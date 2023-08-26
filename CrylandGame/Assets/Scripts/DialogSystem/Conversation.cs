using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogSystem
{
    [XmlRoot("conversation")]
    public class Conversation
    {
        
        [XmlElement("day")]
        public  int Day { get; set; }
        
        [XmlArray("dialogs")]
        [XmlArrayItem("dialog")]
        public  List<Dialog> Dialogs { get; set; }
    }
}