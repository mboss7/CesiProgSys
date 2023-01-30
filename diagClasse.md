```mermaid
classDiagram

class Program{
    +main()
}

class IViewCli{
    

    +startProgram()
    +menu()
    +help()
    +read(): String
    +showConfig()
}

class ViewCliFr{
    +startProgram()
    +menu()
    +help()
    +read() : String
    +showConfig()
}

class ViewCliEn{
    +startProgram()
    +menu()
    +help()
    +read() : String
    +showConfig()
}

class ViewModelCli{
    -inputUser : String
    -commands: List<Tuple<string, delegate>>
    
    
}

class IManager{
    
}

class

class IBackup{
+startThread()
}

class FullBackup{
+startThread()
}

class DifferentialBackup{
+startThread()
}

class IncrementialBackup{
+startThread()
}

class SevenZip{

}

class Config{

}

class ILogs{

}

class DailyLogs{

}

class RealTimeLogs{

}
>>>>>>> 9e630b562fc450dfff83ecca5df2035cb2c221ed

class Hash{
    +generate(string uri) : String
    +compare(string hashSource, string hashDestination) : Bool
}

class Json{
    +serialize
}


```

Class manager
-> class backup abstraite (plusieurs threads, géré par manager) -> nom, répertoire source et cible
    -> backup_complet
    -> backup_différentiel
    -> backup_incrémentiel

-> class 7zip proposer à l'utilisateur de compresser ou non

translate :  2 vues, une française, une anglaise (tableau de delegate pour la lecture des commandes)

class config : sauvegarde la langue, un mode de detection des extensions des fichiers, sauvegarde par défaut, sauvegarde récente

class LOG abstraite : (format json, et eviter les emplacements de type temp)
    log journalier -> horodatage, nom, adresse unc source et destination, taille du fichier, temps de transfert final (negatif si erreur)
    log temps réel -> etat d'avancement des travaux de sauvegarde, nom horodatage, (si actif, nombre total de fichiers, taille des fichiers, progressions ..)


