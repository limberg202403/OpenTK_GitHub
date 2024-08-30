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
        public object_T T1;
        public object_T T2;
        public object_T T3;

        stage escenario = new stage();
        objeto T = new objeto();

        string Figure;
        private float angle = 0.0f;

        

        public game(String figure, float width, float height ) : base() {
            this.Figure = figure;
        
        }               


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);

            polygon caraFrontalp = new polygon();
            caraFrontalp.newVertice(new Vector3(0.2f, 0.8f, 0.0f ));
            caraFrontalp.newVertice(new Vector3(0.2f, -0.8f, 0.0f ));
            caraFrontalp.newVertice(new Vector3(-0.2f, -0.8f, 0.0f));
            caraFrontalp.newVertice(new Vector3(-0.2f, 0.8f, 0.0f));
            caraFrontalp.color = new Color4(0.8f, 0.8f, 0.8f, 0.8f);


            polygon caraAtrasp = new polygon();
            caraAtrasp.newVertice(new Vector3(0.2f, 0.8f, 0.2f  ));
            caraAtrasp.newVertice(new Vector3(0.2f, -0.8f, 0.2f ));
            caraAtrasp.newVertice(new Vector3(-0.2f, -0.8f, 0.2f));
            caraAtrasp.newVertice(new Vector3(-0.2f, 0.8f, 0.2f));
            caraAtrasp.color = new Color4(0.8f, 0.8f, 0.8f, 0.8f);
         

            polygon caraDerechap = new polygon();
            caraDerechap.newVertice(new Vector3(0.2f, 0.8f, 0.2f  ));
            caraDerechap.newVertice(new Vector3(0.2f, -0.8f, 0.2f ));
            caraDerechap.newVertice(new Vector3(0.2f, -0.8f, 0.0f  ));
            caraDerechap.newVertice(new Vector3(0.2f, 0.8f, 0.0f));
            caraDerechap.color = new Color4(0.6f, 0.6f, 0.6f, 0.6f);

            polygon caraIzquierdap = new polygon();
            caraIzquierdap.newVertice(new Vector3(-0.2f, 0.8f, 0.0f  ));
            caraIzquierdap.newVertice(new Vector3(-0.2f, 0.8f, 0.2f   ));
            caraIzquierdap.newVertice(new Vector3(-0.2f, -0.8f, 0.2f  ));
            caraIzquierdap.newVertice(new Vector3(-0.2f, -0.8f, 0.0f  ));
            caraIzquierdap.color = new Color4(0.7f, 0.7f, 0.7f,0.7f);

            polygon caraSuperiorp = new polygon();
            caraSuperiorp.newVertice(new Vector3(0.2f, 0.8f, 0.2f ));
            caraSuperiorp.newVertice(new Vector3(0.2f, 0.8f, 0.0f ));
            caraSuperiorp.newVertice(new Vector3(-0.2f, 0.8f, 0.0f ));
            caraSuperiorp.newVertice(new Vector3(-0.2f, 0.8f, 0.2f));
            caraSuperiorp.color = new Color4(0.9f, 0.9f, 0.9f, 0.9f);

            polygon caraInferiorp = new polygon();
            caraInferiorp.newVertice(new Vector3(0.2f, -0.8f, 0.0f ));
            caraInferiorp.newVertice(new Vector3(0.2f, -0.8f, 0.2f ));
            caraInferiorp.newVertice(new Vector3(-0.2f, -0.8f, 0.2f ));
            caraInferiorp.newVertice(new Vector3(-0.2f, -0.8f, 0.0f));
            caraInferiorp.color = new Color4(0.5f, 0.5f, 0.5f, 0.5f);


            //---------------------------------PARTE SUPERIOR----------------------------------------------//


            polygon caraAtrass = new polygon();
            caraAtrass.newVertice(new Vector3(0.7f, 1.1f, 0.0f));
            caraAtrass.newVertice(new Vector3(0.7f, 0.8f, 0.0f));
            caraAtrass.newVertice(new Vector3(-0.7f, 0.8f, 0.0f));
            caraAtrass.newVertice(new Vector3(-0.7f, 1.1f, 0.0f));
            caraAtrass.color = new Color4(0.8f, 0.8f, 0.8f, 0.8f);

            polygon caraAdelantes = new polygon();
            caraAdelantes.newVertice(new Vector3(0.7f, 1.1f, 0.2f));
            caraAdelantes.newVertice(new Vector3(0.7f, 0.8f, 0.2f));
            caraAdelantes.newVertice(new Vector3(-0.7f, 0.8f, 0.2f));
            caraAdelantes.newVertice(new Vector3(-0.7f, 1.1f, 0.2f));
            caraAdelantes.color = new Color4(0.8f, 0.8f, 0.8f, 0.8f);
      
            polygon caraDers = new polygon();
            caraDers.newVertice(new Vector3(0.7f, 1.1f, 0.2f));
            caraDers.newVertice(new Vector3(0.7f, 0.8f, 0.2f));
            caraDers.newVertice(new Vector3(0.7f, 0.8f, 0.0f));
            caraDers.newVertice(new Vector3(0.7f, 1.1f, 0.0f));
            caraDers.color = new Color4(0.6f, 0.6f, 0.6f, 0.6f);
        
            polygon caraIzqs = new polygon();
            caraIzqs.newVertice(new Vector3(-0.7f, 1.1f, 0.0f));
            caraIzqs.newVertice(new Vector3(-0.7f, 0.8f, 0.0f));
            caraIzqs.newVertice(new Vector3(-0.7f, 0.8f, 0.2f));
            caraIzqs.newVertice(new Vector3(-0.7f, 1.1f, 0.2f));
            caraIzqs.color = new Color4(0.7f, 0.7f, 0.7f, 0.7f);
        
            polygon caraSups = new polygon();
            caraSups.newVertice(new Vector3(0.7f, 1.1f, 0.2f));
            caraSups.newVertice(new Vector3(0.7f, 1.1f, 0.0f));
            caraSups.newVertice(new Vector3(-0.7f, 1.1f, 0.0f));
            caraSups.newVertice(new Vector3(-0.7f, 1.1f, 0.2f));
            caraSups.color = new Color4(0.6f, 0.6f, 0.6f, 0.6f);         

            polygon caraInfs = new polygon();
            caraInfs.newVertice(new Vector3(0.7f, 0.8f, 0.0f));
            caraInfs.newVertice(new Vector3(0.7f, 0.8f, 0.2f));
            caraInfs.newVertice(new Vector3(-0.7f, 0.8f, 0.2f));
            caraInfs.newVertice(new Vector3(-0.7f, 0.8f, 0.0f));
            caraInfs.color = new Color4(0.5f, 0.5f, 0.5f, 0.5f);



            part partesCub = new part();

            partesCub.center = new origen(0.0f,0.0f,0.0f);

            partesCub.addPolygon("traserap", caraFrontalp);
            partesCub.addPolygon("delanterap", caraAtrasp);
            partesCub.addPolygon("Derechap", caraDerechap);
            partesCub.addPolygon("Izquierdap", caraIzquierdap);
            partesCub.addPolygon("Superiorp", caraSuperiorp);
            partesCub.addPolygon("Inferiorp", caraInferiorp);

            partesCub.addPolygon("traseras", caraAtrass);
            partesCub.addPolygon("delanteras", caraAdelantes);
            partesCub.addPolygon("Derechas", caraDers);
            partesCub.addPolygon("Izquierdas", caraIzqs);
            partesCub.addPolygon("Superiors", caraSups);
            partesCub.addPolygon("Inferiors", caraInfs);

            T.center = new origen(0.0f,0.0f,0.0f);
            T.addPart("T",partesCub);

            escenario.addObject("letraT", T);
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
