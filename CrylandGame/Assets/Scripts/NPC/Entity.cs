using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] buttons;
    [SerializeField]
    private Animation DialogueAnimation;
    [SerializeField]
    private TMPro.TextMeshProUGUI textGUIObj;

    protected List<string> Texts;
    protected int DialogueNumber = 0;
    
    // used as a void start in derrived classes
    // made so that every single derrived class had new texts list made automatically for it
    protected virtual void MakeTexts()
    {

    }
    public void Start()
    {
        Texts = new List<string>();
        MakeTexts();
    }

    // prints out text
    protected void Talk()
    {
        InteractibleList playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractibleList>();
        if (playerScr.dialogueActive == true)
        {
            return;
        }
        playerScr.dialogueActive = true;
        playerScr.dialogueWith = this.gameObject;
        //textGUIObj.text = Texts[0];
        StartCoroutine(TypeText());
        DialogueAnimation.clip = DialogueAnimation.GetClip("PopUpAnimation");
        DialogueAnimation.Play();
    }

    // was used when i wanted to print based on input; decided to have list of strings
    // not used anymore
    protected void NextSlide(string text)
    {
        textGUIObj.text = text;
    }

    // NextSlide is called whenever you press yes and it shows next dialogue message. SlideActionInh is for inherited classes
    // override (check NPC2.cs)
    protected virtual void SlideActionInh() {
    }
    protected virtual void NextSlide()
    {
        DialogueNumber++;
        SlideActionInh();
        if (DialogueNumber >= Texts.Count)
        {
            return;
        }
        //textGUIObj.text = Texts[DialogueNumber];
        StartCoroutine(TypeText());
    }


    protected void ActivateButtons()
    {
        foreach (GameObject a in buttons)
        {
            a.SetActive(true);
        }
    }
    protected void DeactivateButtons()
    {
        foreach (GameObject a in buttons)
        {
            a.SetActive(false);
        }
    }
    protected void SetButton(bool a, bool b)
    {
        buttons[0].SetActive(a);
        buttons[1].SetActive(b);
    }
    protected void RemoveTextGUI()
    {
        InteractibleList playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractibleList>();
        if (playerScr.dialogueActive == false)
        {
            return;
        }
        DialogueAnimation.clip = DialogueAnimation.GetClip("DisappearAnimation");
        DialogueAnimation.Play();
        playerScr.dialogueActive = false;
        DialogueNumber = 0;
    }

    private IEnumerator TypeText()
    {
        // later think of making it in the way where they dont appear when you press a button or when you walk away!!!!!
        textGUIObj.text = string.Empty;
        
        foreach (char c in Texts[DialogueNumber])
        {
            textGUIObj.text += c;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2);
    }
}
