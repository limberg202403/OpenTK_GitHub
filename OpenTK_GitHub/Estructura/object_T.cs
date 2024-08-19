using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
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
            BeginMode beginM = BeginMode.Quads;

            caraTraseraI(beginM);
            caraDelanteraI(beginM);
            caraDerechaI(beginM);
            caraIzquierdaI(beginM);
            caraSuperiorI(beginM);
            caraInferiorI(beginM);

            caraTraseraS(beginM);
            caraDelanteraS(beginM);
            caraDerechaS(beginM);
            caraIzquierdaS(beginM);
            caraSuperiorS(beginM);
            caraInferiorS(beginM);

        }

        /*----------------    PARTE INFERIOR     ----------------------*/
        public void caraTraseraI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad);
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad);
            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad);

            GL.End();

        }
        public void caraDelanteraI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro


            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad+zz);
            GL.End();
        }
        public void caraDerechaI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro
            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad );
            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad );

            GL.End();
        }
        public void caraIzquierdaI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro

            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad );

            GL.End();
        }
        public void caraSuperiorI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.9f, 0.9f, 0.9f); // Gris muy claro
            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho, punto.Y + alto, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho, punto.Y + alto, punto.Z + profundidad + zz);

            GL.End();
        }
        public void caraInferiorI(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad );
            GL.Vertex3(punto.X + ancho, punto.Y - alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho, punto.Y - alto, punto.Z + profundidad );

            GL.End();
        }

        /*------------------------  PARTE SUPERIOR ---------------------------------*/

        public void caraTraseraS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

            GL.Vertex3(punto.X + ancho +xx, punto.Y + alto+yy , punto.Z + profundidad);
            GL.Vertex3(punto.X + ancho +xx, punto.Y + alto, punto.Z + profundidad);
            GL.Vertex3(punto.X - ancho -xx, punto.Y + alto, punto.Z + profundidad);
            GL.Vertex3(punto.X - ancho -xx, punto.Y + alto+yy, punto.Z + profundidad);

            GL.End();
        }
        public void caraDelanteraS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad+zz);
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad+zz);

            GL.End();
        }
        public void caraDerechaS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro

            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad );
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad );

            GL.End();
        }
        public void caraIzquierdaS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro

            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad + zz);

            GL.End();
        }
        public void caraSuperiorS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro

            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto + yy, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad );
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto + yy, punto.Z + profundidad + zz);

            GL.End();
        }
        public void caraInferiorS(BeginMode beginM)
        {
            GL.Begin(beginM);
            GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro

            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto , punto.Z + profundidad );
            GL.Vertex3(punto.X + ancho + xx, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto, punto.Z + profundidad + zz);
            GL.Vertex3(punto.X - ancho - xx, punto.Y + alto , punto.Z + profundidad );

            GL.End();
        }
    }
}
