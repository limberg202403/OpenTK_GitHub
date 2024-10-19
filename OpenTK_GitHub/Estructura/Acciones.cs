using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_GitHub.Estructura
{
    class Acciones

    {
        public string keyObjeto;
        public string keyParte;
        public List<Transformacion> listasDeEstados; //listasDeEstados

        public Acciones(string keyObjeto, List<Transformacion> listaDeTransformaciones)
        {
            this.keyObjeto = keyObjeto;
            this.keyParte = "";
            this.listasDeEstados = listaDeTransformaciones;
        }

        public Acciones(string keyObjeto, string keyParte, List<Transformacion> listaDeTransformaciones)
        {
            this.keyObjeto = keyObjeto;
            this.keyParte = keyParte;
            this.listasDeEstados = listaDeTransformaciones;
        }
    }
}
