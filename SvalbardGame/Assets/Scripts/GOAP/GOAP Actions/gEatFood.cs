using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    bool isHungry;
    public gEatFood()
    {
        name = "EatFood";
        cost = 3;
        isHungry = true;
        preconditions.Add("IsHungry", isHungry);
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

        isHungry = !isHungry;
        preconditions["IsHungry"] = isHungry;
    }
}