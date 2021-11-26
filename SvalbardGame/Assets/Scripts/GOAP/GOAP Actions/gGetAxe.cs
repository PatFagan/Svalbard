using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    public string aiName;

    // get agent status
    gGoapAgent goapAgentScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
    }

    public gGetAxe()
    {
        name = "GetAxe";
        cost = 2;
        preconditions.Add("NeedsAxe", false);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["NeedsAxe"] == true)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);

        preconditions["NeedsAxe"] = goapAgentScript.hasAxe;
    }
}