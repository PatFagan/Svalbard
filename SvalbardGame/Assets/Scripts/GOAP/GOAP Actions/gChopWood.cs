using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    // get agent status and moveTo script
    gGoapAgent goapAgentScript;
    gMoveToPos moveToScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        moveToScript = GameObject.Find("GoapActionKeeper").GetComponent<gMoveToPos>();
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
        {
            NextState();
            return false;
        }
    }

    void Update()
    {
        preconditions["HasAxe"] = goapAgentScript.hasAxe;
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);
        moveToScript.SetTarget("Wood", GameObject.Find(aiName));
    }
}