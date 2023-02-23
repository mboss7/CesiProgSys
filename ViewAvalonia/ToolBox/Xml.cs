using ViewAvalonia.Network;

namespace ViewAvalonia.ToolBox;

public class Xml
{
    public static string serialize(object obj)
    {
        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        StringWriter strWriter = new StringWriter();
        x.Serialize(strWriter, obj);

        return strWriter.ToString();
    }

    // public static object deserialize(string xml)
    // {
    //     System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer();
    //     StringReader strReader = new StringReader(xml);
    //     strReader.ReadToEnd();
    //     return (Packet)x.Deserialize(strReader);
    // }
}