using Newtonsoft.Json;
using OpenTK;

namespace OpenTK_GitHub
{
    class origen
    {
        public float X, Y, Z;
        [JsonConstructor]
        public origen(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public static origen operator +(origen a, origen b) => new origen(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static origen operator -(origen a, origen b) => new origen(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static origen operator *(origen a, origen b) => new origen(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static origen operator *(origen a, Matrix3 b) => new origen(
            a.X * b.M11 + a.Y * b.M12 + a.Z * b.M13,
            a.X * b.M21 + a.Y * b.M22 + a.Z * b.M23,
            a.X * b.M31 + a.Y * b.M32 + a.Z * b.M33);
        public static origen operator *(origen a, Matrix4 b) => new origen(
            a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31 + 1f * b.M41,
            a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32 + 1f * b.M42,
            a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33 + 1f * b.M43);
    }
}
