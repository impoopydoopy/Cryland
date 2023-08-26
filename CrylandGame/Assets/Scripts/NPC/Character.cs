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

        void Start()
        {
            string xmlString = DialogXML.text;

            XmlSerializer serializer = new XmlSerializer(typeof(Conversations));

            using (StringReader reader = new StringReader(xmlString))
            {
                this.conversations = (Conversations)serializer.Deserialize(reader);
                
                //  Debug
                foreach (var conversation in conversations.ConversationList)
                {
                    Debug.Log("Day: " + conversation.Day);
                    foreach (var dialog in conversation.Dialogs)
                    {
                        Debug.Log("Phrase: " + dialog.Phrase);
                        Debug.Log("Answer: " + dialog.Answer);
                    }
                }
            }
        }
    }
}