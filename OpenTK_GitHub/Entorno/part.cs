using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK_GitHub.Estructura;



namespace OpenTK_GitHub.Entorno
{
    public class part
    {

        public Dictionary<string, polygon> ConjPoligonos { get; private set; }
        public origen center { get; set; }

        public part()
        {
            ConjPoligonos = new Dictionary<string, polygon>();
        }

        public part(Dictionary<string, polygon> poligonos, origen CentroDeMasa)
        {
            ConjPoligonos = poligonos;
            this.center = CentroDeMasa;
        }

        public void AgregarCara(string nombreCara, polygon poligonos)
        {
            ConjPoligonos.Add(nombreCara, poligonos);

        }
      
        public void DibujarFigura()
        {
            foreach (polygon cara in ConjPoligonos.Values)
            {
                GL.PushMatrix();
                GL.Translate(center.X, center.Y, center.Z);
                cara.dibujar();
                GL.PopMatrix();
            }
        }

    }
}
