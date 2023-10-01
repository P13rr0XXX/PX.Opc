using System.Collections.Generic;
using System.Xml.Serialization;

namespace PX.Opc
{
    [XmlRoot("opc_server")]
    public class OpcServerConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("node")]
        public string Node { get; set; }
        [XmlArray("opc_groups"),XmlArrayItem("opc_group")]
        public List<OpcGroupConfig> OpcGroupConfigs { get; set; }

        public OpcServerConfig()
        {
            this.Name = default;
            this.OpcGroupConfigs = new List<OpcGroupConfig>();
        }
    }
}
