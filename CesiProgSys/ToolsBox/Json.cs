

using System;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace CesiProgSys.ToolsBox
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lire le fichier texte
            string text = File.ReadAllText("input.txt");

            // Convertir le fichier texte en objet
            object obj = JsonConvert.DeserializeObject(text);

            // Écrire le fichier JSON
            File.WriteAllText("output.json", JsonConvert.SerializeObject(obj, Formatting.Indented));

            Console.WriteLine("Conversion terminée avec succès.");
        }
    }

    internal class JsonConvert
    {
        public static object DeserializeObject(string text)
        {
            throw new
                NotImplementedException();
        }

        public static string? SerializeObject(object o, object indented)
        {
            throw new NotImplementedException();
        }
    }
}
