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

    // public static object deserialize(string xml)
    // {
    //     return;
    // }
}