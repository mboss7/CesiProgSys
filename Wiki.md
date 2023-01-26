# Wiki 


## Library :

http://dev-dot.net/6-classes-system-io/








# MVVM 


Model ->  backup / log (Real time / Daylie /drive 


View -> CLI

View - Model ->


Design patern Mediator.


Eviter relations fortes !  


```mermaid 

classDiagram 
    class CLI
    CLI <|-- CLI_VM
    CLI_VM <|--PROGRAM
    PROGRAM <|-- Manager
    Manager <|-- Backup    
    Backup  <|-- Interface Log
    Backup  <|-- Interface Drive
    Interface Log  <|--  Log    
    Interface Drive <|-- Drive 





```