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
        // EN ESTA CLASE HACE LAS OPERACIONES MATEMATICAS
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

        public static origen operator -(origen punto1, origen punto2)
        {
            return new origen(punto1.X - punto2.X, punto1.Y - punto2.Y, punto1.Z - punto2.Z);
        }

        public static origen operator *(origen punto1, origen punto2)
        {
            return new origen(punto1.X * punto2.X, punto1.Y * punto2.Y, punto1.Z * punto2.Z);
        }

        public static origen operator *(origen punto1, Matrix3 punto2)
        {
            return new origen( punto1.X * punto2.M11 + punto1.Y * punto2.M12 + punto1.Z * punto2.M13,
                               punto1.X * punto2.M21 + punto1.Y * punto2.M22 + punto1.Z * punto2.M23,
                               punto1.X * punto2.M31 + punto1.Y * punto2.M32 + punto1.Z * punto2.M33
                             );
        }

        public static origen operator *(origen punto1, Matrix4 punto2)
        {
            return new origen(punto1.X * punto2.M11 + punto1.Y * punto2.M21 + punto1.Z * punto2.M31 + 1f* punto2.M41,
                               punto1.X * punto2.M12 + punto1.Y * punto2.M22 + punto1.Z * punto2.M32 +1f* punto2.M42,
                               punto1.X * punto2.M13 + punto1.Y * punto2.M23 + punto1.Z * punto2.M33 +1f * punto2.M43
                             );

        }   

    }
}
