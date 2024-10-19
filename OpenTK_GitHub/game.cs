using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using OpenTK_GitHub.Entorno;
using OpenTK_GitHub.Estructura;


namespace OpenTK_GitHub
{
    class game : GameWindow
    {
        Escena escenario;
        Escena animacion;
        public Controller controlador;
        private Libreto libreto;
        Thread ejecutar;


        public game(int widht, int height, string title) : base(widht, height, GraphicsMode.Default, title)
        {
            //---------------------------------------------------------------------------------------------------
            Color colorPiel = Color.FromArgb(255, 255, 224); // Color piel claro
            Poligono cabeza = new Poligono(colorPiel, new origen(0, 6, 0)); // La cabeza está en el punto (0,6,0)

            // Añadir los vértices para una esfera
            int numLatitudes = 60;
            int numLongitudes = 40;
            float radio = 3.0f;

            for (int lat = 0; lat <= numLatitudes; lat++)
            {
                float theta = lat * (float)Math.PI / numLatitudes; // Ángulo de latitud
                float sinTheta = (float)Math.Sin(theta);
                float cosTheta = (float)Math.Cos(theta);

                for (int lon = 0; lon <= numLongitudes; lon++)
                {
                    float phi = lon * 2 * (float)Math.PI / numLongitudes; // Ángulo de longitud
                    float sinPhi = (float)Math.Sin(phi);
                    float cosPhi = (float)Math.Cos(phi);

                    // Coordenadas de la esfera
                    float x = radio * sinTheta * cosPhi;
                    float y = radio * cosTheta;
                    float z = radio * sinTheta * sinPhi;

                    cabeza.addVertice(x, y, z); // Agregar el punto en el espacio 3D
                }
            }

            // Añadir la cabeza al objeto persona
            Dictionary<string, Poligono> polygonsCabeza = new Dictionary<string, Poligono>();
            polygonsCabeza.Add("Cabeza", cabeza);
            Partes parteCabeza = new Partes(new origen(0, 0, 0), polygonsCabeza);

            //-------------------------------------------------------------------
            Color colorCuello = Color.FromArgb(255, 255, 224);
            Poligono cuello = new Poligono(colorCuello, new origen(0, 0.45f, 0));

            int numDivisiones = 100;
            float altura = 2.5f;
            float radio1 = 1.5f;

            // Añadir los vértices para el cilindro
            for (int i = 0; i <= numDivisiones; i++)
            {
                float angulo = 2 * (float)Math.PI * i / numDivisiones;
                float x = radio1 * (float)Math.Cos(angulo);
                float z = radio1 * (float)Math.Sin(angulo);

                cuello.addVertice(x, altura, z); // Vértice superior

                cuello.addVertice(x, 0, z); // Vértice inferior
            }

            Dictionary<string, Poligono> polygonsCuello = new Dictionary<string, Poligono>();
            polygonsCuello.Add("Cuello", cuello);
            Partes parteCuello = new Partes(new origen(0, 0, 0), polygonsCuello);


            //--------------------------------------------------------


            Color colorTorso = Color.FromArgb(255, 224, 192); // Color piel claro
            Poligono torso = new Poligono(Color.Bisque, new origen(0, -3.0f, 0));

            // Parte superior del torso (hombros)
            torso.addVertice(-2, 4, 4);
            torso.addVertice(2, 4, 4);
            torso.addVertice(2, -6, 4);
            torso.addVertice(-2, -6, 4);

            // Parte inferior del torso 
            torso.addVertice(-2, 4, -4);
            torso.addVertice(2, 4, -4);
            torso.addVertice(2, -6, -4);
            torso.addVertice(-2, -6, -4);

            // Parte inferior del torso 
            torso.addVertice(2, 4, 4);
            torso.addVertice(2, 4, -4);
            torso.addVertice(2, -6, -4);
            torso.addVertice(2, -6, 4);


            // Parte inferior del torso 
            torso.addVertice(-2, 4, 4);
            torso.addVertice(-2, 4, -4);
            torso.addVertice(-2, -6, -4);
            torso.addVertice(-2, -6, 4);


            // Parte inferior del torso 
            torso.addVertice(-2, 4, 4);
            torso.addVertice(2, 4, 4);
            torso.addVertice(2, 4, -4);
            torso.addVertice(-2, 4, -4);

            // Parte inferior del torso 
            torso.addVertice(-2, -6, 4);
            torso.addVertice(2, -6, 4);
            torso.addVertice(2, -6, -4);
            torso.addVertice(-2, -6, -4);

            Dictionary<string, Poligono> polygonsTorso = new Dictionary<string, Poligono>();
            polygonsTorso.Add("Torso", torso);
            Partes parteTorso = new Partes(new origen(0, 0, 0), polygonsTorso);

            /////////////////   /////////////////        
            Color colorBrazo = Color.FromArgb(255, 224, 192); // Color piel claro
            Poligono brazo = new Poligono(Color.Red, new origen(0, -2.5f, 4.0f)); // Posición cerca del hombro

            brazo.addVertice(-1.5f, 3, 1);
            brazo.addVertice(1.5f, 3, 1);
            brazo.addVertice(1.5f, 1, 1);
            brazo.addVertice(-1.5f, 1, 1);

            // Parte inferior del brazo (cerc
            brazo.addVertice(-1.5f, 1, 1);
            brazo.addVertice(1.5f, 1, 1);
            brazo.addVertice(1.5f, -1, 1);
            brazo.addVertice(-1.5f, -1, 1);

            // Parte trasera del brazo
            brazo.addVertice(-1.5f, 3, -1);
            brazo.addVertice(1.5f, 3, -1);
            brazo.addVertice(1.5f, 1, -1);
            brazo.addVertice(-1.5f, 1, -1);

            // Parte inferior trasera del bra
            brazo.addVertice(-1.5f, -1, -1);
            brazo.addVertice(1.5f, -1, -1);
            brazo.addVertice(1.5f, -1, 1);
            brazo.addVertice(-1.5f, -1, 1);

            // Parte delantera
            brazo.addVertice(-1.5f, 3, 1);
            brazo.addVertice(1.5f, 3, 1);
            brazo.addVertice(1.5f, 1, 1);
            brazo.addVertice(-1.5f, 1, 1);

            // Parte trasera
            brazo.addVertice(-1.5f, 3, -1);
            brazo.addVertice(-1.5f, 1, -1);
            brazo.addVertice(1.5f, 1, -1);
            brazo.addVertice(1.5f, 3, -1);

            // Parte izquierda
            brazo.addVertice(-1.5f, 3, 1);
            brazo.addVertice(-1.5f, 3, -1);
            brazo.addVertice(-1.5f, 1, -1);
            brazo.addVertice(-1.5f, 1, 1);

            // Parte derecha
            brazo.addVertice(1.5f, 3, 1);
            brazo.addVertice(1.5f, 3, -1);
            brazo.addVertice(1.5f, 1, -1);
            brazo.addVertice(1.5f, 1, 1);

            // Parte inferior
            brazo.addVertice(-1.5f, -1, 1);
            brazo.addVertice(1.5f, -1, 1);
            brazo.addVertice(1.5f, -1, -1);
            brazo.addVertice(-1.5f, -1, -1);


            // Añadir el brazo al objeto persona
            Dictionary<string, Poligono> polygonsBrazo = new Dictionary<string, Poligono>();
            polygonsBrazo.Add("Brazo", brazo);
            Partes parteBrazo = new Partes(new origen(0, 0, 0), polygonsBrazo);

            //_-------------------------------------------------------------------------------
            Color colorBrazo1 = Color.FromArgb(255, 224, 192); // Color piel claro
            Poligono brazo1 = new Poligono(Color.Red, new origen(0, -2.5f, -5.0f)); // Posición cerca del hombro

            // Vértices del brazo (rectángulo en 3D inclinado)

            brazo1.addVertice(-1.5f, 3, 1);
            brazo1.addVertice(1.5f, 3, 1);
            brazo1.addVertice(1.5f, 1, 1);
            brazo1.addVertice(-1.5f, 1, 1);

            brazo1.addVertice(-1.5f, 1, 1);
            brazo1.addVertice(1.5f, 1, 1);
            brazo1.addVertice(1.5f, -1, 1);
            brazo1.addVertice(-1.5f, -1, 1);

            brazo1.addVertice(-1.5f, 3, -1);
            brazo1.addVertice(1.5f, 3, -1);
            brazo1.addVertice(1.5f, 1, -1);
            brazo1.addVertice(-1.5f, 1, -1);

            brazo1.addVertice(-1.5f, -1, -1);
            brazo1.addVertice(1.5f, -1, -1);
            brazo1.addVertice(1.5f, -1, 1);
            brazo1.addVertice(-1.5f, -1, 1);

            // Parte delantera
            brazo1.addVertice(-1.5f, 3, 1);
            brazo1.addVertice(1.5f, 3, 1);
            brazo1.addVertice(1.5f, 1, 1);
            brazo1.addVertice(-1.5f, 1, 1);

            // Parte trasera
            brazo1.addVertice(-1.5f, 3, -1);
            brazo1.addVertice(-1.5f, 1, -1);
            brazo1.addVertice(1.5f, 1, -1);
            brazo1.addVertice(1.5f, 3, -1);

            // Parte izquierda
            brazo1.addVertice(-1.5f, 3, 1);
            brazo1.addVertice(-1.5f, 3, -1);
            brazo1.addVertice(-1.5f, 1, -1);
            brazo1.addVertice(-1.5f, 1, 1);

            // Parte derecha
            brazo1.addVertice(1.5f, 3, 1);
            brazo1.addVertice(1.5f, 3, -1);
            brazo1.addVertice(1.5f, 1, -1);
            brazo1.addVertice(1.5f, 1, 1);

            // Parte inferior
            brazo1.addVertice(-1.5f, -1, 1);
            brazo1.addVertice(1.5f, -1, 1);
            brazo1.addVertice(1.5f, -1, -1);
            brazo1.addVertice(-1.5f, -1, -1);

            // Añadir el brazo al objeto persona
            Dictionary<string, Poligono> polygonsBrazo1 = new Dictionary<string, Poligono>();
            polygonsBrazo1.Add("Brazo1", brazo1);
            Partes parteBrazo1 = new Partes(new origen(0, 0, 0), polygonsBrazo1);

            //-------------------------------------------ANTEBRAZO----------------------------------------------
            // Definir el color y crear el polígono para el antebrazo
            Color colorAntebrazo = Color.FromArgb(0, 0, 255); // Color azul
            Poligono antebrazo = new Poligono(colorAntebrazo, new origen(0, -4.0f, 4.0f));

            // Parte superior del antebrazo (unido al brazo)
            antebrazo.addVertice(-1.0f, 1, 1);
            antebrazo.addVertice(1.0f, 1, 1);
            antebrazo.addVertice(1.0f, -1, 1);
            antebrazo.addVertice(-1.0f, -1, 1);

            // Parte trasera del antebrazo
            antebrazo.addVertice(-1.0f, 1, -1);
            antebrazo.addVertice(1.0f, 1, -1);
            antebrazo.addVertice(1.0f, -1, -1);
            antebrazo.addVertice(-1.0f, -1, -1);

            // Parte inferior del antebrazo (cerc
            antebrazo.addVertice(-1.0f, -1, 1);
            antebrazo.addVertice(1.0f, -1, 1);
            antebrazo.addVertice(1.0f, -3, 1);
            antebrazo.addVertice(-1.0f, -3, 1);

            antebrazo.addVertice(-1.0f, -1, -1);
            antebrazo.addVertice(1.0f, -1, -1);
            antebrazo.addVertice(1.0f, -3, -1);
            antebrazo.addVertice(-1.0f, -3, -1);

            // Conectar los vértices para crear las caras

            // Parte delantera
            antebrazo.addVertice(-1.0f, 1, 1);
            antebrazo.addVertice(1.0f, 1, 1);
            antebrazo.addVertice(1.0f, -1, 1);
            antebrazo.addVertice(-1.0f, -1, 1);

            // Parte trasera
            antebrazo.addVertice(-1.0f, 1, -1);
            antebrazo.addVertice(-1.0f, -1, -1);
            antebrazo.addVertice(1.0f, -1, -1);
            antebrazo.addVertice(1.0f, 1, -1);

            // Parte izquierda
            antebrazo.addVertice(-1.0f, 1, 1);
            antebrazo.addVertice(-1.0f, 1, -1);
            antebrazo.addVertice(-1.0f, -1, -1);
            antebrazo.addVertice(-1.0f, -1, 1);

            // Parte derecha
            antebrazo.addVertice(1.0f, 1, 1);
            antebrazo.addVertice(1.0f, 1, -1);
            antebrazo.addVertice(1.0f, -1, -1);
            antebrazo.addVertice(1.0f, -1, 1);

            // Parte inferior
            antebrazo.addVertice(-1.0f, -3, 1);
            antebrazo.addVertice(1.0f, -3, 1);
            antebrazo.addVertice(1.0f, -3, -1);
            antebrazo.addVertice(-1.0f, -3, -1);

            Dictionary<string, Poligono> polygonsAntebrazo = new Dictionary<string, Poligono>();
            // Añadir el antebrazo al objeto persona
            polygonsAntebrazo.Add("Antebrazo", antebrazo);
            Partes parteAntebrazo = new Partes(new origen(0, 0, 0), polygonsAntebrazo);

            //-------------------------------------------ANTEBRAZO 1----------------------------------------------

            Color colorAntebrazo1 = Color.FromArgb(0, 0, 255); // Color azul
            Poligono antebrazo1 = new Poligono(colorAntebrazo1, new origen(0, -4.0f, -5.0f));

            antebrazo1.addVertice(-1.0f, 1, 1);
            antebrazo1.addVertice(1.0f, 1, 1);
            antebrazo1.addVertice(1.0f, -1, 1);
            antebrazo1.addVertice(-1.0f, -1, 1);

            // Parte trasera del antebrazo
            antebrazo1.addVertice(-1.0f, 1, -1);
            antebrazo1.addVertice(1.0f, 1, -1);
            antebrazo1.addVertice(1.0f, -1, -1);
            antebrazo1.addVertice(-1.0f, -1, -1);

            // Parte inferior del antebrazo (cerca
            antebrazo1.addVertice(-1.0f, -1, 1);
            antebrazo1.addVertice(1.0f, -1, 1);
            antebrazo1.addVertice(1.0f, -3, 1);
            antebrazo1.addVertice(-1.0f, -3, 1);

            antebrazo1.addVertice(-1.0f, -1, -1);
            antebrazo1.addVertice(1.0f, -1, -1);
            antebrazo1.addVertice(1.0f, -3, -1);
            antebrazo1.addVertice(-1.0f, -3, -1);


            // Parte delantera
            antebrazo1.addVertice(-1.0f, 1, 1);
            antebrazo1.addVertice(1.0f, 1, 1);
            antebrazo1.addVertice(1.0f, -1, 1);
            antebrazo1.addVertice(-1.0f, -1, 1);

            // Parte trasera
            antebrazo1.addVertice(-1.0f, 1, -1);
            antebrazo1.addVertice(-1.0f, -1, -1);
            antebrazo1.addVertice(1.0f, -1, -1);
            antebrazo1.addVertice(1.0f, 1, -1);

            // Parte izquierda
            antebrazo1.addVertice(-1.0f, 1, 1);
            antebrazo1.addVertice(-1.0f, 1, -1);
            antebrazo1.addVertice(-1.0f, -1, -1);
            antebrazo1.addVertice(-1.0f, -1, 1);

            // Parte derecha
            antebrazo1.addVertice(1.0f, 1, 1);
            antebrazo1.addVertice(1.0f, 1, -1);
            antebrazo1.addVertice(1.0f, -1, -1);
            antebrazo1.addVertice(1.0f, -1, 1);

            // Parte inferior
            antebrazo1.addVertice(-1.0f, -3, 1);
            antebrazo1.addVertice(1.0f, -3, 1);
            antebrazo1.addVertice(1.0f, -3, -1);
            antebrazo1.addVertice(-1.0f, -3, -1);


            Dictionary<string, Poligono> polygonsAntebrazo1 = new Dictionary<string, Poligono>();
            // Añadir el antebrazo al objeto persona
            polygonsAntebrazo1.Add("Antebrazo", antebrazo1);
            Partes parteAntebrazo1 = new Partes(new origen(0, 0, 0), polygonsAntebrazo1);

            //---------------------------- piernas  --------------------------------

            // Definir el color y crear el polígono para la pierna
            Color colorPierna = Color.FromArgb(110, 69, 19); // Color café
            Poligono pierna = new Poligono(colorPierna, new origen(-1, -2.0f, 2.0f)); // Posición relativa de la pierna


            pierna.addVertice(-2f, 1, 1);
            pierna.addVertice(2f, 1, 1);
            pierna.addVertice(2f, -4, 1);
            pierna.addVertice(-2f, -4, 1);

            pierna.addVertice(-2f, 1, -1);
            pierna.addVertice(2f, 1, -1);
            pierna.addVertice(2f, -4, -1);
            pierna.addVertice(-2f, -4, -1);

            pierna.addVertice(-2f, -4, 1);
            pierna.addVertice(2f, -4, 1);
            pierna.addVertice(2f, -6, 1);
            pierna.addVertice(-2f, -6, 1);

            pierna.addVertice(-2f, -4, -1);
            pierna.addVertice(2f, -4, -1);
            pierna.addVertice(2f, -6, -1);
            pierna.addVertice(-2f, -6, -1);

            // Conectar los vértices para crear las caras

            // Parte delantera
            pierna.addVertice(-2f, 1, 1);
            pierna.addVertice(2f, 1, 1);
            pierna.addVertice(2f, -4, 1);
            pierna.addVertice(-2f, -4, 1);

            // Parte trasera
            pierna.addVertice(-2f, 1, -1);
            pierna.addVertice(-2f, -4, -1);
            pierna.addVertice(2f, -4, -1);
            pierna.addVertice(2f, 1, -1);

            // Parte izquierda
            pierna.addVertice(-2f, 1, 1);
            pierna.addVertice(-2f, 1, -1);
            pierna.addVertice(-2f, -4, -1);
            pierna.addVertice(-2f, -4, 1);

            // Parte derecha
            pierna.addVertice(2f, 1, 1);
            pierna.addVertice(2f, 1, -1);
            pierna.addVertice(2f, -4, -1);
            pierna.addVertice(2f, -4, 1);

            // Parte inferior (cerca del pie)
            pierna.addVertice(-2f, -6, 1);
            pierna.addVertice(2f, -6, 1);
            pierna.addVertice(2f, -6, -1);
            pierna.addVertice(-2f, -6, -1);

            // Añadir la pierna al objeto persona

            Dictionary<string, Poligono> polygonsPierna = new Dictionary<string, Poligono>();
            polygonsPierna.Add("Pierna", pierna);
            Partes partePierna = new Partes(new origen(0, -8, 0), polygonsPierna);

            //_-----------------------------    ---------------------------------


            // Definir el color y crear el polígono para la pierna
            Color colorPierna1 = Color.FromArgb(139, 69, 19); // Color café
            Poligono pierna1 = new Poligono(colorPierna1, new origen(1, -2.0f, -3.0f)); // Posición relativa de la pierna

            // Vértices de la pierna (rectángulo en 3D)

            pierna1.addVertice(-1.7f, 1, 1);
            pierna1.addVertice(1.7f, 1, 1);
            pierna1.addVertice(1.7f, -4, 1);
            pierna1.addVertice(-1.7f, -4, 1);

            pierna1.addVertice(-1.7f, 1, -1);
            pierna1.addVertice(1.7f, 1, -1);
            pierna1.addVertice(1.7f, -4, -1);
            pierna1.addVertice(-1.7f, -4, -1);

            pierna1.addVertice(-1.7f, -4, 1);
            pierna1.addVertice(1.7f, -4, 1);
            pierna1.addVertice(1.7f, -6, 1);
            pierna1.addVertice(-1.7f, -6, 1);

            pierna1.addVertice(-1.7f, -4, -1);
            pierna1.addVertice(1.7f, -4, -1);
            pierna1.addVertice(1.7f, -6, -1);
            pierna1.addVertice(-1.7f, -6, -1);

            // Conectar los vértices para crear las caras

            // Parte delantera
            pierna1.addVertice(-1.7f, 1, 1);
            pierna1.addVertice(1.7f, 1, 1);
            pierna1.addVertice(1.7f, -4, 1);
            pierna1.addVertice(-1.7f, -4, 1);

            // Parte trasera
            pierna1.addVertice(-1.7f, 1, -1);
            pierna1.addVertice(-1.7f, -4, -1);
            pierna1.addVertice(1.7f, -4, -1);
            pierna1.addVertice(1.7f, 1, -1);

            // Parte izquierda
            pierna1.addVertice(-1.7f, 1, 1);
            pierna1.addVertice(-1.7f, 1, -1);
            pierna1.addVertice(-1.7f, -4, -1);
            pierna1.addVertice(-1.7f, -4, 1);

            // Parte derecha
            pierna1.addVertice(1.7f, 1, 1);
            pierna1.addVertice(1.7f, 1, -1);
            pierna1.addVertice(1.7f, -4, -1);
            pierna1.addVertice(1.7f, -4, 1);

            // Parte inferior (cerca del pie)
            pierna1.addVertice(-1.7f, -6, 1);
            pierna1.addVertice(1.7f, -6, 1);
            pierna1.addVertice(1.7f, -6, -1);
            pierna1.addVertice(-1.7f, -6, -1);

            Dictionary<string, Poligono> polygonsPierna1 = new Dictionary<string, Poligono>();
            polygonsPierna1.Add("Pierna1", pierna1);
            Partes partePierna1 = new Partes(new origen(0, -8, 0), polygonsPierna1);

            //_----------------------------- PIERNA INFERIOR---------------------------------

            Color colorParteInferior = Color.FromArgb(255, 228, 181); // Color piel
            Poligono parteInferiorPierna = new Poligono(colorParteInferior, new origen(-1, -16.0f, 2.0f));


            // Parte superior de la pierna (unido al torso)
            parteInferiorPierna.addVertice(-1.7f, 1, 1);
            parteInferiorPierna.addVertice(1.7f, 1, 1);
            parteInferiorPierna.addVertice(1.7f, -4, 1);
            parteInferiorPierna.addVertice(-1.7f, -4, 1);

            // Parte trasera de la pierna
            parteInferiorPierna.addVertice(-1.7f, 1, -1);
            parteInferiorPierna.addVertice(1.7f, 1, -1);
            parteInferiorPierna.addVertice(1.7f, -4, -1);
            parteInferiorPierna.addVertice(-1.7f, -4, -1);

            // Parte inferior de la pierna (cerca del pie)
            parteInferiorPierna.addVertice(-1.7f, -4, 1);
            parteInferiorPierna.addVertice(1.7f, -4, 1);
            parteInferiorPierna.addVertice(1.7f, -6, 1);
            parteInferiorPierna.addVertice(-1.7f, -6, 1);

            parteInferiorPierna.addVertice(-1.7f, -4, -1);
            parteInferiorPierna.addVertice(1.7f, -4, -1);
            parteInferiorPierna.addVertice(1.7f, -6, -1);
            parteInferiorPierna.addVertice(-1.7f, -6, -1);

            // Conectar los vértices para crear las caras

            // Parte delantera
            parteInferiorPierna.addVertice(-1.7f, 1, 1);
            parteInferiorPierna.addVertice(1.7f, 1, 1);
            parteInferiorPierna.addVertice(1.7f, -4, 1);
            parteInferiorPierna.addVertice(-1.7f, -4, 1);

            // Parte trasera
            parteInferiorPierna.addVertice(-1.7f, 1, -1);
            parteInferiorPierna.addVertice(-1.7f, -4, -1);
            parteInferiorPierna.addVertice(1.7f, -4, -1);
            parteInferiorPierna.addVertice(1.7f, 1, -1);

            // Parte izquierda
            parteInferiorPierna.addVertice(-1.7f, 1, 1);
            parteInferiorPierna.addVertice(-1.7f, 1, -1);
            parteInferiorPierna.addVertice(-1.7f, -4, -1);
            parteInferiorPierna.addVertice(-1.7f, -4, 1);

            // Parte derecha
            parteInferiorPierna.addVertice(1.7f, 1, 1);
            parteInferiorPierna.addVertice(1.7f, 1, -1);
            parteInferiorPierna.addVertice(1.7f, -4, -1);
            parteInferiorPierna.addVertice(1.7f, -4, 1);

            // Parte inferior (cerca del pie)
            parteInferiorPierna.addVertice(-1.7f, -6, 1);
            parteInferiorPierna.addVertice(1.7f, -6, 1);
            parteInferiorPierna.addVertice(1.7f, -6, -1);
            parteInferiorPierna.addVertice(-1.7f, -6, -1);


            Dictionary<string, Poligono> polygonsParteInferior = new Dictionary<string, Poligono>();
            polygonsParteInferior.Add("ParteInferiorPierna", parteInferiorPierna);
            Partes parteInferiorP = new Partes(new origen(0, 0, 0), polygonsParteInferior);

            //_----------------------------- PIERNA INFERIOR 1 

            Color colorParteInferior1 = Color.FromArgb(160, 228, 181); // Color piel
            Poligono parteInferiorPierna1 = new Poligono(colorParteInferior1, new origen(1, -16.0f, -3.0f));


            parteInferiorPierna1.addVertice(-1.7f, 1, 1);
            parteInferiorPierna1.addVertice(1.7f, 1, 1);
            parteInferiorPierna1.addVertice(1.7f, -4, 1);
            parteInferiorPierna1.addVertice(-1.7f, -4, 1);

            // Parte trasera de la pierna
            parteInferiorPierna1.addVertice(-1.7f, 1, -1);
            parteInferiorPierna1.addVertice(1.7f, 1, -1);
            parteInferiorPierna1.addVertice(1.7f, -4, -1);
            parteInferiorPierna1.addVertice(-1.7f, -4, -1);

            // Parte inferior de la pierna (cerca del pie)
            parteInferiorPierna1.addVertice(-1.7f, -4, 1);
            parteInferiorPierna1.addVertice(1.7f, -4, 1);
            parteInferiorPierna1.addVertice(1.7f, -6, 1);
            parteInferiorPierna1.addVertice(-1.7f, -6, 1);

            parteInferiorPierna1.addVertice(-1.7f, -4, -1);
            parteInferiorPierna1.addVertice(1.7f, -4, -1);
            parteInferiorPierna1.addVertice(1.7f, -6, -1);
            parteInferiorPierna1.addVertice(-1.7f, -6, -1);

            // Conectar los vértices para crear las caras

            // Parte delantera
            parteInferiorPierna1.addVertice(-1.7f, 1, 1);
            parteInferiorPierna1.addVertice(1.7f, 1, 1);
            parteInferiorPierna1.addVertice(1.7f, -4, 1);
            parteInferiorPierna1.addVertice(-1.7f, -4, 1);

            // Parte trasera
            parteInferiorPierna1.addVertice(-1.7f, 1, -1);
            parteInferiorPierna1.addVertice(-1.7f, -4, -1);
            parteInferiorPierna1.addVertice(1.7f, -4, -1);
            parteInferiorPierna1.addVertice(1.7f, 1, -1);

            // Parte izquierda
            parteInferiorPierna1.addVertice(-1.7f, 1, 1);
            parteInferiorPierna1.addVertice(-1.7f, 1, -1);
            parteInferiorPierna1.addVertice(-1.7f, -4, -1);
            parteInferiorPierna1.addVertice(-1.7f, -4, 1);

            // Parte derecha
            parteInferiorPierna1.addVertice(1.7f, 1, 1);
            parteInferiorPierna1.addVertice(1.7f, 1, -1);
            parteInferiorPierna1.addVertice(1.7f, -4, -1);
            parteInferiorPierna1.addVertice(1.7f, -4, 1);

            // Parte inferior (cerca del pie)
            parteInferiorPierna1.addVertice(-1.7f, -6, 1);
            parteInferiorPierna1.addVertice(1.7f, -6, 1);
            parteInferiorPierna1.addVertice(1.7f, -6, -1);
            parteInferiorPierna1.addVertice(-1.7f, -6, -1);

            Dictionary<string, Poligono> polygonsParteInferior1 = new Dictionary<string, Poligono>();
            polygonsParteInferior1.Add("ParteInferiorPierna1", parteInferiorPierna1);
            Partes parteInferiorP1 = new Partes(new origen(0, 0, 0), polygonsParteInferior1);

            //---------------------------------------------------------------------------------------------------
            // Cambiamos el color a azul
            Color colorPelota = Color.FromArgb(0, 0, 255);

            // Instanciamos el balón con un nuevo color
            Poligono pelota = new Poligono(Color4.Blue, new origen(0, 6, 0));

            int numLatitudes1 = 60;
            int numLongitudes1 = 40;
            float radio2 = 3.0f;

            for (int lat = 0; lat <= numLatitudes1; lat++)
            {
                float theta = lat * (float)Math.PI / numLatitudes1;
                float sinTheta = (float)Math.Sin(theta);
                float cosTheta = (float)Math.Cos(theta);

                for (int lon = 0; lon <= numLongitudes1; lon++)
                {
                    float phi = lon * 2 * (float)Math.PI / numLongitudes1;
                    float sinPhi = (float)Math.Sin(phi);
                    float cosPhi = (float)Math.Cos(phi);

                    // Coordenadas de la esfera
                    float x = radio2 * sinTheta * cosPhi;
                    float y = radio2 * cosTheta;
                    float z = radio2 * sinTheta * sinPhi;

                    pelota.addVertice(x, y, z);
                }
            }

            // Añadir el balón a la colección de polígonos
            Dictionary<string, Poligono> polygonsPelota = new Dictionary<string, Poligono>();
            polygonsPelota.Add("poliPelota", pelota);

            // Instanciar la parte del balón
            Partes partePelota = new Partes(new origen(-2.5f, 8.5f, 0), polygonsPelota);


            //--------------------------------------------------------


            Dictionary<string, Partes> ParteHumano = new Dictionary<string, Partes>();
            ParteHumano.Add("cabeza", parteCabeza);
            ParteHumano.Add("cuello", parteCuello);
            ParteHumano.Add("Torso", parteTorso);
            ParteHumano.Add("brazo", parteBrazo);
            ParteHumano.Add("brazo1", parteBrazo1);
            ParteHumano.Add("antebrazo", parteAntebrazo);
            ParteHumano.Add("antebrazo1", parteAntebrazo1);
            ParteHumano.Add("pierna", partePierna);
            ParteHumano.Add("pierna1", partePierna1);
            ParteHumano.Add("InferiorPierna", parteInferiorP);
            ParteHumano.Add("InferiorPierna1", parteInferiorP1);
            //-------------------

            Dictionary<string, Partes> Partepelot = new Dictionary<string, Partes>();
            Partepelot.Add("pelota", partePelota);


            Objeto humano = new Objeto(new origen(42, 10, 0), ParteHumano);

            Objeto balon = new Objeto(new origen(0, 0, 0), Partepelot);



            Color colorRampa = Color.FromArgb(78, 128, 147);
            Poligono rampaTecho = new Poligono(colorRampa, new origen(-27, -7, 0));
            rampaTecho.addVertice(9, 2, 5);
            rampaTecho.addVertice(9, 2, -5);
            rampaTecho.addVertice(-9, -2, -5);
            rampaTecho.addVertice(-9, -2, 5);


            ///- pared y repoisa -----------------------------------------------------------


            Dictionary<string, Objeto> objetosCuarto = new Dictionary<string, Objeto>();
            objetosCuarto.Add("humano", humano);
            objetosCuarto.Add("balon", balon);

            animacion = new Escena(new origen(0, 0, 0), objetosCuarto);

            //------------------------- animacion
            List<Transformacion> listaDeConversiones = new List<Transformacion>();
            List<Transformacion> listaDeConversionesP = new List<Transformacion>();
            List<Transformacion> listaDeConversionesBrazo = new List<Transformacion>();

            Transformacion accion = new Transformacion("Traslacion", -20, "x", 2000, 0);
            Transformacion accion1 = new Transformacion("Traslacion", -7, "x", 1000, 2000);
            Transformacion accion11 = new Transformacion("Traslacion", -3, "x", 1000, 3000);
          

            //Transformacion accion13 = new Transformacion("Traslacion", 7, "y", 1000, 3000);

            // brazo y antebrazo
            Transformacion brazoA = new Transformacion("Rotacion", -20, "z", 1000, 4000);
            //Transformacion brazoA1 = new Transformacion("Rotacion", -30, "z", 1000, 5000);

            Transformacion antebrazoA = new Transformacion("Rotacion", 20, "z", 1000, 5000);
            //Transformacion antebrazoA1 = new Transformacion("Rotacion", 30, "z", 1000, 7000);


            //saltar
            Transformacion accion14 = new Transformacion("Traslacion", 25, "y", 1000, 4000);
            Transformacion accion17 = new Transformacion("Traslacion", -10, "x", 1000, 5000);


            //cae el balon
            Transformacion accion01P = new Transformacion("Traslacion", -7, "x", 2000, 6200);
            Transformacion accion02P = new Transformacion("Traslacion", -64, "y", 2000, 8200);
            Transformacion accion02P1 = new Transformacion("Traslacion", -20, "x", 2000, 8200);



            //pelota rebota (arriba)
            Transformacion accion03P = new Transformacion("Traslacion", 20, "y", 2000, 10200);
            Transformacion accion04P = new Transformacion("Traslacion", -20, "x", 2000, 10200);

            ///_-------------------------------------


            Transformacion patearElBalon = new Transformacion("Rotacion", -20, "z", 1000, 6000);
            Transformacion patearElBalon1 = new Transformacion("Rotacion", 20, "z", 1000, 7000);

            Transformacion patearElBalonInf = new Transformacion("Rotacion", -10, "z", 1000, 6000);
            Transformacion patearElBalonInf1 = new Transformacion("Rotacion", 10, "z", 1000, 7000);

            //
            Transformacion balanceoArriba = new Transformacion("Traslacion", 2, "y", 1000, 0);
            Transformacion balanceoAbajo = new Transformacion("Traslacion", -2, "y", 1000, 500);


            // Brazo derecho
            Transformacion rotacionBrazoDerechoAdelante = new Transformacion("Rotacion", 15, "z", 1000, 0);
            Transformacion rotacionBrazoDerechoAtras = new Transformacion("Rotacion", -15, "z", 1000, 1000);

            // Brazo izquierdo
            Transformacion rotacionBrazoIzquierdoAdelante = new Transformacion("Rotacion", 15, "z", 1000, 0);
            Transformacion rotacionBrazoIzquierdoAtras = new Transformacion("Rotacion", -15, "z", 1000, 1000);


            // Transformaciones de las piernas
            Transformacion rotacionPiernaDerechaAdelante = new Transformacion("Rotacion", -20, "z", 1000, 0);
            Transformacion rotacionPiernaDerechaAtras = new Transformacion("Rotacion", 20, "z", 1000, 2000);
            Transformacion rotacionPiernaIzquierdaAdelante = new Transformacion("Rotacion", 20, "z", 1000, 1000);
            Transformacion rotacionPiernaIzquierdaAtras = new Transformacion("Rotacion", -20, "z", 1000, 3000);


            listaDeConversiones.Add(balanceoArriba);
            listaDeConversiones.Add(balanceoAbajo);
            listaDeConversiones.Add(balanceoArriba);
            listaDeConversiones.Add(balanceoAbajo);

            listaDeConversionesBrazo.Add(rotacionBrazoDerechoAdelante);
            listaDeConversionesBrazo.Add(rotacionBrazoDerechoAtras);
            listaDeConversionesBrazo.Add(rotacionBrazoIzquierdoAdelante);
            listaDeConversionesBrazo.Add(rotacionBrazoIzquierdoAtras);
            listaDeConversionesBrazo.Add(rotacionBrazoDerechoAdelante);
            listaDeConversionesBrazo.Add(rotacionBrazoDerechoAtras);
            listaDeConversionesBrazo.Add(rotacionBrazoIzquierdoAdelante);
            listaDeConversionesBrazo.Add(rotacionBrazoIzquierdoAtras);


            listaDeConversiones.Add(accion);
            listaDeConversiones.Add(accion1);
            listaDeConversiones.Add(accion11);
            listaDeConversiones.Add(accion14); 
            listaDeConversiones.Add(accion17);
          //  listaDeConversiones.Add(accion12);


            listaDeConversionesBrazo.Add(brazoA);
            //listaDeConversionesBrazo.Add(brazoA1);
            listaDeConversionesBrazo.Add(antebrazoA);
            //listaDeConversionesBrazo.Add(antebrazoA1);


            listaDeConversionesP.Add(accion01P);
            listaDeConversionesP.Add(accion02P);
            listaDeConversionesP.Add(accion02P1);

            listaDeConversionesP.Add(accion03P);
            listaDeConversionesP.Add(accion04P);


            List<Transformacion> listaDeConversionesPiernaDerecha = new List<Transformacion>();
            listaDeConversionesPiernaDerecha.Add(rotacionPiernaDerechaAdelante);
            listaDeConversionesPiernaDerecha.Add(rotacionPiernaDerechaAtras);
            listaDeConversionesPiernaDerecha.Add(patearElBalon);
            listaDeConversionesPiernaDerecha.Add(patearElBalon1);

            List<Transformacion> listaDeConversionesPiernaInf = new List<Transformacion>();
            listaDeConversionesPiernaInf.Add(patearElBalonInf);
            listaDeConversionesPiernaInf.Add(patearElBalonInf1);


            // Para la pierna izquierda
            List<Transformacion> listaDeConversionesPiernaIzquierda = new List<Transformacion>();
            listaDeConversionesPiernaIzquierda.Add(rotacionPiernaIzquierdaAdelante);
            listaDeConversionesPiernaIzquierda.Add(rotacionPiernaIzquierdaAtras);



            Acciones acciones = new Acciones("humano", listaDeConversiones);
            Acciones acciones4 = new Acciones("balon", "pelota", listaDeConversionesP);
            Acciones acciones5 = new Acciones("humano", "brazo", listaDeConversionesBrazo);
            Acciones acciones6 = new Acciones("humano", "antebrazo", listaDeConversionesBrazo);



            //pierna
            Acciones accionesPiernaDerecha = new Acciones("humano", "pierna", listaDeConversionesPiernaDerecha);
            Acciones accionesPiernaIzquierdaInf = new Acciones("humano", "InferiorPierna", listaDeConversionesPiernaInf);
            Acciones accionesPiernaIzquierda = new Acciones("humano", "pierna1", listaDeConversionesPiernaIzquierda);
            Acciones accionesPiernaDerecha1 = new Acciones("humano", "InferiorPierna", listaDeConversionesPiernaDerecha);
            Acciones accionesPiernaIzquierda2 = new Acciones("humano", "InferiorPierna1", listaDeConversionesPiernaIzquierda);


            List<Acciones> listaDeAcciones = new List<Acciones>();
            listaDeAcciones.Add(acciones);
            listaDeAcciones.Add(acciones4);
            listaDeAcciones.Add(acciones5);
            listaDeAcciones.Add(acciones6);


            //
            listaDeAcciones.Add(accionesPiernaDerecha);
            listaDeAcciones.Add(accionesPiernaIzquierda);
            listaDeAcciones.Add(accionesPiernaDerecha1);
            listaDeAcciones.Add(accionesPiernaIzquierda2);
            listaDeAcciones.Add(accionesPiernaIzquierdaInf);


            libreto = new Libreto(listaDeAcciones, animacion);
            controlador = new Controller(libreto);
            ejecutar = new Thread(controlador.Execute);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string path = @"escenario.json"; //direccion de arcv json
            escenario = SceneSerializer.JsonStage(path);


            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-50, 50, -50, 50, -50, 50);
            GL.Enable(EnableCap.DepthTest);
            GL.Rotate(15f, 0, 1, 0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //wea de la doc

            animacion.draw();
            escenario.draw();
            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            //if (e.Key == Key.K)
            if (Keyboard.GetState().IsKeyDown(Key.K))
            {
                ejecutar.Start();
            }

           
            if (Keyboard.GetState().IsKeyDown(Key.X))
            {
                animacion.rotate("x", 1.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Y))
            {
                animacion.rotate("y", 1.8f);
            }
            if (Keyboard.GetState().IsKeyDown(Key.Q))
            {
                escenario.rotate("x", 1.8f);
            }

            if (Keyboard.GetState().IsKeyDown(Key.Number1))
            {
                animacion.scale("x", 1.05f);
            }

            //if (Keyboard.GetState().IsKeyDown(Key.Number2))
            //{
            //    cuarto.scale(1.05f);
            //}


            base.OnKeyDown(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);


            base.OnResize(e);
        }
    }
}
