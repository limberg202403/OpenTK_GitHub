using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenTK_GitHub.Entorno
{
    internal class Partes
    {
        [JsonProperty("polygons")]
        private Dictionary<string, Poligono> poligonos;
        [JsonProperty("centro")]
        public origen centro;
        [JsonProperty("centroResto")]
        private origen centroResto { get; set; }

        public Partes()
        {
            this.poligonos = new Dictionary<string, Poligono>();
            this.centro = new origen(0, 0, 0);
            this.centroResto = new origen(0, 0, 0);
        }
        public Partes(origen centro, Dictionary<string, Poligono> poligonos)
        {
            this.poligonos = poligonos;
            this.centro = centro;
            this.centroResto = new origen(0, 0, 0);
            setCentroResto(this.centroResto);
        }
        public origen Centro
        {
            get { return centro; }
            set { this.centro = value; }
        }
        public void UpdateVertices()
        {
            foreach (string nombre in poligonos.Keys)
            {
                poligonos[nombre].UpdateVertices();
            }
        }
        public void setCentroResto(origen centroResto)
        {
            this.centroResto = centroResto;
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.setCentroAcarreado(centroResto + centro);
            }
        }
        public void addPoligono(string name, Poligono poligono)
        {
            poligonos.Add(name, poligono);
        }
        public void removePoligono(string name)
        {
            poligonos.Remove(name);
        }
        public Poligono buscarPoligono(string nombre)
        {
            if (poligonos.ContainsKey(nombre))
            {
                return poligonos[nombre];
            }
            else
            {
                return null;
            }
        }
        public void draw()
        {
            draw(new origen(0, 0, 0));
        }
        public void draw(origen centroUp)
        {
            origen centroResto = centro + centroUp;
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.draw(centroResto);
            }
        }

        internal void translate(string eje, float translateValue)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.translate(eje, translateValue);
            }
        }
        public void scale(string eje, float scaleValue)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.scale(eje, scaleValue, centro + centroResto);
            }
        }
        public void scale(string eje, float scaleValue, origen transformacion)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.scale(eje, scaleValue, transformacion);
            }
        }
        public void rotate(string eje, float angle)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.rotate(eje, angle, centro + centroResto);
            }
        }
        public void rotate(string eje, float angle, origen transformacion)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.rotate(eje, angle, transformacion);
            }
        }

        public void limpiar()
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.limpiar();
            }
        }
    }
}
