# Diagramme de Class : 


```mermaid
classDiagram
class Backup
Backup : +string name
Backup : +string source
Backup : +string destination
Backup : +string type

    class BckLocation
    BckLocation : +string storageName
    BckLocation : +string storageType
    BckLocation : +string storagePath


    class Logs
    Logs : +string Horodatage
    Logs : +string Backup.name
    Logs : +string Source.path
    Logs : +string Destination.path
    Logs : +string File.size
    Logs : +string File.Transfert.time
```
    

# Diagram de class simplifié : 
 ```mermaid    
 classDiagram
     class BckApp
     BckApp <|-- BckAppInterface_Model
     BckAppInterface_Model <|-- CLI_View_Model
     CLI_View_Model <|-- CLI_View
    
    
    
    
    
    
    
```

modif 