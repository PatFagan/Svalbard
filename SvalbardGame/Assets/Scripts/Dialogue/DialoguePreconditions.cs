using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePreconditions : MonoBehaviour
{
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    void Start() // true = inaccessible, false = accessible
    {
        // GENERAL

        // PIERRE
        preconditions.Add("HasMetCartographer", false);
        preconditions.Add("DoesNotHaveTheMap", true);

        // YIGS
        preconditions.Add("HasMetYigs", false);
        preconditions.Add("HasTheSeed", false);

        // IGOR
        preconditions.Add("HasMetIgor", false);
        preconditions.Add("IGOR-001", false);
    }
}