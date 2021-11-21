using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string npcName;
    public int indexIncrease;

    DialogueIndices dialogueIndicesScript;
    void Start()
    {
        dialogueIndicesScript = GameObject.Find(npcName).GetComponent<DialogueIndices>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dialogueIndicesScript.indexCap += indexIncrease;
            dialogueIndicesScript.index++;
            Destroy(gameObject);
        }
    }
}