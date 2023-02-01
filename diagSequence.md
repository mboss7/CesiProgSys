# FullBackup sequence diagram
```mermaid
sequenceDiagram
    participant BackupManager
    participant IBackup
    participant ViewModelCli
    participant Config
    participant FullBackup
    participant Hash
    participant SevenZip
    
    Note left of BackupManager : create a thread
    BackupManager ->> IBackup : startThread
    
    
```