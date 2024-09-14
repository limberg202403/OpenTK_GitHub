using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;


namespace OpenTK_GitHub.Estructura
{
    
    public class origen
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public origen() : this(0, 0, 0) { }

        [JsonConstructor]
        public origen(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public origen(origen t)
        {
            if (t == null) //para evitar excepciones si se intenta copiar un objeto nulo
                throw new ArgumentNullException(nameof(origen));

            X = t.X;
            Y = t.Y;
            Z = t.Z;
        }

        public static origen operator +(origen punto1, origen punto2)
        {
            return new origen(punto1.X + punto2.X, punto1.Y + punto2.Y, punto1.Z + punto2.Z);
        }

        public void TrasladarPunto(origen translation)
        {
            X += translation.X;
            Y += translation.Y;
            Z += translation.Z;
        }


        public void EscalarPunto(float scaleX, float scaleY, float scaleZ)
        {
            X *= scaleX;
            Y *= scaleY;
            Z *= scaleZ;
        }

    }
}
