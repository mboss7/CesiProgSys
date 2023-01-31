﻿```mermaid
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
+redirect()
}
class IManager{
-threadList : List<Thread>
+instantiate()
+finish() : Bool ?
}
class BackupManager{
-threadList : List<Thread>
+instantiate()
+finish() : Bool ?
}
class LogsManager{
-threadList : List<Thread>
+instantiate()
+finish() : Bool ?
}
class IBackup{
-name : String
-SaveSource : String
-SaveTarget : String
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
+zip()
+unzip()
}
class Config{
-language : Enum
-defaultSaveSource : String
-defaultSaveTarget : String
-recentSaveSource : HashMap<String>
-recentSaveTarget : HashMap<String>
-retentionTime : Int
+writeConfig()
+readConfig()
+cleanConfig
}
class Languages{
<<enumeration>>
-FR : 0
-EN : 1
}
class ILogs{
+startThread()
+startLog()
+logInfo()
+logError()
}
class DailyLogs{
+startThread()
+startLog()
+logInfo()
+logError()
}
class RealTimeLogs{
+startThread()
+startLog()
+logInfo()
+logError()
}
class Hash{
+generate(string uri) : String
+compare(string hashSource, string hashDestination) : Bool
}
class Json{
+serialize(object obj) : String
+deserialize(String json) : Object
}

IViewCli <|.. ViewCliFr
IViewCli <|.. ViewCliEn
IManager <|.. BackupManager
IManager <|.. LogsManager
IBackup <|.. FullBackup
IBackup <|.. DifferentialBackup
IBackup <|.. IncrementialBackup
ILogs <|.. DailyLogs
ILogs <|.. RealTimeLogs
Program *-- IManager
Program *-- IViewCli
Program *-- ViewModelCli
BackupManager *-- IBackup
LogsManager *-- ILogs
IViewCli <--> ViewModelCli
IBackup <--> ViewModelCli
Config <--> ViewModelCli
Config <-- IBackup
DailyLogs .. Languages
RealTimeLogs .. Languages
Config .. Languages

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


