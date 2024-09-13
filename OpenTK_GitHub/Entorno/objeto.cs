using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;
using Newtonsoft.Json;

namespace OpenTK_GitHub.Entorno
{
    class objeto
    {
        [JsonProperty("parts")]
        public Dictionary<string, part> ConjPartes { get; set; }
        public origen center { get; set; }

        public objeto()
        {
            ConjPartes = new Dictionary<string, part>();
            center = new origen(); 
        }

        public objeto(Dictionary<string, part> partes, origen centro)
        {
            ConjPartes = partes;
            center = centro;
        }

        public void addPart(string NamePart, part newPart)
        {
            ConjPartes.Add(NamePart, newPart);
        }
    
        public part getPart(string namePart)
        {
            if (ConjPartes.ContainsKey(namePart))
            {
                return ConjPartes[namePart];
            }
            else return null;
        }

        public void deletePart(string NamePart)
        {
            ConjPartes.Remove(NamePart);
        }

        public void dibujar()
        {
            foreach (part partes in ConjPartes.Values)
            {
                partes.dibujar();
            }
        }
    }
}
