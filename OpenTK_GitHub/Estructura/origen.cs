using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace OpenTK_GitHub.Estructura
{
    public class origen
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

     
        public origen() : this(0, 0, 0) { }

      
        public origen(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public origen(origen t)
        {
            if (t == null) //para evitar excepciones si se intenta copiar un objeto nulo
                throw new ArgumentNullException(nameof(origen));

            X = t.X;
            Y = t.Y;
            Z = t.Z;
        }

       


    }
}
