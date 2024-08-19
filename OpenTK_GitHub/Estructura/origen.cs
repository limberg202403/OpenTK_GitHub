using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_GitHub.Estructura
{
    public class origen
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        // Constructor por defecto, inicializa X, Y, Z a 0.
        public origen() : this(0, 0, 0) { }

        // Constructor que toma tres valores.
        public origen(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Constructor que copia otro objeto Origen.
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
