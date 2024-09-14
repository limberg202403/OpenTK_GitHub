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
               Objeto.Trasladar(center.X, center.Y, center.Z);
                Objeto.dibujar();
                Objeto.Trasladar(-center.X, -center.Y, -center.Z);

            }
        }


        //-------------------------------- TRANSFORMACIONES   -------------------------------//

        public void Transladar(float x, float y, float z)
        {

            center = new origen(center.X + x, center.Y + y, center.Z + z);
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.Trasladar(x, y, z);
            }
        }

        public void Scalar(float n)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.Scalar(n);
            }
        }

        public void ScalarCentro(origen origin, float n)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.ScalarCentro(origin, n);
            }
        }
        public void Rotar(string vertice, float angle)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.Rotar(vertice, angle);
            }
        }

        public void RotarCentro(origen origin, string vertice, float angle)
        {
            foreach (objeto objeto in ConjObjects.Values)
            {
                objeto.RotarCentro(origin, vertice, angle);
            }
        }

    }
}
