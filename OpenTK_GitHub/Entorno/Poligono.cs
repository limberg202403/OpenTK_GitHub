using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ProgramacionGrafica;
using System.Collections.Generic;
using System.Drawing;

using OpenTK.Graphics;

namespace OpenTK_GitHub.Entorno
{
    internal class Poligono
    {
        [JsonProperty("vertices")]
        private List<origen> vertices;
        public Color4 color { get; set; }


        [JsonProperty("centro")]
        public origen centroC;
        private origen centroAcarreado;
        public Matrix matriz { get; set; }


        public Poligono()
        {
            vertices = new List<origen>();
            this.color = new Color4();
            color = Color4.Gray;

            this.centroC = new origen(0, 0, 0);
            this.centroAcarreado = new origen(0, 0, 0);
            this.matriz = new Matrix(centroC);
        }
        public Poligono(Color4 color)
        {
            vertices = new List<origen>();
            this.color = color;
            this.centroC = new origen(0, 0, 0);
            this.centroAcarreado = new origen(0, 0, 0);
            this.matriz = new Matrix(centroC);
        }

        public Poligono(Color4 color, origen centroC) //Constructor para un poligono en caso de que sea un circulo
        {
            vertices = new List<origen>();
            this.color = color;
            this.centroC = centroC;
            this.centroAcarreado = new origen(0, 0, 0);
            this.matriz = new Matrix(centroC);
            setCentroAcarreado(new origen(0, 0, 0));
        }
        public origen CentroC
        {
            get { return this.centroC; }
            set { this.centroC = value; }
        }
        public void setCentroAcarreado(origen centroAcarreado)
        {
            this.centroAcarreado = centroAcarreado + centroC;
            this.matriz.SetCentro(this.centroAcarreado.X, this.centroAcarreado.Y, this.centroAcarreado.Z);
        }
        public void addVertice(float x, float y, float z)
        {
            vertices.Add(new origen(x, y, z));
        }
        public void removeVertice(int index)
        {
            vertices.RemoveAt(index);
        }
        public void UpdateVertices()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = new origen(vertices[i].X, vertices[i].Y, vertices[i].Z);
            }
        }
        public void draw()
        {
            draw(new origen(0, 0, 0));
        }

        public void draw(origen centros)
        {
            origen centroResto = centros + centroC;
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(color);
            foreach (origen v in vertices)
            {
                origen vertexToDraw = v;
                vertexToDraw *= matriz.GetMatrix();
                GL.Vertex3(vertexToDraw.X, vertexToDraw.Y, vertexToDraw.Z);
                //GL.Vertex3(vertexToDraw.X + centroResto.X, vertexToDraw.Y + centroResto.Y, vertexToDraw.Z + centroResto.Z);

            }
            GL.End();
        }

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
        public void scale(string axis, float scaleValue, origen transformacion)
        {
            this.matriz.SetCentroAcarreado(transformacion.X, transformacion.Y, transformacion.Z);
            switch (axis)
            {
                case "x":
                    this.matriz.SetEscalacion(scaleValue, 0, 0);
                    break;
                case "y":
                    this.matriz.SetEscalacion(0, scaleValue, 0);
                    break;
                case "z":
                    this.matriz.SetEscalacion(0, 0, scaleValue);
                    break;
            }

        }
        public void scale(string axis, float scaleValue)
        {
            this.matriz.SetCentroAcarreado(centroAcarreado.X, centroAcarreado.Y, centroAcarreado.Z);
            switch (axis)
            {
                case "x":
                    this.matriz.SetEscalacion(scaleValue, 0, 0);
                    break;
                case "y":
                    this.matriz.SetEscalacion(0, scaleValue, 0);
                    break;
                case "z":
                    this.matriz.SetEscalacion(0, 0, scaleValue);
                    break;
            }

        }
        public void rotate(string axis, float angle, origen transformacion)
        {
            this.matriz.SetCentroAcarreado(transformacion.X, transformacion.Y, transformacion.Z);
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
        public void rotate(string axis, float angle)
        {
            this.matriz.SetCentroAcarreado(centroAcarreado.X, centroAcarreado.Y, centroAcarreado.Z);
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

        public void limpiar()
        {
            this.matriz.Limpiar();
        }
    }

}