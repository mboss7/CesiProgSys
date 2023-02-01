```mermaid

sequenceDiagram
JsonConverter->>Text : read file .txt
Text->> Json : converting .txt to Json
Json->> Jsonfile : write Json file
Jsonfile->>JsonConverter : console write finish
```
