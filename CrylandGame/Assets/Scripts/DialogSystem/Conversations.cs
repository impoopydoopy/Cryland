using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogSystem
{
    [XmlRoot("conversations")]
    public class Conversations
    {
        [XmlElement("conversation")] 
        public List<Conversation> ConversationList { get; set; }
    }
}