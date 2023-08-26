using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

namespace DialogSystem
{
    public class DialogController : MonoBehaviour
    {
        public static DialogController instance;

        private void Awake() {
            instance = this;
        }

        public void StartDialog(Character character, int currentDay)
        {
            // TODO: implement
        }
    }
}
