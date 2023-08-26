using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using DialogSystem;

namespace NPC
{
    public class Character : MonoBehaviour
    {

        public TextAsset DialogXML;
        public Conversations conversations;

        void Awake()
        {
            string xmlString = DialogXML.text;
            XmlSerializer serializer = new XmlSerializer(typeof(Conversations));

            using (StringReader reader = new StringReader(xmlString))
            {
                this.conversations = (Conversations)serializer.Deserialize(reader);
            }
        }
    }
}