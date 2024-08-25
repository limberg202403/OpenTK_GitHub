using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_GitHub.Entorno
{
    public class polygon
    {

        public List<Vector3> ConjVertices { get; set; }
        public string nombre { get; set; }
        public Color4 color { get; set; }
        public origen center;

        public polygon()
        {
            ConjVertices = new List<Vector3>();
            color = Color4.Black;
            nombre = "";
         
        }

        public polygon(List<Vector3> Vertices, Color4 color)
        {
            ConjVertices = Vertices;
            this.color = color;
            nombre = "";
      
        }

        public void addPunto(Vector3 vertice)
        {
            ConjVertices.Add(vertice);
        }
       
        public void dibujar()
        {
            GL.Color4(0.2f,0.2f,0.2,1.0f);
            GL.Begin(PrimitiveType.Quads);

            foreach (Vector3 vertice in ConjVertices)
            {
                GL.Vertex3(vertice.X + center.X, vertice.Y + center.Y, vertice.Z + center.Z);
            }

            GL.End();
        }
    }
}
