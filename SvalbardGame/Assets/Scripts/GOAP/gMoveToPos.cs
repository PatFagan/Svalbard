using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gMoveToPos : MonoBehaviour
{
    public float speed;
    GameObject target;
    Transform followerTransform;
    Vector3 targetPos;
    Vector3 currentPos;
    GameObject follower;
    public void SetTarget(string targetTag, GameObject newFollower)
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
    }

    IEnumerator MoveToTarget()
    {
        targetPos = target.GetComponent<Transform>().position;
        followerTransform = follower.GetComponent<Transform>();
        currentPos = new Vector3(followerTransform.position.x, followerTransform.position.y, followerTransform.position.z);

        while (targetPos != currentPos && target) // while not arrived and while target exists
        {
            if (!target)
                break;

            currentPos = new Vector3(followerTransform.position.x, followerTransform.position.y, followerTransform.position.z);

            // position = Vector2.MoveTowards(from, to, speed);
            follower.GetComponent<Transform>().position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
            yield return new WaitForSeconds(.1f);
        }
    }

    gFSM fsmScript;

    public void RunState(GameObject goapAgent)
    {
        fsmScript = goapAgent.GetComponent<gFSM>();
        print("moveTo state");

        follower = goapAgent;

        if (target)
            StartCoroutine(MoveToTarget());

        fsmScript.currentState = "Animate"; // set to next state after finished
    }
}