using System.Xml.Serialization;

namespace PX.Opc
{
    [XmlRoot("opc_item")]
    public class OpcItemConfig
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("handle")]
        public int Handle { get; set; }

        public OpcItemConfig(): this(default, default) { }

        public OpcItemConfig(string id, int handle)
        {
            this.Id = id;
            this.Handle = handle;
        }
    }
}
