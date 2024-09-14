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

        private float yaw = -90f;
        private float pitch = 0f;
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


            //------------------------ ROTACION DEL OBJETO --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.X))
            {
                escenario.getObject("letraT").Rotar("x", 0.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Y))
            {
                escenario.getObject("letraT").Rotar("y", 0.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Z))
            {
                escenario.getObject("letraT").Rotar("z", 0.8f);
            }


            // Capturar entrada del usuario para rotar la cámara
            if (Keyboard.GetState().IsKeyDown(Key.Number1))
            {
                escenario.Scalar(0.95f); // Reducir escala del escenario
            }
            if (Keyboard.GetState().IsKeyDown(Key.Number2))
            {
                escenario.Scalar(1.05f); // Aumentar escala del escenario
            }
            if (Keyboard.GetState().IsKeyDown(Key.Number3))
            {
                escenario.getObject("letraT").getPart("partesCub1").Scalar(0.95f); // Reducir escala del escenario
            }
            if (Keyboard.GetState().IsKeyDown(Key.Number4))
            {
                escenario.getObject("letraT").getPart("partesCub1").Scalar(1.05f); // Aumentar escala del escenario
            }
            if (Keyboard.GetState().IsKeyDown(Key.A))
            {
                escenario.getObject("letraT").Trasladar(-0.1f, 0.0f, 0.0f); // Traslación hacia la izquierda
            }
            if (Keyboard.GetState().IsKeyDown(Key.D))
            {
                escenario.getObject("letraT").Trasladar(0.1f, 0.0f, 0.0f); // Traslación hacia la derecha
            }
            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                escenario.getObject("letraT").Trasladar(0.0f, 0.1f, 0.0f); // Traslación hacia adelante
            }
            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                escenario.getObject("letraT").Trasladar(0.0f, -0.1f, 0.0f); // Traslación hacia adelante
            }    
            
            //------------------------ ROTAR UNA PARTE --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.C))
            {
                escenario.getObject("letraT").getPart("partesCub1").RotarCentro(parte.center, "x", 1.0f); 
            }
            if (Keyboard.GetState().IsKeyDown(Key.V))
            {
                escenario.getObject("letraT").getPart("partesCub1").RotarCentro(parte.center, "y", 1.0f);
            }

            //------------------------ ROTAR El OBJETO --------------------------------//
            if (Keyboard.GetState().IsKeyDown(Key.R))
            {
                escenario.getObject("letraT").RotarCentro(new origen(), "x", 1.0f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.T))
            {
                escenario.getObject("letraT").RotarCentro(new origen(), "y", 1.0f);
            }
            

            if (Keyboard.GetState().IsKeyDown(Key.G))
            {
                escenario.RotarCentro(new origen(), "y", 1.0f);
            }
            

            if (Keyboard.GetState().IsKeyDown(Key.I))
            {
                escenario.getObject("letraT").getPart("partesCub1").Trasladar(0.0f, 0.1f, 0.0f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.K))
            {
                escenario.getObject("letraT").getPart("partesCub1").Trasladar(0.0f, -0.1f, 0.0f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.J))
            {
                escenario.getObject("letraT").getPart("partesCub1").Trasladar(-0.1f, 0.0f, 0.0f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.L))
            {
                escenario.getObject("letraT").getPart("partesCub1").Trasladar(0.1f, 0.0f, 0.0f);
            }

            base.OnUpdateFrame(e);
        }
    }
}
