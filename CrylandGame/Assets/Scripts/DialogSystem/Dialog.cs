using System;
using System.Xml.Serialization;

namespace DialogSystem
{
    public class Dialog
    {
        [XmlElement("phrase")]
        public  String Phrase { get; set; }
        
        [XmlElement("answer")]
        public  String Answer { get; set; }
    }
}