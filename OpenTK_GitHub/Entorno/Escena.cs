using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace OpenTK_GitHub.Entorno
{
    internal class Escena
    {
        [JsonProperty("objects")]
        private Dictionary<string, Objeto> objetos { get; set; }
        [JsonProperty("centro")]
        public origen centro { get; set; }

        public Escena()
        {
            this.objetos = new Dictionary<string, Objeto>();
            this.centro = new origen(0, 0, 0);
        }
        public Escena(origen centro, Dictionary<string, Objeto> objetos)
        {

            this.objetos = objetos;
            this.centro = centro;
            //foreach (Objeto objeto in objetos.Values)
            //{
            //    this.objetos = new Dictionary<string, Objeto>();
            //    objeto.setSceneCentro(this.centro);
            //}
        }
        public float x
        {
            get { return this.centro.X; }
        }

        public float y
        {
            get { return this.centro.Y; }
        }

        public float z
        {
            get { return this.centro.Z; }
        }
        public origen Centro
        {
            get { return this.centro; }
            set { this.centro = value; }
        }
        public void addObjeto(String nombre, Objeto objeto)
        {
            this.objetos.Add(nombre, objeto);
        }
        public void removeObjeto(String nombre)
        {
            this.objetos.Remove(nombre);
        }
        public Objeto buscarObjeto(String nombre)
        {
            if (objetos.ContainsKey(nombre))
            {
                return objetos[nombre];
            }
            else
            {
                // Si el objeto no se encuentra, puedes retornar null o manejar la situación de otra manera.
                return null;
            }
        }

        public void draw()
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.draw(centro);
            }
        }
        public void translate(string eje, float translateValue)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.translate(eje, translateValue);
            }
        }
        public void scale(string eje, float scaleValue)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.scale(eje, scaleValue);
            }
        }
        public void rotate(string eje, float angle)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.rotate(eje, angle, this.centro);
            }
        }

        public void clear()
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.clear();
            }
        }
    }
}
