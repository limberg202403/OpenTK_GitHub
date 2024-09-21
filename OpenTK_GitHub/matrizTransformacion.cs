using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK_GitHub.Estructura;


namespace OpenTK_GitHub
{
    class matrizTransformacion
    {
        // AQUI EN ESTA CLASE ES DONDE SE HACE LAS OPERACIONES DE LAS TRANSFORMACIONES
        public Matrix4 rotacion { get; set; }
        public Matrix4 traslacion { get; set; }
        public Matrix4 escalacion { get; set; }
        public Matrix4 transformacion { get; set; }
        public Matrix4 centroAcarreado { get; set; }
        public Matrix4 centro { get; set; }

        public matrizTransformacion(origen centro)
        {
            this.rotacion = Matrix4.Identity;
            this.traslacion = Matrix4.Identity;
            this.escalacion = Matrix4.Identity;
            this.transformacion = Matrix4.Identity;
            this.centro = Matrix4.CreateTranslation(centro.X, centro.Y, centro.Z);

        }

        public void SetTransformation()
        {
            this.transformacion = this.centro * this.rotacion * this.escalacion * this.traslacion;
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
    }
}
