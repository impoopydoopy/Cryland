using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2 : Entity, IActionable
{
    // bad naming; its called in void start() without intercepting parent class void start where it makes a new list of strings
    // it does make list of dialogue texts, but i also needed to add listeners to buttons
    // later change texts.add to XML based text add
    protected override void MakeTexts()
    {
        Texts.Add("Hellol");
        Texts.Add("Sup");
        buttons[0].GetComponent<Button>().onClick.AddListener(NextSlide);
        buttons[1].GetComponent<Button>().onClick.AddListener(onExit);
    }

    // called when interacting (pressing spacebar) in the NPC's area
    public void Action()
    {
        InteractibleList playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractibleList>();
        if (playerScr.dialogueActive == false)
        {
            ActivateButtons();
            Talk();
        }
        
    }
    // widens given [0] or [1] button when the other one disappears; used in DeactivateButtonA()
    // broken!!!
    void MakeButtonXWide(int a)
    {
        RectTransform button = buttons[a].GetComponent<RectTransform>();
        button.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 320);
        //button.anchoredPosition = new Vector2(21f, -40f);
    }

    // supposed to reset button size in onExit
    // works bad
    void ResetButtonSize(int a)
    {
        RectTransform button = buttons[a].GetComponent<RectTransform>();

        button.GetComponent<Button>().onClick.RemoveListener(DeactivateButtonA);
        if (a == 0)
        {
            button.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 160);
            button.anchoredPosition = new Vector2(-76.3f, -40.7f);
        }
        else
        {
            button.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 160);
            button.anchoredPosition = new Vector2(131f, -41f);
        }
        
    }
    
    protected override void SlideActionInh() {
        if (DialogueNumber >= 1)
        {
            Debug.Log("dialogue number is 1 or more");
            Button button = buttons[0].GetComponent<Button>();
            button.onClick.RemoveListener(NextSlide);
            button.onClick.AddListener(DeactivateButtonA);
        }
    }

    // for testing purposes, its specifically deactivates first button and makes second one big
    void DeactivateButtonA()
    {
        Debug.Log("deactivatebuttona done");
        MakeButtonXWide(1);
        buttons[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "bye";
        SetButton(false, true);
    }

    // called when exiting the area or pressing no
    // the reason its entire function is for button listener
    void onExit()
    {
        InteractibleList playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractibleList>();
        if (playerScr.dialogueActive == true && playerScr.dialogueWith == this.gameObject)
        {
            ResetButtonSize(1);
            RemoveTextGUI();
            playerScr.dialogueWith = null;
        }
        buttons[1].GetComponent<Button>().onClick.AddListener(NextSlide);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onExit();
    }
}
