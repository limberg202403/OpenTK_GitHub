using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Input;


namespace OpenTK_GitHub
{
    internal class game:GameWindow
    {
        string Figure;
        private float angle = 0.0f;      

        public game(String figure, float width, float height ) : base() {
            this.Figure = figure;            
        }
           
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);

            // GL.ClearColor(Color.SlateGray);
            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);    
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Rotate(angle*2, 0.0f, 0.5f, 0.0f);
        
            // Dibujar el letra "T"
            GL.Begin(BeginMode.Quads);


            /*--------------------------PARTE INFERIOR-----------------------------*/

            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro

            ///cara trasera |
            GL.Vertex3(0.2f, 0.8f, 0.0f);
            GL.Vertex3(0.2f, -0.8f, 0.0f);
            GL.Vertex3(-0.2f, -0.8f, 0.0f);
            GL.Vertex3(-0.2f, 0.8f, 0.0f);


            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro
            //cara delantera |
            GL.Vertex3(0.2f, 0.8f, 0.2f);
            GL.Vertex3(0.2f, -0.8f, 0.2f);
            GL.Vertex3(-0.2f, -0.8f, 0.2f);
            GL.Vertex3(-0.2f, 0.8f, 0.2f);


            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro
            //cara derecha |
            GL.Vertex3(0.2f, 0.8f, 0.2f);
            GL.Vertex3(0.2f, -0.8f, 0.2f);
            GL.Vertex3(0.2f, -0.8f, 0.0f);
            GL.Vertex3(0.2f, 0.8f, 0.0f);


            GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro
            //cara izquierda |
            GL.Vertex3(-0.2f, 0.8f, 0.0f);
            GL.Vertex3(-0.2f, 0.8f, 0.2f);
            GL.Vertex3(-0.2f, -0.8f, 0.2f);
            GL.Vertex3(-0.2f, -0.8f, 0.0f);


            GL.Color3(0.9f, 0.9f, 0.9f); // Gris muy claro
            //cara Superior |
            GL.Vertex3(0.2f, 0.8f, 0.2f);
            GL.Vertex3(0.2f, 0.8f, 0.0f);
            GL.Vertex3(-0.2f, 0.8f, 0.0f);
            GL.Vertex3(-0.2f, 0.8f, 0.2f);


            GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro
            //cara Inferior |
            GL.Vertex3(0.2f, -0.8f, 0.0f);
            GL.Vertex3(0.2f, -0.8f, 0.2f);
            GL.Vertex3(-0.2f, -0.8f, 0.2f);
            GL.Vertex3(-0.2f, -0.8f, 0.0f);


            /*--------------------------PARTE SUPERIOR-----------------------------*/

            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro
            // cara  trasera--
            GL.Vertex3(0.7f, 1.1f, 0.0f);
            GL.Vertex3(0.7f, 0.8f, 0.0f);
            GL.Vertex3(-0.7f, 0.8f, 0.0f);
            GL.Vertex3(-0.7f, 1.1f, 0.0f);


            GL.Color3(0.8f, 0.8f, 0.8f); // Gris más claro
            // cara delantera --
            GL.Vertex3(0.7f, 1.1f, 0.2f);
            GL.Vertex3(0.7f, 0.8f, 0.2f);
            GL.Vertex3(-0.7f, 0.8f, 0.2f);
            GL.Vertex3(-0.7f, 1.1f, 0.2f);


            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro
            //Cara derecha --
            GL.Vertex3(0.7f, 1.1f, 0.2f);
            GL.Vertex3(0.7f, 0.8f, 0.2f);
            GL.Vertex3(0.7f, 0.8f, 0.0f);
            GL.Vertex3(0.7f, 1.1f, 0.0f);


            GL.Color3(0.7f, 0.7f, 0.7f); // Gris claro
            //Cara izquierda --
            GL.Vertex3(-0.7f, 1.1f, 0.0f);
            GL.Vertex3(-0.7f, 0.8f, 0.0f);
            GL.Vertex3(-0.7f, 0.8f, 0.2f);
            GL.Vertex3(-0.7f, 1.1f, 0.2f);


            GL.Color3(0.6f, 0.6f, 0.6f); // Gris más oscuro
            //Cara superior  --
            GL.Vertex3(0.7f, 1.1f, 0.2f);
            GL.Vertex3(0.7f, 1.1f, 0.0f);
            GL.Vertex3(-0.7f, 1.1f, 0.0f);
            GL.Vertex3(-0.7f, 1.1f, 0.2f);


            GL.Color3(0.5f, 0.5f, 0.5f); // Gris oscuro
            //Cara inferior  --
            GL.Vertex3(0.7f, 0.8f, 0.0f);
            GL.Vertex3(0.7f, 0.8f, 0.2f);
            GL.Vertex3(-0.7f, 0.8f, 0.2f);
            GL.Vertex3(-0.7f, 0.8f, 0.0f);
           
            GL.End();


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width,Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 
            (float)this.Width / (float)this.Height, 0.1f, 90.0f);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);

            base.OnResize(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            // Limpiar 
            GL.Disable(EnableCap.DepthTest);
            base.OnUnload(e);
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {                        
            if (Keyboard.GetState().IsKeyDown(Key.Q))
            {
                angle += 20.0f * (float)e.Time;
            }           
            base.OnUpdateFrame(e);
        }
    }
}
