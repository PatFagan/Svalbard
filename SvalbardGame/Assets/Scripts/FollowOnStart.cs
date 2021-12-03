using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnStart : MonoBehaviour
{
    public float speed;
    private Transform target;
    public string targetTag;
    Vector3 trackingPosition;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag(targetTag))
        {
            // get target
            target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
            trackingPosition = target.position;
        }
    }

    void FixedUpdate()
    {
        // move towards target
        transform.position = Vector3.MoveTowards(transform.position, trackingPosition, speed * Time.fixedDeltaTime);
    }
}