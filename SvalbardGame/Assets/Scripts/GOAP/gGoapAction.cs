using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class gGoapAction : MonoBehaviour
{
    public string name;
    public int cost;
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    public abstract bool CheckPreconditions();
    public abstract void RunAction();
}