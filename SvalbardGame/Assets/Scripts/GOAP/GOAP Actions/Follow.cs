using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;

    GameObject target;
    Transform followerTransform;
    Vector3 targetPos;
    Vector3 currentPos;
    GameObject follower;
    public void FollowTarget(string targetTag, GameObject newFollower)
    {
        follower = newFollower;
        target = GameObject.FindGameObjectWithTag(targetTag);
        targetPos = target.GetComponent<Transform>().position;
        followerTransform = follower.GetComponent<Transform>(); 
        currentPos = new Vector3(followerTransform.position.x, followerTransform.position.y, followerTransform.position.z);

        if (target)
            StartCoroutine(MoveToTarget());
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
}