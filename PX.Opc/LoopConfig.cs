using System.Xml.Serialization;

namespace PX.Opc
{
    [XmlRoot("loop_config")]
    public class LoopConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("sleep_duration")]
        public int SleepDuration { get; set; }

        public LoopConfig() : this(default, default) { }

        public LoopConfig(string name, int sleepDuration)
        {
            Name = name;
            SleepDuration = sleepDuration;
        }
    }
}
