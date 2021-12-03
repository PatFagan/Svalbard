using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gAnimate : MonoBehaviour
{
    gFSM fsmScript;
    gGoapAgent goapAgentScript;
    Animator goapAgentAnimator;

    public void RunState(GameObject goapAgent)
    {
        fsmScript = goapAgent.GetComponent<gFSM>();
        goapAgentScript = goapAgent.GetComponent<gGoapAgent>();
        goapAgentAnimator = goapAgent.GetComponent<Animator>();

        print("animate state");

        // play an animation
        goapAgentAnimator.Play(goapAgentScript.currentAnimation);

        fsmScript.currentState = "Goap"; // set to next state after finished
    }
}