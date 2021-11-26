using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    public string aiName;

    // get agent status
    gGoapAgent goapAgentScript;
    void Start()
    {
        goapAgentScript = GameObject.Find(aiName).GetComponent<gGoapAgent>();
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

    public override void RunAction()
    {
        print("eating food, cost: " + cost);

        preconditions["IsHungry"] = goapAgentScript.isHungry;
    }
}