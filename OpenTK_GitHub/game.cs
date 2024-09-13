using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK;
using OpenTK.Input;
using OpenTK_GitHub.Estructura;
using OpenTK_GitHub.Entorno;

namespace OpenTK_GitHub
{
    public class game:GameWindow
    {     

        stage escenario = new stage();
        objeto T = new objeto();


        string Figure;
        private float angle = 0.0f;        

        public game(string figure, float width, float height ) : base() {
            this.Figure = figure;
        
        }              
       
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.12f, 0.1f, 0.15f, 1.0f);

            string path = @"escenario.json"; //direccion de arcv json
            escenario = SceneSerializer.JsonStage(path);

            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);    
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Rotate(angle*2, 0.0f, 0.5f, 0.0f);
         
            escenario.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width,Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(50.0f), 
            (float)this.Width / (float)this.Height, 0.1f, 100.0f);
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
