using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK_GitHub.Estructura;
using Newtonsoft.Json;


namespace OpenTK_GitHub.Entorno
{
    class part
    {
        [JsonProperty("polygons")]

        public Dictionary<string, polygon> ConjPoligonos { get; set; }

        public origen center { get; set; }

        public part()
        {
            ConjPoligonos = new Dictionary<string, polygon>();
            center = new origen();
        }

        public part(Dictionary<string, polygon> poligonos, origen center)
        {
            ConjPoligonos = poligonos;
            this.center = center;
        }

        public void addPolygon(string namePolygon, polygon newPolygon)
        {
            ConjPoligonos.Add(namePolygon, newPolygon);
        }

        public polygon getPolygon(string namePolygon)
        {
            if (ConjPoligonos.ContainsKey(namePolygon))
            {
                return ConjPoligonos[namePolygon];
            }
            else return null;
        }

        public void deletePolygon(string namePolygon)
        {
            ConjPoligonos.Remove(namePolygon);
        }


        public void dibujar()
        {
            foreach (polygon poligono in ConjPoligonos.Values)
            {
                poligono.Trasladar(center.X, center.Y, center.Z);
                poligono.dibujar();
                poligono.Trasladar(-center.X, -center.Y, -center.Z);
            }
        }


        //---------------------------  TRANSFORMACIONESS  ----------------------------//

        public void Trasladar(float x, float y, float z)
        {
            foreach (polygon poligonos in ConjPoligonos.Values)
            {
                poligonos.Trasladar(x, y, z);
            }
        }

        public void Scalar(float n)
        {
            foreach (polygon poligonos in ConjPoligonos.Values)
            {
                poligonos.Scalar(n);
            }
        }

        public void ScalarCentro(origen origin, float n)
        {
            foreach (polygon poligonos in ConjPoligonos.Values)
            {
                poligonos.ScalarCentro(origin, n);
            }
        }

        public void Rotar(string vertice, float angle)
        {
            foreach (polygon poligonos in ConjPoligonos.Values)

            {
                poligonos.Rotar(vertice, angle);
            }
        }

        public void RotarCentro(origen origin, string vertice, float angle)
        {
            foreach (polygon poligonos in ConjPoligonos.Values)
            {
                poligonos.RotarCentro(origin, vertice, angle);
            }
        }


    }    
}
