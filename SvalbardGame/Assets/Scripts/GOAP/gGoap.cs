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

    void Start()
    {
        getListOfGoapActions();

        // sort goap actions by cost, from least to greatest
        //gnomeSort(GoapActions, goapActionsListSize);
    }

    public void RunState(GameObject goapAgent)
    {
        print("goap state");

        // run through goap actions
        // run first action with all preconditions met
        for (int i = 0; i < GoapActions.Count; i++)
        {
            if (GoapActions[i].CheckPreconditions())
            {
                GoapActions[i].RunAction();
                break;
            }
        }

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

        print("SORTED: " + list[0] + " COST: " + list[0].cost); 
        print("SORTED: " + list[1] + " COST: " + list[1].cost);
        print("SORTED: " + list[2] + " COST: " + list[2].cost);
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