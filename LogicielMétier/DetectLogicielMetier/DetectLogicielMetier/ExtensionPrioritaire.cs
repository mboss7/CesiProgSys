﻿
using System;
using System.Collections.Generic;

namespace DetectLogicielMetier
{
    public class ExtensionPrioritaire
    {
    // list tuple  qui contient  string / liste file info 
    private List<string> ListeAvantTri;

    private List<string> fichiersPrioritaires;

    public void ListeMaker()
    {

        // Créer une liste 
        List<string> ListeAvantTri = new List<string>();
        List<string> fichiersPrioritaires = new List<string>();

        // Ajouter des éléments à la liste 
        ListeAvantTri.Add("Java.exe");
        ListeAvantTri.Add("Python.txt");
        ListeAvantTri.Add("C#.lol");
        ListeAvantTri.Add("PHP.xd");
        ListeAvantTri.Add("C++.exe");
        ListeAvantTri.Add("SQL.txt");

    }

    public void ListeTri()
            {
                Console.WriteLine("\nParcourir la liste avec la boucle for-each. \n");
                foreach(string item in ListeAvantTri) {
                    if (item.Contains(".txt"))
                    {
                    
                        fichiersPrioritaires.Add(item);
                    
                    }
                }
            }

    public void ListReader()
    {
           
            
        Console.WriteLine("\nParcourir la liste element prioritaires avec la boucle for-each:\n ");
        foreach(string item in fichiersPrioritaires) {
            Console.WriteLine(item);
        }
    }

         
    }
    }


