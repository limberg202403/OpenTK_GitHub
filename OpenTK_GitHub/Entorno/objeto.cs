using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;
using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace OpenTK_GitHub.Entorno
{
    class objeto
    {
        [JsonProperty("parts")]
        public Dictionary<string, part> Conjpart { get; set; }
        [JsonProperty("centro")]
        public origen center { get; set; }
        private origen centroEscenario { get; set; }

        public objeto()
        {
            this.Conjpart = new Dictionary<string, part>();
            this.center = new origen(0, 0, 0);
            this.centroEscenario = new origen(0, 0, 0);
        }

        public objeto(origen centro, Dictionary<string, part> partes)
        {
            this.center = centro;
            this.Conjpart = partes;
            this.centroEscenario = new origen(0, 0, 0);
        }
     
        public void addParte(string nombre, part parte)
        {
            this.Conjpart.Add(nombre, parte);
        }
        public void removeParte(string nombre)
        {
            this.Conjpart.Remove(nombre);
        }
        public part getPart(String nombre)
        {
            return Conjpart[nombre];
        }

        public void draw()
        {
            dibujar(new origen(0, 0, 0));
        }
        public void dibujar(origen sceneCentre)
        {
            origen centroObjSce = sceneCentre + this.center;
            foreach (part parte in Conjpart.Values)
            {            
                parte.dibujar(centroObjSce);

            }
        }


        //-------------------------------- TRANSFORMACIONES   -------------------------------//

        internal void translate(string eje, float translateValue)
        {
            foreach (part parte in Conjpart.Values)
            {
                parte.translate(eje, translateValue);
            }
        }
        public void scale(float scaleValue)
        {
            foreach (part parte in Conjpart.Values)
            {
                parte.scale(scaleValue, center + centroEscenario);
            }
        }
   
        public void rotate(string eje, float angle, origen transformacion)
        {
            foreach (part parte in Conjpart.Values)
            {
                parte.rotate(eje, angle, transformacion);
            }
        }

     
    }
}
