using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OpenTK_GitHub.Entorno
{
    internal class Objeto
    {
        [JsonProperty("parts")]
        private Dictionary<string, Partes> partes { get; set; }
        [JsonProperty("centro")]
        public origen centro { get; set; }
        private origen centroEscenario { get; set; }



        public Objeto()
        {
            this.partes = new Dictionary<string, Partes>();
            this.centro = new origen(0, 0, 0);
            this.centroEscenario = new origen(0, 0, 0);
        }

        public Objeto(origen centro, Dictionary<string, Partes> partes)
        {
            this.centro = centro;
            this.partes = partes;
            this.centroEscenario = new origen(0, 0, 0);
            setSceneCentro(new origen(0, 0, 0));
        }
        public void setSceneCentro(origen centroEscenario)
        {
            this.centroEscenario = centroEscenario;
            foreach (var parte in partes.Values)
            {
                parte.setCentroResto(this.centro + this.centroEscenario);
            }
        }
        public void addParte(string nombre, Partes parte)
        {
            this.partes.Add(nombre, parte);
        }
        public void removeParte(string nombre)
        {
            this.partes.Remove(nombre);
        }
        public Partes buscarPartes(String nombre)
        {
            if (partes.ContainsKey(nombre))
            {
                return partes[nombre];
            }
            else
            {
                return null;
            }
        }
        public float x
        {
            get { return centro.X; }
        }
        public origen Centro
        {
            get { return centro; }
            set { this.centro = value; }
        }
        public float centroY
        {
            get { return centro.Y; }
        }
        public float centroZ
        {
            get { return centro.Z; }
        }

        public void draw()
        {
            draw(new origen(0, 0, 0));
        }
        public void draw(origen sceneCentre)
        {
            origen centroObjSce = sceneCentre + this.centro;
            foreach (Partes parte in partes.Values)
            {
                parte.draw(centroObjSce);
            }
        }

        public void UpdateVertices()
        {
            foreach (string nombre in partes.Keys)
            {
                partes[nombre].UpdateVertices();
            }
        }
        internal void translate(string eje, float translateValue)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.translate(eje, translateValue);
            }
        }
        public void scale(string eje, float scaleValue)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.scale(eje, scaleValue, centro + centroEscenario);
            }
        }
        public void scale(string eje, float scaleValue, origen transformacion)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.scale(eje, scaleValue, transformacion);
            }
        }
        public void rotate(string eje, float angle)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.rotate(eje, angle, centro + centroEscenario);
            }
        }
        public void rotate(string eje, float angle, origen transformacion)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.rotate(eje, angle, transformacion);
            }
        }

        public void clear()
        {
            foreach (Partes parte in partes.Values)
            {
                parte.clear();
            }
        }
    }
}
