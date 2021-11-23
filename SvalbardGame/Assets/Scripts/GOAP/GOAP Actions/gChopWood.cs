using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gChopWood : gGoapAction
{
    bool hasAxe;
    bool runningCheck;
    public gChopWood()
    {
        name = "Chop Wood";
        cost = 4;
        hasAxe = true;
        preconditions.Add("Has Axe", hasAxe);
    }

    void Update()
    {
        if (runningCheck == false)
            StartCoroutine(SwapAxe());
    }

    IEnumerator SwapAxe()
    {
        runningCheck = true;
        yield return new WaitForSeconds(2f);

        hasAxe = !hasAxe;
        preconditions["Has Axe"] = hasAxe;
        
        runningCheck = false;
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["Has Axe"] == true)
            return true;
        else
            return false;
    }

    public override void RunAction()
    {
        print("chopping wood, cost: " + cost);
    }
}