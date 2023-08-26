using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using NPC;
using UnityEngine;

namespace DialogSystem
{
    public class DialogController : MonoBehaviour
    {
        
        public static DialogController instance;
        public Character mockNPC;

        private void Awake() {
            instance = this;
        }

        private void Start()
        {
            StartDialog(mockNPC, 0);
            StartDialog(mockNPC, 1);
            StartDialog(mockNPC, 2);
        }

        public void StartDialog(Character character, int currentDay)
        {
            Conversations conversations = character.conversations;
            if (currentDay >= conversations.ConversationList.Count)
            {
                Debug.LogError("No such day!");
                return;
            }
                
            List<Dialog> dialogs = conversations.ConversationList[1].Dialogs;
            Debug.Log("Day: " + currentDay);
            foreach (var dialog in dialogs)
            {
                Debug.Log("Phrase: " + dialog.Phrase);
                Debug.Log("Answer: " + dialog.Answer);
            }
        }
    }
}
