using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Conversation : MonoBehaviour
{
    public int cost;
    public string conditionKey;
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    public string[] sentences;
    public AudioSource[] voiceActing;
    public Sprite[] characterImages;
    public string farewellDialogue;
    public AudioSource farewellAudio;
    public int[] questUpdates;

    public abstract bool CheckPreconditions();
    public abstract void UpdatePreconditions();

    DialoguePreconditions dialoguePreconditionsScript;
    public void UpdateToPlayerPreconditions()
    {
        dialoguePreconditionsScript = GameObject.Find("Player").GetComponent<DialoguePreconditions>();
        preconditions = dialoguePreconditionsScript.preconditions;
    }
}