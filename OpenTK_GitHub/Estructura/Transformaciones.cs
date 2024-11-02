using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_GitHub.Estructura
{
    class Transformacion
    {
        public string transformacion { get; }
        public string eje { get; }
        public int CantidadATransformar { get; }
        public long duracion { get; }
        public long tiempoInicio { get; set; }
        public decimal diferencial { get; } // cant incremental
        public long segundos { get; set; }
        public long lastExecutionTime { get; set; }

        public Transformacion(string Tipotransformacion, int ValorATransformar, string eje, long duracion, long tiempoInicio)
        {
            this.transformacion = Tipotransformacion;
            CantidadATransformar = ValorATransformar;
            this.eje = eje;
            this.duracion = duracion;
            this.tiempoInicio = tiempoInicio;

            segundos = duracion / 1000;
            diferencial = (decimal)CantidadATransformar / (22 * segundos);
        }
    }
}
