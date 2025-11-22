using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using TMPro;
using JetBrains.Annotations;

public class Dialogue : MonoBehaviour
{
    TextAsset DialogueIntro;
    string dialogue;
    List<string> dialogueLines = new List<string>();
    List<DialogueOption> dialogueOptions = new List<DialogueOption>();
    private int currentIndex = 0; //Conversation number
    private int choiceNum = 0;
    private bool choiceState = false;
    private bool buttonsActive = false;
    public TextMeshProUGUI dialogueText;
    public GameObject Buttons;
    public List <TextMeshProUGUI> choiceTexts;
    private void Start()
    {
        currentIndex = 0;
        DialogueIntro = Resources.Load<TextAsset>("Dialogues/DialogueIntro");
        dialogue = DialogueIntro.text;
        dialogueLines = dialogue.Split(new[] { '\n' }).ToList();
        foreach (string line in dialogueLines)
        {
            dialogueOptions.Add(new DialogueOption());
            if (line.Contains("~"))
            {
                dialogueOptions[currentIndex].Text1.Add(line.Replace("~", "").Trim());
            }
            else if (line.Contains("+"))
            {
                dialogueOptions[currentIndex].Text2.Add(line.Replace("+", "").Trim());
            }
            else if (line.Contains("|"))
            {
                dialogueOptions[currentIndex].optionText.Add(line.Replace("|", "").Trim());
            }

            else if (line.Contains("/"))
            {
                dialogueOptions[currentIndex].responseLines.Add(line.Replace("/", "").Trim());

            }
            else if (line.Contains("("))
            {
                currentIndex++;
            }
        }

        currentIndex = 0;

        foreach (string option in dialogueOptions[currentIndex].optionText)
        {
            Debug.Log(option);
        }

        UISetup();
        
    }

    //STATES: BUTTON + PROMPT TEXT (choiceState = true), NORMAL TEXT (choiceState = false), RESPONSE TEXT (choiceState = true)
    //HAVE TO SET CHOICE STATE TO FALSE AFTER RESPONSE IS GIVEN
    //NEED TO FORWARD DIALOGUE AFTER RESPONSE IS GIVEN

    public void Update()
    {
    //Press E, if buttons aren't active, goes to next dialogue set, then assumes that we are in normal text (which we are) and then makes sure buttons are inactive

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!buttonsActive)
            {
                currentIndex++;
            }
            else
            {
            }
            choiceState = !choiceState;
            buttonsActive = false;
            Debug.Log(choiceState);
            Debug.Log(buttonsActive);

        }
    }
    public void buttonClicked(int optionNum)
    {
        Buttons.SetActive(false);
        buttonsActive = false;
        choiceNum = optionNum;
        dialogueText.text = dialogueOptions[currentIndex].responseLines[optionNum];

    }
    public void UISetup()
    {
        if (dialogueOptions[currentIndex].optionText.Count >= 1)
        {
            for (int i = 0; i < dialogueOptions[currentIndex].optionText.Count; i++)
            {
                choiceTexts[i].text = dialogueOptions[currentIndex].optionText[i];
            }
            if (Buttons.gameObject.activeSelf == false && choiceState == false)
            {
                dialogueText.text = dialogueOptions[currentIndex].Text2[0];
            }
            else if (Buttons.gameObject.activeSelf == true)
            {
                dialogueText.text = dialogueOptions[currentIndex].Text1[0];
                buttonsActive = true;
            }
        }
    }
}

public class DialogueOption
{
    public List<string> Text1 = new List<string>();
    public List<string> Text2 = new List<string>();
    public List<string> optionText = new List<string>();
    public List<string> responseLines = new List<string>();

}

//interaction, set option num, search for response not option, debug


