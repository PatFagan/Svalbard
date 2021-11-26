using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    // get agent status and follow script
    gGoapAgent goapAgentScript;
    Follow followScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        followScript = GameObject.Find("GoapActionKeeper").GetComponent<Follow>();
    }

    public gGetAxe()
    {
        name = "GetAxe";
        cost = 2;
        preconditions.Add("NeedsAxe", true);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["NeedsAxe"] == true)
            return true;
        else
            return false;
    }

    void Update()
    {
        preconditions["NeedsAxe"] = !goapAgentScript.hasAxe;
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);
        followScript.FollowTarget("Axe", GameObject.Find(aiName));
    }
}