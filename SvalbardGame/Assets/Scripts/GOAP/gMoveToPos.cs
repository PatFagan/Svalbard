using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gMoveToPos : MonoBehaviour
{
    gFSM fsmScript;

    public void RunState(GameObject goapAgent)
    {
        fsmScript = goapAgent.GetComponent<gFSM>();
        print("moveTo state");

        // run dijksras, have goap set the toNode, (fromNode is just currentPos)

        fsmScript.currentState = "Animate"; // set to next state after finished
    }
}