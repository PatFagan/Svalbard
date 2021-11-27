using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    TMP_Text questText;
    TMP_Text dialogueBox;
    Image currentCharacter;
    public GameObject vendorButton;
    public GameObject vendorMenu;

    public int index; // current dialogue being said

    bool nearNPC = false;
    string[] sentences;
    AudioSource[] voiceActing;
    Sprite[] characterImages;
    string farewellDialogue;
    AudioSource farewellAudio;
    int[] questUpdates;

    float timer;

    void Start()
    {
        questText = GameObject.Find("QuestText").GetComponent<TMP_Text>();
        dialogueBox = GameObject.Find("Dialogue").GetComponent<TMP_Text>();
        currentCharacter = GameObject.Find("CharacterImage").GetComponent<Image>();
    }

    public void StartDialogue(Conversation conversation)
    {
        sentences = conversation.sentences;
        characterImages = conversation.characterImages;
        voiceActing = conversation.voiceActing;
        farewellDialogue = conversation.farewellDialogue;
        farewellAudio = conversation.farewellAudio;

        nearNPC = true;
        dialogueBox.text = "";
        currentCharacter.sprite = characterImages[index];
        currentCharacter.enabled = true;
        StartCoroutine(LoadDialogue());
        if (vendorButton)
            vendorButton.SetActive(true);
    }

    void ContinueDialogue()
    {
        nearNPC = true;
        dialogueBox.text = "";
        currentCharacter.sprite = characterImages[index];
        currentCharacter.enabled = true;
        StartCoroutine(LoadDialogue());
        if (vendorButton)
            vendorButton.SetActive(true);
    }

    IEnumerator LoadDialogue()
    {
        voiceActing[index].Play();
        foreach (char letter in sentences[index].ToCharArray())
        {
            if (nearNPC == true)
            {
                dialogueBox.text += letter;
                yield return new WaitForSeconds(.01f);
            }
        }
        CheckQuestStatus(index);
    }

    public void NextLine()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            ContinueDialogue();
        }
    }

    void FinishLine()
    {
        dialogueBox.text = sentences[index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nearNPC == true)
        {
            if (dialogueBox.text == sentences[index])
            {
                NextLine();
            }
        }
        timer--;
    }

    IEnumerator CloseDialogue()
    {
        nearNPC = false;
        if (nearNPC == false)
        {
            farewellAudio.Play();
            dialogueBox.text = farewellDialogue;
            currentCharacter.enabled = false;
            if (vendorButton)
                vendorButton.SetActive(false);
            if (vendorMenu)
                vendorMenu.SetActive(false);
            timer = 300f;
            yield return new WaitUntil(() => nearNPC == true || timer == 0);
            dialogueBox.text = "";
        }
    }

    // dialogue end trigger
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(CloseDialogue());
        }
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
        switch (status)
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
}