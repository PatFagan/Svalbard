using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gAnimate : MonoBehaviour
{
    gFSM fsmScript;
    gGoapAgent goapAgentScript;
    Animator goapAgentAnimator;
    gMoveToPos moveToScript;

    public void RunState(GameObject goapAgent)
    {
        fsmScript = goapAgent.GetComponent<gFSM>();
        goapAgentScript = goapAgent.GetComponent<gGoapAgent>();
        goapAgentAnimator = goapAgent.GetComponent<Animator>();
        moveToScript = GameObject.Find("GoapActionKeeper").GetComponent<gMoveToPos>();

        print("animate state");

        // play an animation
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        yield return new WaitUntil(() => moveToScript.targetPos == moveToScript.currentPos); // wait until ai has arrived at moveTo's target
        goapAgentAnimator.Play(goapAgentScript.currentAnimation); // play anim
        fsmScript.currentState = "Goap"; // set to next state after finished
    }
}