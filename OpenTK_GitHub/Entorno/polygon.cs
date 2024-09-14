using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK_GitHub.Estructura;
using System.Collections.Generic;

namespace OpenTK_GitHub.Entorno
{
    class polygon
    {       
        [JsonProperty("vertices")]
        public List<origen> ConjVertices { get; set; }
        public string name { get; set; }
        public Color4 color { get; set; }

        public origen center { get; set; }

        private Matrix4 Model;
        private Matrix4 ModelMaxtrix;

        public polygon()
        {
            ConjVertices = new List<origen>();
            color = Color4.Gray;
            name = "";
            center = new origen();
            Model = Matrix4.Identity;
            ModelMaxtrix = Matrix4.Identity;

        }

        public polygon(List<origen> Vertices, Color4 color)
        {
            ConjVertices = Vertices;
            this.color = color;
            center = new origen();

            name = "";

            Model = Matrix4.Identity;
            ModelMaxtrix = Matrix4.Identity;
        }

        public void newVertice(origen vertice)
        {
            ConjVertices.Add(vertice);
        }

    
        public void dibujar()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);

            foreach (origen vertice in ConjVertices)
            {
                //trasladarDeVuelta
                Vector4 puntoTransformado = Vector4.Transform(new Vector4(vertice.X, vertice.Y, vertice.Z, 1.0f), Model);
                GL.Vertex3(puntoTransformado.X, puntoTransformado.Y, puntoTransformado.Z);
                
            }
            GL.End();           
        }


        //-----------------------  TRANSFORAMCIONES   -----------------------//

        public void Trasladar(float x, float y, float z)
        {
            Model = Matrix4.Mult(Model, Matrix4.CreateTranslation(x, y, z));
            ModelMaxtrix = Matrix4.Mult(Matrix4.CreateTranslation(-x, -y, -z), ModelMaxtrix);
        }

        public void Scalar(float n)
        {
            Model = Matrix4.Mult(Model, Matrix4.CreateScale(n));
            ModelMaxtrix = Matrix4.Mult(Matrix4.CreateScale(1.0f / n), ModelMaxtrix);
        }

        public void ScalarCentro(origen center, float n)
        {
            Trasladar(-center.X, -center.Y, -center.Z);
            Scalar(n);
            Trasladar(center.X, center.Y, center.Z);
        }
        public void Rotar(string axis, float angle)
        {
            float radians = MathHelper.DegreesToRadians(angle);
            Matrix4 rotationMatrix = Matrix4.Identity;

            if (axis == "x")
                rotationMatrix = Matrix4.CreateRotationX(radians);
            else if (axis == "y")
                rotationMatrix = Matrix4.CreateRotationY(radians);
            else if (axis == "z")
                rotationMatrix = Matrix4.CreateRotationZ(radians);

            Model = Matrix4.Mult(Model, rotationMatrix);
            ModelMaxtrix = Matrix4.Mult(rotationMatrix, ModelMaxtrix);
        }

 
        public void RotarCentro(origen center, string axis, float angle)
        {
            Trasladar(-center.X, -center.Y, -center.Z);
            Rotar(axis, angle);
            Trasladar(center.X, center.Y, center.Z);

        }
    }

}
