using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    bool nearNPC = false;
    public TMP_Text questText;
    public TMP_Text dialogueBox;
    public string[] sentences;
    public AudioSource[] voiceActing;
    public string farewellDialogue;
    public AudioSource farewellAudio;
    public int[] questUpdates;

    public Sprite[] characterImages;
    public Image currentCharacter;

    DialogueIndices dialogueIndicesScript;
    void Start()
    {
        dialogueIndicesScript = gameObject.GetComponent<DialogueIndices>();
    }

    public void StartDialogue()
    {
        nearNPC = true;
        dialogueBox.text = "";
        currentCharacter.sprite = characterImages[dialogueIndicesScript.index];
        currentCharacter.enabled = true;
        StartCoroutine(LoadDialogue());
    }

    public void EndDialogue()
    {
        nearNPC = false;
        farewellAudio.Play();
        dialogueBox.text = farewellDialogue;
        currentCharacter.enabled = false;
        StartCoroutine(CloseDialogue());
    }

    // check to see if a quest has been updated
    public void CheckQuestStatus(int currentIndex)
    {
        for (int i = 0; i < questUpdates.Length; i++)
        {
            if (currentIndex == questUpdates[i])
            {
                StartCoroutine(ShowQuestStatus(1));
            }
        }
    }

    // if one has, display the update
    IEnumerator ShowQuestStatus(int status)
    {
        switch(status)
        {
            case 1:
                questText.text = "FAVOR EARNED";
                yield return new WaitForSeconds(3f);
                questText.text = "";
                break;
            default:
                questText.text = "QUEST UPDATED";
                yield return new WaitForSeconds(3f);
                questText.text = "";
                break;
        }
    }

    IEnumerator LoadDialogue()
    {
        voiceActing[dialogueIndicesScript.index].Play();
        foreach (char letter in sentences[dialogueIndicesScript.index].ToCharArray())
        {
            if (nearNPC == true)
            {
                dialogueBox.text += letter;
                yield return new WaitForSeconds(.01f);
            }
            else
            {
                break;
            }
        }
        CheckQuestStatus(dialogueIndicesScript.index);
    }

    public void NextLine()
    {
        if (dialogueIndicesScript.index < sentences.Length - 1)
        {
            if (dialogueIndicesScript.index < dialogueIndicesScript.indexCap - 1)
            {
                dialogueIndicesScript.index++;
                StartDialogue();
            }
        }
    }

    void FinishLine()
    {
        dialogueBox.text = sentences[dialogueIndicesScript.index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nearNPC == true)
        {
            if (dialogueBox.text == sentences[dialogueIndicesScript.index])
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