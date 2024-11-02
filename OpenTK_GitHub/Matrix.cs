using OpenTK;
using OpenTK_GitHub;
using OpenTK_GitHub.Entorno;


namespace ProgramacionGrafica
{
    class Matrix
    {

        public Matrix4 rotacion { get; set; }
        public Matrix4 traslacion { get; set; }
        public Matrix4 escalacion { get; set; }
        public Matrix4 transformacion { get; set; }
        public Matrix4 centroAcarreado { get; set; }
        public Matrix4 centro { get; set; }

        public Matrix(origen centro)
        {
            this.rotacion = Matrix4.Identity;
            this.traslacion = Matrix4.Identity;
            this.escalacion = Matrix4.Identity;
            this.transformacion = Matrix4.Identity;
            this.centro = Matrix4.CreateTranslation(centro.X, centro.Y, centro.Z);
            this.centroAcarreado = Matrix4.Identity;

        }

        public void SetTransformation()
        {
            this.transformacion = this.centro * this.centroAcarreado.Inverted() * this.rotacion * this.escalacion * this.traslacion * this.centroAcarreado;
        }
        public Matrix4 GetMatrix()
        {
            return this.transformacion;
        }
        public void SetCentro(float x, float y, float z)
        {
            this.centro = Matrix4.CreateTranslation(x, y, z);
            SetTransformation();
        }
        public void SetCentroAcarreado(float x, float y, float z)
        {
            this.centroAcarreado = Matrix4.CreateTranslation(x, y, z);
            SetTransformation();
        }
        public void SetTraslacion(float x, float y, float z)
        {
            this.traslacion *= Matrix4.CreateTranslation(x, y, z);
            SetTransformation();

        }
        public void SetEscalacion(float x, float y, float z)
        {
            this.escalacion *= Matrix4.CreateScale(x, y, z);
            SetTransformation();

        }

        public void SetRotacion(float x, float y, float z)
        {
            float rotarX = MathHelper.DegreesToRadians(x);
            float rotarY = MathHelper.DegreesToRadians(y);
            float rotarZ = MathHelper.DegreesToRadians(z);
            this.rotacion *= Matrix4.CreateRotationX(rotarX) * Matrix4.CreateRotationY(rotarY) * Matrix4.CreateRotationZ(rotarZ);
            SetTransformation();
        }

        public void clear()
        {
            this.rotacion = Matrix4.Identity;
            this.traslacion = Matrix4.Identity;
            this.escalacion = Matrix4.Identity;
            this.centroAcarreado = Matrix4.Identity;
        }
    }
}