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
        public origen center { get; set; }

        public stage()
        {
            ConjObjects = new Dictionary<string, objeto>();
            center = new origen();
        }

        public stage(Dictionary<string, objeto> objeto, origen center)
        {
            ConjObjects = objeto;
            this.center = center;
        }

        public void addObject(string nameObject, objeto newObjeto)
        {
            ConjObjects.Add(nameObject, newObjeto);
        }

        public objeto getObject(string nameObject)
        {
            if (ConjObjects.ContainsKey(nameObject))
            {
                return ConjObjects[nameObject];
            }
            else return null;
        }

        public bool deleteObject(string nameObject)
        {
            if (ConjObjects.ContainsKey(nameObject))
            {
                ConjObjects.Remove(nameObject);               
                return true;
            }
            else return false;            
        }
 

        public void dibujar()
        {
            foreach (objeto Objeto in ConjObjects.Values)
            {
                Objeto.dibujar();
            }
        }

    }
}
