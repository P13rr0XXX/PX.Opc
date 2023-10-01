using System.Collections.Generic;
using System.Xml.Serialization;

namespace PX.Opc
{
    [XmlRoot("opc_group")]
    public class OpcGroupConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray("opc_items"),XmlArrayItem("opc_item")]
        public List<OpcItemConfig> OpcItemConfigs { get; set; }
        
        public OpcGroupConfig()
        {
            this.Name = default;
            this.OpcItemConfigs = new List<OpcItemConfig>();
        }
    }
}
