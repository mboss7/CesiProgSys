# Deliverable 1 : 

## EasySave Version 1.0 :

The software is a console application using .Net Core.

The sofware must allow the creation of up to 5 backup jobs.

A backup job is defined by :

-         A name

-         A source directory

-         A target directory

-         A type (full, differential)

The software must be usable at least by English and French users.

The user can request th execution of one of the backup jobs or the sequential execution of all the jobs.

The directories (source and target) may be on :

-         Local disks

-         External disks

-         network drives

All elements of the source directory are affected by the backup

Daily log file :

The software must write in real time in a daily log file the history of the actions of the backup jobs.

    The minimum information expected is :

-         Timestamp

-         Name of the backup job

-         Full address of the source file (UNC format)

-         Full address of the destination file (UNC format)

-         File size

-         File transfer time in ms (negative if error)

The software must record in real time, in a single file, the progress of the backup jobs.

    The information to be recorded for each backup job is :

-         Name of the backup job

-         Timestamp

-         Status of the backup job (e.g. Active, Not Active ...)


    If the job is active :

-         The total number of eligible files

-         The size of the files to be transferred

-         The progress :

        -             Number of files remaining

        -             Size of remaining  files

        -             Full address of the source file being backed up

        -             Full address of the destination file

The locations of the two files (daily log and status) will have to be studied to work on the clients' servers. Therefore, locations such as "c:\temp\" are to be avoided.

The files (daily log and status) and any configuration files will be in JSON format. To allow a fast reading via Notepad, it is necessary to put line breaks between the JSON elements. A pagination would be a plus.

## EasySave Version 1.1 :

Log format

    Logs must be in JSON and XML format.

    Allow the user to choose the format of the log file (XML or JSON).

## EasySave Version 2 :

Graphic Interface

    The application must now be developed in WPF under .Net Core.

Unlimited number of jobs

    The number of backup jobs is now unlimited.

Encryption via CryptoSoft software

    The software should be able to encrypt files using CryptoSoft software. Only files with extensions defined by the user in the general settings shall be encrypted.

Evolution of the Daily Log file

    The daily log file must contain additional information :

-     0 : pas de cryptage
-     >0 : temps de cryptage (en ms)
-     <0 : code erreur

Business software

    If the presence of business software is detected, the software must prevent a backup job from being started. In the case of sequential jobs, the software must finish the current job and stop before starting the next job. The user will be able to define the business software in the general settings of the software.

## EasySave Version 3 :

Priority file management

    No backup of a non-priority file can be made as long as there are priority files pending on at least one job. Priority files are files whose extensions are declared by the user in a predefined list (present in the general settings).

Interdiction de transférer en simultané des fichiers de plus n Ko

    In order not to overload the bandwidth, it is forbidden to transfer two files larger than n KB at the same time. (n KB can be set)

    Remark: during the transfer of a file larger than n KB, other jobs can transfer files of smaller sizes (subject to the priority file rule)

Real-time interaction with each job or all jobs

    For each backup job (or set of jobs), the user must be able to :

-     Pause (effective pause after the current file transfer)
-     Set to Play (start or resume a pause)
-     Set to Stop (immediate stop of the work and the current task)


    The user should be able to follow the progress of each job in real time (at least with a progress percentage).

Temporary pause if business software operation is detected

    Si le logiciel détecte le fonctionnement d'un logiciel métier, il doit obligatoirement mettre en pause le transfert des fichiers.

Remote console

    To enable the progress of backups to be monitored in real time on a remote workstation, a GUI must be developed that enables a user to monitor the progress of backup work on a remote workstation and also to act on it.

    The minimum specifications for this console are :

-     Design mode : WPF and FrameWork .NetCore
-     Communication via Sockets.

The application should be single-source

    The application cannot be launched more than once on the same computer.

Option: Reduction of parallel works if network load 

    Si la charge réseau est supérieure à un seuil, l'application doit réduire les taches en parallèle pour ne pas saturer le réseau.

### Table summarising the different versions in French

![Version Project](.\Image\VersionProject.png)