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
        while (targetPos != currentPos)
        {
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
        targetPos = target.GetComponent<Transform>().position;
        followerTransform = follower.GetComponent<Transform>();
        currentPos = new Vector3(followerTransform.position.x, followerTransform.position.y, followerTransform.position.z);
        print(targetPos);

        if (target)
            StartCoroutine(MoveToTarget());

        fsmScript.currentState = "Animate"; // set to next state after finished
    }
}