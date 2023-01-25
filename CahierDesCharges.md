﻿# Livrable 1 : :

## Le cahier des charges de la première version du logiciel est le suivant :

    Le logiciel est une application Console utilisant .Net Core.

    Le logiciel doit permettre de créer jusqu'à 5 travaux de sauvegarde

    Un travail de sauvegarde est défini par :

-         Une appellation

-         Un répertoire source

-         Un répertoire cible

-         Un type (complet, différentiel)

    Le logiciel doit être utilisable à minima par des utilisateurs anglophones et Francophones

    L'utilisateur peut demander l'exécution d'un des travaux de sauvegarde ou l'exécution séquentielle de l'ensemble des travaux.

    Les répertoires (sources et cibles) pourront être sur :

-         Des disques locaux

-         Des disques Externes

-         Des Lecteurs réseaux

    Tous les éléments du répertoire source sont concernés par la sauvegarde

    Fichier Log journalier :

    Le logiciel doit écrire en temps réel dans un fichier log journalier l'historique des actions des travaux de sauvegarde. Les informations minimales attendues sont :

-         Horodatage

-         Appellation du travail de sauvegarde

-         Adresse complète du fichier Source (format UNC)

-         Adresse complète du fichier de destination (format UNC)

-         Taille du fichier

-         Temps de transfert du fichier en ms (négatif si erreur)

-         Exemple de contenu: Sample_log.pdf [pdf]

    Le logiciel doit enregistrer en temps réel, dans un fichier unique, l'état d'avancement des travaux de sauvegarde. Les informations à enregistrer pour chaque travail de sauvegarde sont :

-         Appellation du travail de sauvegarde

-         Horodatage

        Etat du travail de Sauvegarde (ex : Actif, Non Actif...)

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