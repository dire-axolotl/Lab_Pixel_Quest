using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using TMPro;

public class Dialogue : MonoBehaviour
{
    TextAsset DialogueIntro;
    string dialogue;
    List<string> dialogueLines = new List<string>();
    List<DialogueOption> dialogueOptions = new List<DialogueOption>();
    private int currentIndex = 0; //Conversation number
    private int choiceNum = 0;
    public TextMeshProUGUI dialogueText;
    public GameObject Buttons;
    public List <TextMeshProUGUI> choiceTexts;
    private void Start()
    {

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
                dialogueOptions[currentIndex].Test2.Add(line.Replace("+", "").Trim());
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

        //Collect player input 

        Debug.Log(dialogueOptions[currentIndex].responseLines[choiceNum]);
        if (dialogueOptions[currentIndex].optionText.Count >= 1)
        {
            for (int i = 0; i < dialogueOptions[currentIndex].optionText.Count; i++)
            {
                choiceTexts[i].text = dialogueOptions[currentIndex].optionText[i];
            }
            dialogueText.text = dialogueOptions[currentIndex].Text1[0];
        }
    }

    public void buttonClicked(int optionNum)
    {
        Buttons.SetActive(false);
        choiceNum = optionNum;
        dialogueText.text = dialogueOptions[currentIndex].responseLines[optionNum];

    }
}

public class DialogueOption
{
    public List<string> Text1 = new List<string>();
    public List<string> Test2 = new List<string>();
    public List<string> optionText = new List<string>();
    public List<string> responseLines = new List<string>();

}

//interaction, set option num, search for response not option, debug


