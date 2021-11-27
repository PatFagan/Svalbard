using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePreconditions : MonoBehaviour
{
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    void Start()
    {
        preconditions.Add("HasLightBulb", false);
        preconditions.Add("HasMetCartographer", false);

        preconditions.Add("AtCartographer", false);
    }
}