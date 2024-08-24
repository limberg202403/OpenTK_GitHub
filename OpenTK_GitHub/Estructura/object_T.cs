//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenTK;
//using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace OpenTK_GitHub.Estructura
{
    public class object_T
    {

        float xx = 0.5f;
        float yy = 0.3f;
        float zz = 0.2f;

        private float ancho, alto, profundidad;
        public origen punto;
        public object_T(origen p, float ancho, float alto, float profundidad)
        {
            this.punto = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
        }

        public void draw()
        {
            PrimitiveType beginM = PrimitiveType.Quads;

            /*----------------    PARTE INFERIOR     ----------------------*/
          
                GL.Begin(beginM);
                GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad);
                GL.End();

            
                GL.Begin(beginM);
                GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.End();
           
                GL.Begin(beginM);
                GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro

                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad);
                GL.End();
           
                GL.Begin(beginM);
                GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro

                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad);
                GL.End();
           
                GL.Begin(beginM);
                GL.Color3(0.9f, 0.9f, 0.9f); // Gris muy claro

                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad + zz);
                GL.End();
          
                GL.Begin(beginM);
                GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro

                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad);
                GL.End();
            

            /*------------------------  PARTE SUPERIOR ---------------------------------*/

                GL.Begin(beginM);
                GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.End();
           

                GL.Begin(beginM);
                GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
                GL.End();
          
                GL.Begin(beginM);
                GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro

                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.End();
          
                GL.Begin(beginM);
                GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro

                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
                GL.End();
           
                GL.Begin(beginM);
                GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro

                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad + zz);

                GL.End();
           
                GL.Begin(beginM);
                GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro

                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad);
                GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad + zz);
                GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad);

                GL.End();
            

        }

      
    }
}
