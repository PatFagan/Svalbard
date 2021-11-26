using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    // get agent status and follow script
    gGoapAgent goapAgentScript;
    Follow followScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        followScript = GameObject.Find("GoapActionKeeper").GetComponent<Follow>();
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

    void Update()
    {
        preconditions["HasAxe"] = goapAgentScript.hasAxe;
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);
        followScript.FollowTarget("Wood", GameObject.Find(aiName));
    }
}