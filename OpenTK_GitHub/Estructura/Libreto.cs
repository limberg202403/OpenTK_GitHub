using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Entorno;


namespace OpenTK_GitHub.Estructura
{
    class Libreto //guion
    {
        public List<Acciones> ListaDeAcciones { get; }
        public Escena Escena { get; }

        public Libreto(List<Acciones> listaDeAcciones, Escena escena)
        {
            ListaDeAcciones = listaDeAcciones;
            Escena = escena;
        }
    }
}
