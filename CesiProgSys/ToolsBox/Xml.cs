using System.Data;
using CesiProgSys.Network;

namespace CesiProgSys.ToolsBox;

public class Xml
{
    public static string serialize(object obj)
    {
        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        StringWriter strWriter = new StringWriter();
        x.Serialize(strWriter, obj);

        return strWriter.ToString();
    }

    // public static Packet deserialize(string xml)
    // {        
    //     Packet temp = new Packet(); //oui je sais c'est moche raf
    //     System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(temp.GetType());
    //     StringReader strReader = new StringReader(xml);
    //     strReader.ReadToEnd();
    //     return (Packet)x.Deserialize(strReader);
    // }
}