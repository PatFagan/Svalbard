using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    public gChopWood()
    {
        name = "Chop Wood";
        cost = 4;
        //preconditions = new KeyValuePair<string, bool>("Has Axe", false);
        //preconditions.Add(new KeyValuePair<string, bool>("Has Axe", false));
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);
    }
}