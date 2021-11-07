using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TMP_Text dialogueBox;
    public string[] sentences;
    public string farewellDialogue;
    int index;
    bool hello = false;
    public int indexCap; // add to cap when certain criteria are met in game

    public void StartDialogue()
    {
        hello = true;
        dialogueBox.text = "";
        StartCoroutine(LoadDialogue());
    }

    public void EndDialogue()
    {
        hello = false;
        dialogueBox.text = farewellDialogue;
        StartCoroutine(CloseDialogue());
    }

    IEnumerator LoadDialogue()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            if (hello == true)
            {
                dialogueBox.text += letter;
                yield return new WaitForSeconds(.05f);
            }
        }
    }

    public void NextLine()
    {
        if (index < sentences.Length - 1)
        {
            if (index < indexCap - 1)
            {
                index++;
                StartDialogue();
            }
        }
    }

    void FinishLine()
    {
        dialogueBox.text = sentences[index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hello == true)
        {
            //if (dialogueBox.text != sentences[index])
            //{
            //    FinishLine();
            //}
            if (dialogueBox.text == sentences[index])
            {
                NextLine();
            }
        }
    }

    IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(2f);
        dialogueBox.text = "";
    }
}