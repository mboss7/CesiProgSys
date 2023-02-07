Main Menu of the CLI
```mermaid
sequenceDiagram
Actor User
User->>View: Select parameter
View -->>User: Show Menu
```
Create a Backup
```mermaid
sequenceDiagram
Actor User
View -->>User: Show Backup creation Menu
User ->>View: Enter selected Menu (Number)
View ->>ViewModel: Send Variable values
ViewModel -->>View: Send reply 
ViewModel ->>Model: Write changes
Model -->>ViewModel: Send reply
```

Editing a Backup
```mermaid
sequenceDiagram
Actor User
View -->>User: Enter Variable Values
User ->>View: Show Backup editing Menu
View ->>ViewModel: Send Variable values
ViewModel -->>View: Send reply 
ViewModel ->>Model: Write changes
Model -->>ViewModel: Send reply
View -->>User: Send reply
View -->>User: Show Main Menu
```

Deleting a Backup
```mermaid
sequenceDiagram
Actor User
View -->>User: Enter Variable Values
User ->>View: Show Backup editing Menu
View ->>ViewModel: Send Variable values
ViewModel -->>View: Send reply 
ViewModel ->>Model: Write changes
Model -->>ViewModel: Send reply
View -->>User: Send reply
View -->>User: Show Main Menu
```