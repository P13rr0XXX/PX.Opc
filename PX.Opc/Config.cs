using System.Xml.Serialization;

namespace PX.Opc
{
    [XmlRoot("config")]
    public class Config
    {
        [XmlElement("opc_server")]
        public OpcServerConfig OpcServerConfig { get; set; }

        public Config()
        {
            this.OpcServerConfig = new OpcServerConfig();
        }
    }
}
