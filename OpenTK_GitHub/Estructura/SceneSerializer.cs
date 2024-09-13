using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using OpenTK_GitHub.Entorno;

namespace OpenTK_GitHub.Estructura
{
     class SceneSerializer
    {
        public static void SaveStage(string nombreArchivo, stage escenario)
        {
            string json = JsonConvert.SerializeObject(escenario);
            File.WriteAllText(nombreArchivo, json);
        }

        public static stage JsonStage(string fileName)
        {
            string json = File.ReadAllText(fileName);
            stage escenario = JsonConvert.DeserializeObject<stage>(json);

            //-------
            if (escenario == null || escenario.ConjObjects.Count == 0)
            {
                Console.WriteLine("Error: El escenario no se cargó correctamente o está vacío.");
                return escenario;
            }
            else
            {
                Console.WriteLine("Escenario cargado correctamente con " + escenario.ConjObjects.Count + " objetos.");
                return escenario;
            }
        }
    }
}
