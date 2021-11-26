using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    // get agent status and follow script
    gGoapAgent goapAgentScript;
    Follow followScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
        followScript = GameObject.Find("GoapActionKeeper").GetComponent<Follow>();
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
            return false;
    }

    void Update()
    {
        preconditions["IsHungry"] = goapAgentScript.isHungry;
    }

    public override void RunAction()
    {
        print("eating food, cost: " + cost);
        followScript.FollowTarget("Food", GameObject.Find(aiName));
    }
}