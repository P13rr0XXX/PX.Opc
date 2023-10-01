using System.IO;
using System.Xml.Serialization;

namespace PX.Opc
{
    public static class Xml
    {
        public static T Deserilize<T>(string path) where T : class
        {
            T o;
            using (StreamReader stream = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                o = (T)serializer.Deserialize(stream);
            }
            return o;
        }

        public static void Serialize<T>(string path, T o) where T : class
        {
            using (StreamWriter stream = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(stream, o);
            }
        }
    }
}
