using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;

namespace OpenTK_GitHub.Entorno
{
     class stage
    {
        [JsonProperty("objects")]
        public Dictionary<string, objeto> ConjObjects { get; set; }
        [JsonProperty("centro")]
        public origen center { get; set; }
        public stage()
        {
            ConjObjects = new Dictionary<string, objeto>();
            center = new origen();
        }     

        public stage(Dictionary<string, objeto> objeto, origen centro)
        {
            ConjObjects = objeto;
            center = centro;
        }

        public void addObject(string nameObject, objeto newObjeto)
        {
            newObjeto.center += center;
            ConjObjects.Add(nameObject, newObjeto);
        } 

        public objeto getObject(string nameObject)
        {        
                return ConjObjects[nameObject];          
        }

        public bool deleteObject(string nameObject)
        {          
                return ConjObjects.Remove(nameObject);                               
        }
 
        public void dibujar()
        {
            foreach (objeto Objeto in ConjObjects.Values)
            {
                Objeto.dibujar(center);

            }
        }

        //-------------------------------- TRANSFORMACIONES   -------------------------------//

        public void translate(string eje, float translateValue)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.translate(eje, translateValue);
            }
        }
        public void scale(float scaleValue)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.scale(scaleValue);
            }
        }
        public void rotate(string eje, float angle)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.rotate(eje, angle, this.center);
            }
        }

    }
}
