using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGoap : MonoBehaviour
{
    public List<Conversation> conversations; // list of conversations

    DialogueScript dialogueScript; // script that runs the given dialogue
    DialoguePreconditions dialoguePreconditionsScript; // script that checks dialogue preconditions
    void Start()
    {
        dialogueScript = gameObject.GetComponent<DialogueScript>();
        dialoguePreconditionsScript = GameObject.Find("Player").GetComponent<DialoguePreconditions>();

        // sort list of conversations by cost, from least to greatest
        //gnomeSort(conversations);
    }

    public void ChooseDialogue()
    {
        // run through goap actions
        // run first action with all preconditions met
        for (int i = 0; i < conversations.Count; i ++)
        {
            if (conversations[i].CheckPreconditions())
            {
                dialogueScript.StartDialogue(conversations[i]);
                conversations[i].UpdatePreconditions();
                conversations.RemoveAt(i); // removes dialogue from list
                break;
            }
        }
    }

    void gnomeSort(List<Conversation> list)
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
    void swapVar(Conversation a, Conversation b)
    {
        Conversation temp;
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