# CesiProgSys


# Project Expectations 

## Delivrable 1 : 

# Structures and Uses:

To detect file modifications: hash comparison (md5 for speed)

Creation of a console application followed by the implementation of a remote interface via tcp.

Demonstrate progress.

Think about a version that works on Windows and Linux.

![image](https://user-images.githubusercontent.com/102410364/214019216-da5dd7c5-df74-4353-9773-92c86f4ed934.png)



[![](https://mermaid.ink/img/pako:eNpNUctKxEAQ_JVmvC5-QG6yCyq4IAT0kks700ka5uU8VmXZf_G635Efs-PqJs0cBqqqq2rmqHQwpBrl2BuHsfOdB5m7GKHFeqABkyHY3oAJxVMBHRJdKPO8UMocPJj6jyOY6dyz57SwXLWFy5gIzUo6nRP3rLH8LqAMD5hHiKEmOFwwSuCCuZLyIn4OOfMbWy7TWbSgR_SD0C3K8UNdRdyK7Z8F2DCslkhHy0AetvsdaMt6gfZzYogWC_UhOWjgiX39BCn4Kg8VPvItLOyW_JJm-p5TaMyZVpR7ytee2s7gKsijL5R61ARDwjjye6U5ViIXCkHRURapjXKUHLKRzzrO2k6VkRx1qpGroR4lc6c6fxIq1hLaL69VU1KljarRSJUdoxg41fRoM51-AL1ZqN0?type=png)](https://mermaid.live/edit#pako:eNpNUctKxEAQ_JVmvC5-QG6yCyq4IAT0kks700ka5uU8VmXZf_G635Efs-PqJs0cBqqqq2rmqHQwpBrl2BuHsfOdB5m7GKHFeqABkyHY3oAJxVMBHRJdKPO8UMocPJj6jyOY6dyz57SwXLWFy5gIzUo6nRP3rLH8LqAMD5hHiKEmOFwwSuCCuZLyIn4OOfMbWy7TWbSgR_SD0C3K8UNdRdyK7Z8F2DCslkhHy0AetvsdaMt6gfZzYogWC_UhOWjgiX39BCn4Kg8VPvItLOyW_JJm-p5TaMyZVpR7ytee2s7gKsijL5R61ARDwjjye6U5ViIXCkHRURapjXKUHLKRzzrO2k6VkRx1qpGroR4lc6c6fxIq1hLaL69VU1KljarRSJUdoxg41fRoM51-AL1ZqN0)


C# .NET Core Backup App
.NET version to be defined
Multithreaded
Hash verification to check modifications
Ability to change language
Log creation
Command line application 
Multi-platform: Linux and Windows
Case sensitivity
Class management
Remote TCP graphical interface

Example of how the project works:
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

