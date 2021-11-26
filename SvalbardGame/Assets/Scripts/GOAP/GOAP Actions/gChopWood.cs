using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    public string aiName;

    // get agent status
    gGoapAgent goapAgentScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
    }

    public gChopWood()
    {
        name = "ChopWood";
        cost = 1;
        preconditions.Add("HasAxe", false);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["HasAxe"] == true)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);

        preconditions["HasAxe"] = goapAgentScript.hasAxe;
    }
}