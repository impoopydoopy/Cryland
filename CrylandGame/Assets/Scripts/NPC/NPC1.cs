using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : Entity, IActionable
{
    protected override void MakeTexts()
    {
        Texts.Add("Hello");
    }
    public void Action()
    {
        DeactivateButtons();
        Talk();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractibleList playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractibleList>();
        if (playerScr.dialogueActive == true && playerScr.dialogueWith == this.gameObject)
        {
            RemoveTextGUI();
            playerScr.dialogueWith = null;
        }
    }
}
