using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gAnimate : MonoBehaviour
{
    gFSM fsmScript;

    public void RunState(GameObject goapAgent)
    {
        fsmScript = goapAgent.GetComponent<gFSM>();
        print("animate state");

        // play an animation
        // have goap set the animation

        fsmScript.currentState = "Goap"; // set to next state after finished
    }
}