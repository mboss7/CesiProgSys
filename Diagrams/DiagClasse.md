 ```mermaid
classDiagram

class Backup{

    #SendPacket( string ty, int pr, State st)
    +backup()
    +startCheckAuthorizations()
    +checkAuthorizations(string directory)
    -bool checkRights(FileSystemAccessRule rule)
    -bool checkTypes(FileAttributes toCheck)
}
 
 class BackupManager{

     BackupManager()
     BackupManager Instance()
     +List<Backup> listBackupCheckingAuth;
     +List<Backup> listBackupReady;
     +List<Backup> listBackupStarted;
     +List<Backup> listBackupStoped;
     +Backup instantiate(string name, string source, string target, bool type)
     startBackup(Backup b)
     startThread(object obj)
 }
 
 class DifferentialBackup{

     DifferentialBackup(string name, string source, string target)
     backup()
 }
 class FullBackup{
     public FullBackup(string name, string source, string target)
     public override void backup()
 }
class DailyLogs{
    private DailyLogs()
    private void setPath()
    public override void writeLogs()
    
}
class Logs{
    public void startLog()
    protected void log(List<string> toPrint, string path)
    public abstract void writeLogs();
    
} 
class LogsManager{
    private LogsManager()
    public static LogsManager Instance()
    public void instantiate()
    public void finish()
    private static void startThread(object obj)
}
class RealTimeLogs{

    private readonly Logs dlInstance;
    private RealTimeLogs()
    public static RealTimeLogs Instance()
    public override void writeLogs()
    
}

class Packet{
    public int id;
}
class PacketChangeConfigs{
    public PacketChangeConfigs()
}
class PacketConfigBackup{
    public PacketConfigBackup()
}
class PacketConfigs{
    public PacketConfigs()
}
class PacketControlBackup{
    public PacketControlBackup()
}
class PacketStateBackup{
    public PacketStateBackup()
}
class Client{
    public static void startClient(object obj)
    private static Socket Connect(string ip)
    private static void SendNetwork(Socket client)
}
class NetworkHandler{
    private BackupManager bManager;
    private List<Backup> backups;
    private Config config;
    public ManualResetEventSlim wait = new(true);
    private NetworkHandler()
    private static NetworkHandler instance;
    public static NetworkHandler Instance()
    public static void threadNetworkHandler()
    public void instantiateBackup(string name, string sourceDir, string targetDir, bool type)
    public void startBackup(string name)
    public void stopBackup(string name)
    public void restartBackup(string name)
    public void killBackup(string name)
    public void changeLanguage(Language l)
    public void changeDefaultSaveSource(string s)
    public void changeDefaultSaveTarget(string s)
    public void resetConfig()
    public void changeTypeLogs(string s)
}
class Server{
    public static ConcurrentQueue<Packet> packets = new();
    public static void startServer()
    private static Socket Connect()
    private static Socket Accept(Socket socket)
    private static void createClient(Socket client)
    private static void ListenNetwork(Socket client)
}
class TcpClientSsl{
    public static void RunClient(object objIpPort)
    public async Task SslTcpClientConnection(string ipAddress, int port)
    static string ReadMessage(SslStream sslStream)
}
class TcpServer{
    public static bool isRunning = false;
    public SslStream sslStream;
    public static void RunSrv(object obj)
    public SslStream SslTcpServerConnection(int port)
    static string ReadMessage(SslStream sslStream)
}
class ThreadForTcp{
    public void ClientTcpThreadRun(string[] IpPort)
    public void ServerTcpThreadRun(string[] IpPort)
}
class Config{
    private Config()
    private static Config instance;
    public static Config Instance()
    public void writeConfig()
    public void setConfig()
    public void resetConfig()
    public void addToSet(string toAdd, HashSet<string> hashSet)
    public void checkTimeRecentSave()
    public void SendConfig()
    
}
class Hash{
    public Hash()
    public string HashFileGenerator(string pathFileToHash)
    public string HashTextGenerator(string SourceHash)
    public bool HashComparator(string hash1, string hash2)
}
 class Info{
     public string typeBackup;
     private TimeSpan _timeLaps;
     public TimeSpan TimeLaps
     private string _sourceDir;
     public string SourceDir
     private string _destDir;
     public string DestDir
     private string _currentSource;
     public string CurrentSource
     private string _currentDest;
     public string CurrentDest
     private DateTime _date;
     public DateTime Date
     private string _name;
     public string Name
     private int _totalFilesToCopy;
     public int TotalFilesToCopy
     private long _totalFilesSize;
     public long TotalFilesSize
     private int _nbFilesLeftToDo;
     public int NbFilesLeftToDo
     private State _state;
     public int Progression
     private State _state;
     public State State
     public event PropertyChangedEventHandler? PropertyChanged
     private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
     
}
class Json{
    public static string objectToJson(object obj)
    public static Config? JsonToConfig(string json)
    public static Packet JsonToPacket(string json)
}
class Language{
    public enum Language
}
class State{
    public enum State
}
class Xml{
    public static string serialize(object obj)
}
class Zip{
public Zip()
public void compressed(string location, string file)
}
class ViewCliEn{
    public ViewCliEn()
}
class ViewCliFr {
    public ViewCliFr()
}
class ViewCli{

    protected ViewModelCli vmCLI;
    protected Dictionary<string, string> dico;
    private int askNumber()
    public void menu()
    private void configBackup()
    private void startBackup()
    private void showConfig()
    private void changeConfig()
    private void help()
    private void chooseLanguage()
    private void changeTypeLogs()
    private void defaultSaveSource()
    private void defaultSaveTarget()
    private void retentionTime()
    private void resetConfig()
    private string getRecentSource()
    private string getRecentTarget()
    private void fullBackup()
    private void diffBackup()
    private void startBackupValid()
    private void leave()
}
class ViewModelCli{
    private BackupManager bManager;
    private List<Backup> backups;
    private Config config;
    public ViewModelCli()
    public void instantiateBackup(strinag name, string sourceDir, string targetDir, bool type)
    public List<string[]> getBackups()
    public void startBackup(string name)
    public void stopBackup(string name)
    public void restartBackup(string name)
    public void killBackup(string name)
    public void writeConfig()
    public string[] getConfig()
    public void changeLanguage(Language l)
    public void changeDefaultSaveSource(string s)
    public void changeDefaultSaveTarget(string s)
    public void resetConfig()
    public void changeRetentionTime(int i)
    public string getDefaultSource()
    public string getDefaultTarget()
    public string[] getRecentSource()
    public string[] getRecentTarget()
    public void changeTypeLogs(string s)
}
class Program{
    public static bool cli = true;
     static void Main(string[] args)
}
        




```
//TODO update le diag classe pour inclure le fait que la ckasse realtimelogs doit recupérer les infos depuis les classes de backup, puis une fois la backup fini transmettre les infos à la classe dailylogs
//TODO Le backup manager doit aussi recup des infos depuis le viewmodelCli, pour savoir cb de threads il doit créer notamment
//TODO ou peux etre pas ;.. je sais pas
//Todo IBackup ne doit pas communiquer avec Config ? enfin je pense

Class manager
-> class backup abstraite (plusieurs threads, géré par manager) -> nom, répertoire source et cible
    -> backup_complet
    -> backup_différentiel
    -> backup_incrémentiel

-> class 7zip proposer à l'utilisateur de compresser ou non

translate :  2 vues, une française, une anglaise (tableau de delegate pour la lecture des commandes)

class config : sauvegarde la langue, un mode de detection des extensions des fichiers, sauvegarde par défaut, sauvegarde récente

class LOG abstraite : (format json, et eviter les emplacements de type temp)
    log journalier -> horodatage, nom, adresse unc source et destination, taille du fichier, temps de transfert final (negatif si erreur)
    log temps réel -> etat d'avancement des travaux de sauvegarde, nom horodatage, (si actif, nombre total de fichiers, taille des fichiers, progressions ..)


