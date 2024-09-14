using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_GitHub
{
    class IDTransformacion
    {
        public enum TipoTransformacion
        {
            Escala,
            Traslacion,
            Rotacion
        }
        class Model
        {
            public TipoTransformacion tranfClase { get; set; }
            public float Parametro { get; set; }
        }
    }
}
