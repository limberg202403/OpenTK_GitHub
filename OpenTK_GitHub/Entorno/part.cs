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
        [JsonProperty("centro")]
        public origen center { get; set; }   

        public part()
        {
            this.ConjPoligonos = new Dictionary<string, polygon>();
            this.center = new origen(0, 0, 0);
        }

        public part(origen centro, Dictionary<string, polygon> poligonos)
        {
            this.ConjPoligonos = poligonos;
            this.center = centro;
        }   
     
        public void addPoligono(string name, polygon poligono)
        {
            ConjPoligonos.Add(name, poligono);
        }
        public void removePoligono(string name)
        {
            ConjPoligonos.Remove(name);
        }
        public polygon getPolygon(string nombre)
        {
            return ConjPoligonos[nombre];
        }
        public void dibujar()
        {
            dibujar(new origen(0, 0, 0));
        }
        public void dibujar(origen centroUp)
        {
            origen centroResto = center + centroUp;
            foreach (polygon poligono in ConjPoligonos.Values)
            {             
                poligono.dibujar(centroResto);
            }
        }

        //-------------------------------- TRANSFORMACIONES   -------------------------------//

        internal void translate(string eje, float translateValue)
        {
            foreach (polygon poligono in ConjPoligonos.Values)
            {
                poligono.translate(eje, translateValue);
            }
        }
      
        public void scale(float scaleValue, origen transformacion)
        {
            foreach (polygon poligono in ConjPoligonos.Values)
            {
                poligono.scale(scaleValue, transformacion);
            }
        }
     
        public void rotate(string eje, float angle, origen transformacion)
        {
            foreach (polygon poligono in ConjPoligonos.Values)
            {
                poligono.rotate(eje, angle, transformacion);
            }
        }

    }    
}
