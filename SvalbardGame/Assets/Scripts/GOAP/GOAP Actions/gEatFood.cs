using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gEatFood : gGoapAction
{
    public gEatFood()
    {
        name = "Eat Food";
        cost = 1;
        //preconditions = new KeyValuePair<string, bool>("Has Axe", false);
        //preconditions.Add(new KeyValuePair<string, bool>("Has Axe", false));
    }

    public override void RunAction()
    {
        print("eating food, cost: " + cost);
    }
}