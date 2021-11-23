using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoap : MonoBehaviour
{
    gFSM fsmScript;

    public List<gGoapAction> GoapActions;
    int goapActionsListSize;

    gChopWood chopWoodScript;
    gGetAxe getAxeScript;
    gEatFood eatFoodScript;
    void getListOfGoapActions()
    {
        chopWoodScript = GameObject.Find("GoapActionKeeper").GetComponent<gChopWood>();
        GoapActions[0] = chopWoodScript;
        getAxeScript = GameObject.Find("GoapActionKeeper").GetComponent<gGetAxe>();
        GoapActions[1] = getAxeScript;
        eatFoodScript = GameObject.Find("GoapActionKeeper").GetComponent<gEatFood>();
        GoapActions[2] = eatFoodScript;
    }

    public void RunState(GameObject goapAgent)
    {
        print("goap state");

        getListOfGoapActions();

        goapActionsListSize = GoapActions.Count;
        //print(goapActionsListSize);

        // sort goap actions by cost, from least to greatest
        //gnomeSort(GoapActions, goapActionsListSize);
        // run the least cost action
        GoapActions[2].RunAction();

        // run through goap actions
        // then find the first one that has all preconditions met, and pick that one

        // (this will automatically run planning since if an axe has already...
        // ...been picked up, then the preconditions will have been met...
        // ...and the cost will be low enough to make 'chop wood' the best action to go to next

        fsmScript = goapAgent.GetComponent<gFSM>();
        fsmScript.currentState = "MoveToPos"; // set to next state after finished
    }

    void gnomeSort(List<gGoapAction> list, int size)
    {
        int i = 0;

        while (i < size)
        {
            if (i == 0)
                i++;
            if (list[i - 1].cost <= list[i].cost)
                i++;
            else
            {
                swapVar(list[i], list[i - 1]);
                i--;
            }
        }
    }

    // swaps two values
    void swapVar(gGoapAction a, gGoapAction b)
    {
        gGoapAction temp;
        temp = a;
        a = b;
        b = temp;
    }
}