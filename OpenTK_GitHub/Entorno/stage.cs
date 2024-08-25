using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_GitHub.Estructura;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_GitHub.Entorno
{
    public class stage
    {
        public Dictionary<string, objeto> ObjetosEscenario { get; private set; }
        public origen center { get; set; }

        public stage()
        {
            ObjetosEscenario = new Dictionary<string, objeto>();
        }

        public stage(Dictionary<string, objeto> objeto, origen center)
        {
            ObjetosEscenario = objeto;
            this.center = center;
        }

        public void AgregarObjeto(string nombreObjeto, objeto Objeto)
        {
        
            ObjetosEscenario.Add(nombreObjeto, Objeto);
        }

        public objeto ObtenerObjetoPorNombre(string nombreObjeto)
        {
            if (ObjetosEscenario.ContainsKey(nombreObjeto))
            {
                return ObjetosEscenario[nombreObjeto];
            }
            else return null;
            
        }
     

        public void DibujarEscenario()
        {
            foreach (objeto Objeto in ObjetosEscenario.Values)
            {
                Objeto.DibujarObjeto();
            }
        }

    }
}
