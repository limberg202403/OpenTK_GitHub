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
        objeto objeto = new objeto();
        part parte = new part();


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


            //------------------------ ROTACION DEL escenario --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.X))
            {
                escenario.rotate("x", 1.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Y))
            {
                escenario.rotate("y", 1.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Z))
            {
                escenario.rotate("z", 1.8f);
            }
         
            //------------------------ ESCALAR EL ESCENARIO  --------------------------------//

            if (Keyboard.GetState().IsKeyDown(Key.Number1))
            {
                escenario.scale(0.95f); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.Number2))
            {
                escenario.scale(1.05f); 
            }

            //------------------------ ESCALAR UNA PARTE  --------------------------------//

            if (Keyboard.GetState().IsKeyDown(Key.Number3))
            {
                escenario.getObject("letraT").getPart("partesCub").scale(0.95f, new origen()); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.Number4))
            {
                escenario.getObject("letraT").getPart("partesCub").scale(1.05f, new origen()); 
                                                                            
            }

            //------------------------ TRASLADAR EL ESCENARIO  --------------------------------//

            if (Keyboard.GetState().IsKeyDown(Key.A))
            {
                escenario.translate("x", -0.1f); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.D))
            {
                escenario.translate("x", 0.1f); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                escenario.translate("y", 0.1f); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                escenario.translate("y", -0.1f); 
            }

            //------------------------ ROTAR UNA PARTE --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.C))  
            {
                escenario.getObject("letraT").getPart("partesCub").rotate("x", 1.8f, new origen());

            }
            if (Keyboard.GetState().IsKeyDown(Key.V))   
            {
                escenario.getObject("letraT").getPart("partesCub").rotate("y", 1.8f, new origen());

            }

            if (Keyboard.GetState().IsKeyDown(Key.B))
            {
                escenario.getObject("letraT").getPart("partesCub").rotate("z", 1.8f, new origen());

            }

            //------------------------ ROTAR El OBJETO --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.R))
            {
                escenario.getObject("letraT").rotate("x", 1.5f, new origen());
            }
            if (Keyboard.GetState().IsKeyDown(Key.T))
            {
                escenario.getObject("letraT").rotate("y", 1.5f, new origen());
            }

            //------------------------ TRASLADAR El OBJETO --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.I))
            {
                escenario.getObject("letraT").getPart("partesCub").translate("y", 0.05f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.K))
            {
                escenario.getObject("letraT").getPart("partesCub").translate("y", -0.05f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.J))
            {
                escenario.getObject("letraT").getPart("partesCub").translate("x", -0.05f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.L))
            {
                escenario.getObject("letraT").getPart("partesCub").translate("x", 0.05f);
            }

            base.OnUpdateFrame(e);
        }
    }
}
