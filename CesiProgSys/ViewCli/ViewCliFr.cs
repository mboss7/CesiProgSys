using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli;

public class ViewCliFr : ViewCli
{
    public ViewCliFr()
    {
        vmCLI = new ViewModelCli();

        dico = new Dictionary<string, string>()
        {
            {
                "textMenu",
                "1. Configurer une sauvegarde\n2. Lancer une sauvegarde\n3. Afficher les configurations\n4. Changer les configurations\n5. Aide\n6. Quitter"
            },
            { "textConfigBackup", "1. Sauvegarde complète\n2. Sauvegarde différentielle\n3. Retour\n4. Quitter" },
            { "textStartBackup", "1. Validation du lancement d'une sauvegarde\n2. Retour\n3. Quitter" },
            {"textSource", "1. Utiliser la source par défaut\n2. Utiliser une source récente\nSinon écrire le chemin de la source :"},
            {"textTarget", "1. Utiliser la cible par défaut\n2. Utiliser une cible récente\nSinon écrire le chemin de la cible :"},
            { "textShowConfig", "1. Validation de l'affichage des configurations\n2. Retour\n3. Quitter" },
            {
                "textChangeConfig",
                "1. Changer la langue\n2. Changer la source par défaut de sauvegarde\n3. Changer la cible par défaut de sauvegarde\n4. Reset la config\n5. Changer le temps de rétention\n6. Retour\n7. Quitter"
            },
            {
                "textHelp",
                " .----------------.\n" +
                "| .--------------. |\n" +
                "| |    ______    | |\n" +
                "| |   / _ __ `.  | |\n" +
                "| |  |_/____) |  | |\n" +
                "| |    /  ___.'  | |\n" +
                "| |    |_|       | |\n" +
                "| |    (_)       | |\n" +
                "| |              | |\n" +
                "| '--------------' |\n" +
                "'----------------' \n" +
                "Pour configurer une sauvegarde complète : Taper 1. Puis 1..\nPour configurer une sauvegarde différentielle : Taper 1. Puis 2.\nPour lancer une sauvegarde : Taper 2. Puis 1.\n" +
                "Pour afficher les configurations : Taper 3. Puis 1.\nPour changer la langue : Taper 4. Puis 1. Puis 1.\nPour modifier la source des sauvegardes par défaut : Taper 4. Puis 2. Puis 1.\n" +
                "Pour nettoyer la source des sauvegardes par défaut : Taper 4. Puis 2. Puis 2.\nPour modifier la cible des sauvegardes par défaut : Taper 4. Puis 3. Puis 1.\nPour nettoyer la cible des sauvegardes par défaut : Taper 4. Puis 3. Puis 2." +
                "Pour nettoyer la source récente des sauvegardes : Taper 4. Puis 4. Puis 1.\nPour nettoyer la cible récente des sauvegardes : Taper 4. Puis 5. Puis 1.\nPour modifier le temps de conservation : Taper 4. Puis 6. Puis 1." +
                "Pour nettoyer entièrement les configurations : Taper 4. Puis 7. Puis 1. \n1. Retour\n2. Quitter"
            },
            { "textChooseLanguage", "1. Choisir Français\n2. Choisir Anglais\n3. Retour\n4. Quitter" },
            { "textChooseNameFullBackup", "Choisissez un nom pour votre backup complète:" },
            { "textChooseNameDiffBackup", "Choisissez un nom pour votre backup différentiel :" },
            {
                "textShowContentConfig",
                "Language: {0}\nDefault save source: {1}\nDefault save target: {2}\nRecent save source: {3}\nRecent save target: {4}\nRetention time: {5}\nType of logs: {6}"
            },
            { "textChangeLanguage", "Vous devez redemmarer pour voir les changements" },
            { "textChangeDefaultSaveSource", "Donnez un chemin pour la source de la nouvelle sauvegarde par défaut" },
            { "textChangeDefaultSaveTarget", "Donnez un chemin pour la cible de la nouvelle sauvegarde par défaut" },
            { "textRetentionTime", "Donnez un nouveau temps de conservation (en jours)" },
            { "askChoice", "Entrez votre choix: " },
            { "exit", "Fermeture du programme..." },
            { "invalid", "Choix invalide. Veuillez reessayer" }
        };
    }
}