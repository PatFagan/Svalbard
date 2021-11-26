using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gFSM : MonoBehaviour
{
    public GameObject currentGoapAgent; // get the AI character

    // FSM state scripts
    gGoap goapScript;
    gMoveToPos moveToPosScript;
    gAnimate animateScript;

    public string currentState; // current state key
    bool runningCheck;

    GameObject goapActionKeeper;

    void Start()
    {
        goapActionKeeper = GameObject.Find("GoapActionKeeper");
        // set the FSM states
        goapScript = goapActionKeeper.GetComponent<gGoap>();
        moveToPosScript = goapActionKeeper.GetComponent<gMoveToPos>();
        animateScript = goapActionKeeper.GetComponent<gAnimate>();

        currentState = "Goap"; // set starting state
        runningCheck = false;
    }

    void Update()
    {
        if (runningCheck == false)
            StartCoroutine(CheckState());
    }

    IEnumerator CheckState()
    {
        runningCheck = true;
        yield return new WaitForSeconds(1f);
        // set state based on current state key
        if (currentState == "Goap")
            goapScript.RunState(currentGoapAgent);
        else if (currentState == "MoveToPos")
            moveToPosScript.RunState(currentGoapAgent);
        else if (currentState == "Animate")
            animateScript.RunState(currentGoapAgent);
        else
            print("paused");
        runningCheck = false;
    }
}
