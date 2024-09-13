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

        public Dictionary<string, polygon> ConjPoligonos { get;  set; }
        public origen center { get; set; }

        public part()
        {
            ConjPoligonos = new Dictionary<string, polygon>();
        }

        public part(Dictionary<string, polygon> poligonos, origen CentroDeMasa)
        {
            ConjPoligonos = poligonos;
            this.center = CentroDeMasa;
        }

        public void addPolygon(string namePolygon, polygon newPolygon)
        {
            ConjPoligonos.Add(namePolygon,newPolygon);
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
                poligono.dibujar();             
           }
        }

    }
}
