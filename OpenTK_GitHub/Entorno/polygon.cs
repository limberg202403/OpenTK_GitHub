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
        [JsonProperty("centro")]
        public origen center { get; set; }    
        public matrizTransformacion matriz { get; set; }

        public polygon()
        {
            ConjVertices = new List<origen>();
            this.center = new origen(0, 0, 0);
            this.matriz = new matrizTransformacion(center);
            color = Color4.Gray;
        }
        public polygon(Color4 color)
        {
            ConjVertices = new List<origen>();
            this.color = color;
            this.center = new origen(0, 0, 0);
            this.matriz = new matrizTransformacion(center);
        }
    
        public void addVertice(float x, float y, float z)
        {
            ConjVertices.Add(new origen(x, y, z));
        }
        public void removeVertice(int index)
        {
            ConjVertices.RemoveAt(index);
        }
      

        public void dibujar()
        {
            dibujar(new origen(0, 0, 0));
        }

        public void dibujar(origen centros)
        {
            origen centroResto = centros + center;
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);
            foreach (origen v in ConjVertices)
            {
                origen vertexToDraw = v;
                vertexToDraw *= matriz.GetMatrix();
                GL.Vertex3(vertexToDraw.X + centroResto.X, vertexToDraw.Y + centroResto.Y, vertexToDraw.Z + centroResto.Z);
            }
            GL.End();
        }

        //-------------------------------- TRANSFORMACIONES   -------------------------------//

        public void translate(string axis, float transaleValue)
        {
            switch (axis)
            {
                case "x":
                    this.matriz.SetTraslacion(transaleValue, 0, 0);
                    break;
                case "y":
                    this.matriz.SetTraslacion(0, transaleValue, 0);
                    break;
                case "z":
                    this.matriz.SetTraslacion(0, 0, transaleValue);
                    break;
            }
        }
        public void scale(float scaleValue, origen transformacion)
        {
            this.matriz.SetEscalacion(scaleValue, scaleValue, scaleValue);
        }
       
        public void rotate(string axis, float angle, origen transformacion)
        {

            switch (axis)
            {
                case "x":
                    this.matriz.SetRotacion(angle, 0, 0);
                    break;
                case "y":
                    this.matriz.SetRotacion(0, angle, 0);
                    break;
                case "z":
                    this.matriz.SetRotacion(0, 0, angle);
                    break;
            }
        }            
    }

}
