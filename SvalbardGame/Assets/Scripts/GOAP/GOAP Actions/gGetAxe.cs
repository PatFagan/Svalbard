using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    public gGetAxe()
    {
        name = "Get Axe";
        cost = 2;
        preconditions.Add("Needs Axe", true);
    }

    public override bool CheckPreconditions()
    {
        bool preconditionState;
        if (preconditions.TryGetValue("Needs Axe", out preconditionState))//.Value == false)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);
    }
}