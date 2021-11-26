using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Conversation : MonoBehaviour
{
    public int cost;
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    public string[] sentences;
    public AudioSource[] voiceActing;
    public Sprite[] characterImages;
    public string farewellDialogue;
    public AudioSource farewellAudio;

    public abstract bool CheckPreconditions();
    public abstract void RunAction();

    DialoguePreconditions dialoguePreconditionsScript;
    public void UpdatePreconditions()
    {
        dialoguePreconditionsScript = GameObject.Find("Player").GetComponent<DialoguePreconditions>();
        preconditions = DialoguePreconditions.preconditions;
    }
}