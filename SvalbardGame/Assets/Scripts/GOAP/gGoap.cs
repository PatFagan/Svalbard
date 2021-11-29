using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoap : MonoBehaviour
{
    gFSM fsmScript;

    public List<gGoapAction> GoapActions;

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
        gnomeSort(GoapActions);
    }

    public void RunState(GameObject goapAgent)
    {
        print("goap state");

        // run through goap actions
        // run first action with all preconditions met
        for (int i = GoapActions.Count - 1; i >= 0; i--)
        {
            if (GoapActions[i].CheckPreconditions())
            {
                GoapActions[i].RunAction();
                break;
            }
        }

        fsmScript = goapAgent.GetComponent<gFSM>();
        fsmScript.currentState = "MoveToPos"; // set to next state after finished
    }

    void gnomeSort(List<gGoapAction> list)
    {
        int i = 0;

        while (i < list.Count)
        {
            if (i == 0)
                i++;
            if (list[i - 1].cost >= list[i].cost)
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