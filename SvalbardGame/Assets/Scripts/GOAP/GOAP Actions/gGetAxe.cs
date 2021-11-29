using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    // get agent status and moveTo script
    gGoapAgent goapAgentScript;
    gMoveToPos moveToScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        moveToScript = GameObject.Find("GoapActionKeeper").GetComponent<gMoveToPos>();
    }

    public gGetAxe()
    {
        name = "GetAxe";
        cost = 2;
        preconditions.Add("NeedsAxe", true);
        preconditions.Add("AxeExists", false);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["NeedsAxe"] == true && preconditions["AxeExists"] == true)
            return true;
        else
        {
            NextState();
            return false;
        }
    }

    void Update()
    {
        preconditions["NeedsAxe"] = !goapAgentScript.hasAxe;

        if (GameObject.FindGameObjectWithTag("Axe"))
            preconditions["AxeExists"] = true;
        else
            preconditions["AxeExists"] = false;
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);
        moveToScript.SetTarget("Axe", GameObject.Find(aiName));
    }
}