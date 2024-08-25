using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;

namespace OpenTK_GitHub.Entorno
{
    public class objeto
    {

        public Dictionary<string, part> PartesObjeto { get; private set; }
        public origen center { get; set; }


        public objeto()
        {
            PartesObjeto = new Dictionary<string, part>();
            center = new origen(0, 0, 0); // Inicializar el centro de masa del objeto
        }

        public objeto(Dictionary<string, part> partes, origen centro)
        {
            PartesObjeto = partes;
            this.center = centro;
        }

        public void AgregarPartes(string nombrePartes, part partes)
        {
        
            PartesObjeto.Add(nombrePartes, partes);
        }

        public part ObtenerPartePorNombre(string nombreParte)
        {
            if (PartesObjeto.ContainsKey(nombreParte))
            {
                return PartesObjeto[nombreParte];
            }
            else
            {
                return null;
            }
        }

      
        public void DibujarObjeto()
        {
            foreach (part partes in PartesObjeto.Values)
            {
                partes.DibujarFigura();
            }
        }
    }
}
