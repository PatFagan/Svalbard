using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string npcName;
    public int indexIncrease;

    DialogueScript dialogueScript;
    void Start()
    {
        dialogueScript = GameObject.Find(npcName).GetComponent<DialogueScript>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dialogueScript.indexCap += indexIncrease;
            Destroy(gameObject);
        }
    }
}