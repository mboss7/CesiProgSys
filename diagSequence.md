```mermaid
sequenceDiagram
    participant Program
    participant IManager
    participant BackupManager
    participant IBackup
    participant ViewModelCli
    participant Config
    participant FullBackup
    participant DifferentialBackup
    participant Hash
    participant SevenZip
    
    Program ->> IManager: Instantiate()
    IManager -->> BackupManager: Instantiate()
```