using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Input;
using OpenTK_GitHub.Estructura;



namespace OpenTK_GitHub
{
    internal class game:GameWindow
    {
        public object_T T1;
        public object_T T2;
        public object_T T3;

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

            T1 = new object_T(new origen(), 0.2f, 0.8f, 0.0f);
            T2 = new object_T(new origen(1.5f, 1.0f, 0.0f), 0.2f, 0.8f, 0.0f);
            T3 = new object_T(new origen(-1.5f, -1.0f, 0.0f), 0.2f, 0.8f, 0.0f);
            T1.draw();
            T2.draw();
            T3.draw();
          
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
