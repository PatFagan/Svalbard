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

    bool nearNPC = false;
    public string[] sentences;
    public AudioSource[] voiceActing;
    public Sprite[] characterImages;
    public string farewellDialogue;
    public AudioSource farewellAudio;
    public int[] questUpdates;

    float timer;

    DialogueIndices dialogueIndicesScript;
    void Start()
    {
        questText = GameObject.Find("QuestText").GetComponent<TMP_Text>();
        dialogueBox = GameObject.Find("Dialogue").GetComponent<TMP_Text>();
        currentCharacter = GameObject.Find("CharacterImage").GetComponent<Image>();
        //vendorMenu = GameObject.Find("VendorMenu");

        dialogueIndicesScript = gameObject.GetComponent<DialogueIndices>();
    }

    public void StartDialogue()
    {
        nearNPC = true;
        dialogueBox.text = "";
        currentCharacter.sprite = characterImages[dialogueIndicesScript.index];
        currentCharacter.enabled = true;
        StartCoroutine(LoadDialogue());
        if (vendorButton)
            vendorButton.SetActive(true);
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
            timer = 200f;
            yield return new WaitUntil(() => nearNPC == true || timer == 0);
            dialogueBox.text = "";
        }
    }

    // dialogue start and end triggers
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartDialogue();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(CloseDialogue());
        }
    }
}