using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    bool hasAxe;
    public gChopWood()
    {
        name = "ChopWood";
        cost = 1;
        hasAxe = false;
        preconditions.Add("HasAxe", hasAxe);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["HasAxe"] == true)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);

        hasAxe = !hasAxe;
        preconditions["HasAxe"] = hasAxe;
    }
}