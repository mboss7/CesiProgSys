# CesiProgSys

## Project title : EasySave

## Project description : 

The team has to develop a backup software called EasySave for the software publisher ProSoft. The software will be sold at 200 € HT with an annual maintenance contract at 12% of the purchase price. The team must respect constraints concerning the development tools and methods, the language used, the readability of the code and the user documentation. The project must also be managed in such a way as to reduce the development costs of future versions and to guarantee rapid reactivity in the event of a malfunction.

## Authors

- @Jxstine2002
- @mboss7
- @TanguyGackel
- @Louis410

## Terms of reference :

[Terms of reference](TermsOfReference.md)

## Documentation

[Deliverable_L1_Documentation](Deliverable_L1_Documentation.docx)

## UML diagrams

Project organisation

[Gantt](.\Diagrams\Gantt.md)

System analysis

[Use case diagram](.\Diagrams\DiagUseCase.md)

System presentation

- [Class diagram](.\Diagrams\DiagClasse.md)
- [Sequence diagram](.\Diagrams\DiagSequences)
- [Activity diagram](.\Diagrams\DiagActivity.md)


## Branch organization :
```mermaid
gitGraph
    commit
    branch dev
    checkout dev
    branch features1
    checkout features1
    branch features2
    checkout features2
    commit
    commit
    checkout features1
    commit
    commit
    checkout dev
    merge features1 tag:"Beta v0.1.0"
    checkout features1
    commit
    commit
    checkout features2
    commit
    commit
    checkout dev
    merge features2 tag:"Beta v0.2.0"
    checkout main
    merge dev tag:"v1.0.0"
    checkout dev
    merge features1 tag:"Beta v1.1.0"
    checkout main
    merge dev tag:"v1.1.0"
    commit type: REVERSE
    branch debug
    checkout debug
    commit type: HIGHLIGHT
    commit type: HIGHLIGHT
    checkout dev
    merge debug tag:"Beta 1.1.1"
    checkout main
    merge dev tag:"v1.1.1"
```

## Subject with constraints :

```
Version 1.0

Deliverable 0 description: Work environment
Your team must plan a work environment that meets the constraints imposed by ProSoft.

The proper use of the work environment and the constraints imposed by management will be evaluated throughout the project.

Particular attention will be paid to:

GIT management (versioning)

UML diagrams to be delivered 24 hours before each deliverable (Milestone)

Code quality (absence of redundancy in code lines)

Deliverable 1 description: EasySave version 1.0
The specifications for the first version of the software are as follows:

The software is a Console application using .Net Core.

The software must allow up to 5 backup jobs to be created

A backup job is defined by

An appellation

A source directory

A target directory

A type (full, differential)

The software must be usable by English and French-speaking users at a minimum

The user can request the execution of one of the backup jobs or the sequential execution of all the jobs.

The directories (sources and targets) can be on:

Local drives

External drives

Network drives

All elements in the source directory are subject to backup

Daily Log file:

The software must write in real-time to a daily log file the history of the backup jobs' actions. The minimum information expected is:

Timestamp

Backup job name

Complete source file address (UNC format)

Complete destination file address (UNC format)

File size

File transfer time in ms (negative if error)

Example content: Sample_log.pdf [pdf]

The software must record in real-time, in a single file, the status of the backup jobs. The information to be recorded for each backup job is:

Backup job name

Timestamp

Backup job status (e.g., Active, Non-active...)

If the job is active:

Total number of eligible files

Size of files to transfer

Progress

Number of remaining files

Size of remaining files

Complete source file address being backed up

Complete destination file address

Example content: Sample_state.pdf [pdf]

The locations of the two files (daily log and status) must be studied to work on the clients' servers. Therefore, locations of the type "c:\temp" must be avoided.

The files (daily log and status) and any configuration files will be in JSON format. To allow quick reading via Notepad, it is necessary to put line breaks between JSON elements. Pagination would be a plus.

Important note: if the software is satisfactory, management will ask you to develop a version 2.0 using a WPF graphical interface (based on the MVVM architecture).
 ```

