using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoap : MonoBehaviour
{
    gFSM fsmScript;

    public List<gGoapAction> GoapActions;
    int goapActionsListSize;

    gGetAxe getAxeScript;
    void getListOfGoapActions()
    {
        getAxeScript = GameObject.Find("GoapActionKeeper").GetComponent<gGetAxe>();
        GoapActions[3] = getAxeScript;
    }

    public void RunState(GameObject goapAgent)
    {
        print("goap state");

        getListOfGoapActions();
        GoapActions[3].RunAction();

        goapActionsListSize = GoapActions.Count;

        //gnomeSort(GoapActions, goapActionsListSize);
        // sort goap actions by cost, from least to greatest

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
                swapVar(list[i].cost, list[i - 1].cost);
                i--;
            }
        }
    }

    // swaps two values
    void swapVar<T>(T a, T b)
    {
        T temp;
        temp = a;
        a = b;
        b = temp;
    }
}