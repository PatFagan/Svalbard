using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGoap : MonoBehaviour
{
    public List<Conversation> conversations;
    string characterName = gameObject.name;

    DialogueScript dialogueScript;
    DialoguePreconditions dialoguePreconditionsScript;
    void Start()
    {
        dialogueScript = gameObject.GetComponent<DialogueScript>();
        dialoguePreconditionsScript = GameObject.Find("DialoguePreconditions").GetComponent<DialoguePreconditions>();
        print(characterName);

        // sort list of conversations by cost, from least to greatest
        gnomeSort(conversations);
    }

    void ChooseDialogue()
    {
        // run through goap actions
        // run first action with all preconditions met
        for (int i = conversations.Count - 1; i >= 0; i--)
        {
            if (conversations[i].CheckPreconditions())
            {
                dialogueScript.StartDialogue(conversations[i]); // put sentences, images, voice acting (and maybe color) parameters here
                break;
            }
        }
    }

    void gnomeSort(List<gGoapAction> list)
    {
        int i = 0;

        while (i < list.Count)
        {
            if (i == 0)
                i++;
            if (list[i - 1].cost >= list[i].cost)
                i++;
            else
            {
                swapVar(list[i], list[i - 1]);
                i--;
            }
        }

        //print("SORTED: " + list[0] + " COST: " + list[0].cost);
        //print("SORTED: " + list[1] + " COST: " + list[1].cost);
        //print("SORTED: " + list[2] + " COST: " + list[2].cost);
    }

    // swaps two values
    void swapVar(gGoapAction a, gGoapAction b)
    {
        gGoapAction temp;
        temp = a;
        a = b;
        b = temp;
    }

    // dialogue start trigger
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ChooseDialogue();
        }
    }
}