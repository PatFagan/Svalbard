using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGetAxe : gGoapAction
{
    bool hasAxe;
    public gGetAxe()
    {
        name = "GetAxe";
        cost = 2;
        hasAxe = false;
        preconditions.Add("NeedsAxe", hasAxe);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["NeedsAxe"] == true)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("getting axe, cost: " + cost);

        hasAxe = !hasAxe;
        preconditions["NeedsAxe"] = hasAxe;
    }
}