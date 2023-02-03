

 using System;
 using Newtonsoft.Json;
 using System.IO;
 using System.Xml;
 using Formatting = Newtonsoft.Json.Formatting;

 namespace CesiProgSys.ToolsBox
 {
     public class Jsoncreator
     {
         static void Jsoncreator(string[] args)
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


 }