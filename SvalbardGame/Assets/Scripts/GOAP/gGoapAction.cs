using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class gGoapAction : MonoBehaviour
{
    public string name;
    public int cost;
    //public HashSet<KeyValuePair<string, bool>> preconditions;

    public abstract void RunAction();
}