namespace Tcp_Ssl;

public class ConditionIHM
{
    public void IHMServer(string EntreeUtilisateurClient)
    {
        switch (EntreeUtilisateurClient)
        {
            case "1":
                break;
            case "2":
                break;
            default:
                Console.WriteLine("Command unknow !");
                break;
        }
        
    }
}