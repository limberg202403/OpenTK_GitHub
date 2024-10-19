using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenTK_GitHub.Entorno;

namespace OpenTK_GitHub.Estructura
{
    class Controller
    {
        Libreto libreto;      
        public int tiempoInicial;
        public Controller(Libreto libreto)
        {
            this.libreto = libreto;
        }

        public void Execute()
        {
            tiempoInicial = Environment.TickCount;
            int timeFinish = 60000;
            List<Acciones> listaDeAcciones = libreto.ListaDeAcciones;

            while (true)
            {
                int tiempoTranscurrido = Environment.TickCount - tiempoInicial;

                if (tiempoTranscurrido >= timeFinish)
                {
                    tiempoInicial = Environment.TickCount;
                }
                            
                foreach (Acciones accion in listaDeAcciones)
                {
                    int tiempoActual = Environment.TickCount - tiempoInicial;
                    Objeto objeto = libreto.Escena.buscarObjeto(accion.keyObjeto);
                    Partes parte = null;
                    if (accion.keyParte != "")
                    {
                        parte = objeto.buscarPartes(accion.keyParte);
                    }
                    List<Transformacion> listaDeTransformaciones = accion.listasDeEstados;
                    foreach (Transformacion transformacion in listaDeTransformaciones)
                    {
                        if (tiempoActual >= transformacion.tiempoInicio && tiempoActual <= (transformacion.tiempoInicio + transformacion.duracion))
                        {
                            if (transformacion.lastExecutionTime == 0 || (Environment.TickCount - transformacion.lastExecutionTime) >= 40)
                            {

                                AplicarTransformacion(objeto, transformacion, parte, accion);
                                transformacion.lastExecutionTime = Environment.TickCount;
                            }
                        }
                    }
                }
            }
        }

      
        private void AplicarTransformacion(Objeto objeto, Transformacion transformacion, Partes parte, Acciones accion)
        {
            float diferencial = (float)transformacion.diferencial;//grado de cambio que se aplicara a la transf
            if (accion.keyParte == "")
            {
                switch (transformacion.transformacion)
                {
                    case "Traslacion":
                        objeto.translate(transformacion.eje, diferencial);
                        break;
                    case "Rotacion":
                        objeto.rotate(transformacion.eje, diferencial);
                        break;
                    case "Escalacion":
                        objeto.scale(transformacion.eje, diferencial);
                        break;
                }
            }
            else
            {
                switch (transformacion.transformacion)
                {
                    case "Traslacion":
                        parte.translate(transformacion.eje, diferencial);
                        break;
                    case "Rotacion":
                        parte.rotate(transformacion.eje, diferencial);
                        break;
                    case "Escalacion":
                        parte.scale(transformacion.eje, diferencial);
                        break;
                }
            }

        }
    }
}
