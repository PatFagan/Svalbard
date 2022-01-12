using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string preconditionName;
    public bool destroy;

    public Dictionary<string, bool> dialoguePreconditions;
    void Start()
    {
        dialoguePreconditions = GameObject.Find("Player").GetComponent<DialoguePreconditions>().preconditions;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dialoguePreconditions[preconditionName] = true;
            if(destroy)
                Destroy(gameObject);
        }
    }
}