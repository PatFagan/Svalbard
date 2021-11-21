using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    DialogueScript dialogueScript;
    void Start()
    {
        dialogueScript = gameObject.GetComponent<DialogueScript>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dialogueScript.StartDialogue();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dialogueScript.EndDialogue();
        }
    }
}