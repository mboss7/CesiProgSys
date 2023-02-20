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

    Si le travail est actif :

-         Le nombre total de fichiers éligibles

-         La taille des fichiers à transférer

-         La progression :

        -             Nombre de fichiers restants

        -             Taille des fichiers restants

        -             Adresse complète du fichier Source en cours de sauvegarde

        -             Adresse complète du fichier de destination

        -         exemple de contenu : Sample_state.pdf [pdf]

    Les emplacements des deux fichiers (log journalier et état) devront être étudiés pour fonctionner sur les serveurs des clients. De ce fait, les emplacements du type « c:\temp\ » sont à proscrire.

    Les fichiers (log journalier et état) et les éventuels fichiers de configuration seront au format JSON. Pour permettre une lecture rapide via Notepad, il est nécessaire de mettre des retours à la ligne entre les éléments JSON. Une pagination serait un plus.

Remarque importante : si le logiciel donne satisfaction, la direction vous demandera de développer une version 2.0 utilisant une interface graphique WPF (basée sur l'architecture MVVM)