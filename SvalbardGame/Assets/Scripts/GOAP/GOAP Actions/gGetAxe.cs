using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    public gGetAxe()
    {
        name = "Get Axe";
        cost = 2;
        //preconditions = new KeyValuePair<string, bool>("Has Axe", false);
        //preconditions.Add(new KeyValuePair<string, bool>("Has Axe", false));
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);
    }
}