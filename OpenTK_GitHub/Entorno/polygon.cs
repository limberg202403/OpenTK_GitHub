using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK_GitHub.Estructura;



namespace OpenTK_GitHub.Entorno
{
    public class polygon
    {       

        public List<Vector3> ConjVertices { get; set; }
        public string name { get; set; }
        public Color4 color { get; set; }
        public origen center { get; set; }

        public polygon()
        {
            ConjVertices = new List<Vector3>();
            color = Color4.Gray;
            name = "";
            center = new origen();

        }

        public polygon(List<Vector3> Vertices, Color4 color)
        {
            ConjVertices = Vertices;
            this.color = color;
            name = "";
      
        }

        public void newVertice(Vector3 vertice)
        {
            ConjVertices.Add(vertice);
        }       

        public void dibujar()
        {

            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);

            foreach (var vertice in ConjVertices)
            {
                GL.Vertex3(vertice.X + center.X, vertice.Y + center.Y, vertice.Z + center.Z);
            }
            GL.End();
        }
    }
}
