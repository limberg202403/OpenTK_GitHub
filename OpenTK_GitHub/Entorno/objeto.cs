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

        public origen center { get; set; }

        public objeto()
        {
            Conjpart = new Dictionary<string, part>();
            center = new origen(); 
        }

        public objeto(Dictionary<string, part> part, origen centro)
        {
            Conjpart = part;
            center = centro;
        }

        public void addPart(string NamePart, part newPart)
        {
            newPart.center = newPart.center + center;
            Conjpart.Add(NamePart, newPart);
        }
    
        public part getPart(string namePart)
        {
            if (Conjpart.ContainsKey(namePart))
            {
                return Conjpart[namePart];
            }
            else return null;
        }

        public void deletePart(string NamePart)
        {
            Conjpart.Remove(NamePart);
        }

        public void dibujar()
        {
            foreach (part part in Conjpart.Values)
            {
                part.Trasladar(center.X, center.Y, center.Z);
                part.dibujar();
                part.Trasladar(-center.X, -center.Y, -center.Z);
            }  
        }


        //--------------------  TRANSFORMACIONESS  -----------------------//

        public void Trasladar(float x, float y, float z)
        {
            center = new origen(center.X + x, center.Y + y, center.Z + z);

            foreach (part part in Conjpart.Values)
            {
                part.Trasladar(x, y, z);
            }
        }

        public void Scalar(float n)
        {
            foreach (part part in Conjpart.Values)
            {
                part.Scalar(n);
            }
        }

        public void ScalarCentro(origen origin, float n)
        {
            foreach (part part in Conjpart.Values)
            {
                part.ScalarCentro(origin, n);
            }
        }

        public void Rotar(string vertice, float angle)
        {
            foreach (part partes in Conjpart.Values)
            {
                partes.Rotar(vertice, angle);
            }
        }

        public void RotarCentro(origen origin, string vertice, float angle)
        {

            foreach (part partes in Conjpart.Values)
            {

                partes.RotarCentro(origin, vertice, angle);

            }
        }
    }
}
