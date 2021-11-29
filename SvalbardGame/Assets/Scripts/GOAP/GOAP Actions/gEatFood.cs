using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    // get agent status and moveTo script
    gGoapAgent goapAgentScript;
    gMoveToPos moveToScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        moveToScript = GameObject.Find("GoapActionKeeper").GetComponent<gMoveToPos>();
    }

    public gEatFood()
    {
        name = "EatFood";
        cost = 3;
        preconditions.Add("IsHungry", true);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["IsHungry"] == true)
            return true;
        else
        {
            NextState();
            return false;
        }
    }

    void Update()
    {
        preconditions["IsHungry"] = goapAgentScript.isHungry;
    }

    public override void RunAction()
    {
        print("eating food, cost: " + cost);
        moveToScript.SetTarget("Food", GameObject.Find(aiName));
    }
}