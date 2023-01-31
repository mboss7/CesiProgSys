# Diagram sequence Logs :

```mermaid
sequenceDiagram
    LogsManager->>ILogs : initiate thread
    ILogs->>DailyLogs : initiate thread write update logs 
    ILogs->>RealTimeLogs : initiate thread write real time logs 
    LogsManager->>ILogs : finish thread
    ILogs->>DailyLogs : finish thread write update logs 
    ILogs->>RealTimeLogs : finish thread write real time logs 
```