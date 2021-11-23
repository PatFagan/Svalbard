using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    public gEatFood()
    {
        name = "Eat Food";
        cost = 1;
        preconditions.Add("Is Hungry", true);
    }

    public override bool CheckPreconditions()
    {
        bool preconditionState;
        if (preconditions.TryGetValue("Is Hungry", out preconditionState))
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("eating food, cost: " + cost);
    }
}