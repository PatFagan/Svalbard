using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursorMovement : MonoBehaviour
{
    // movement variables
    float horizontal, vertical;
    public float moveSpeed;
    public Vector3 movement;

    // components
    public Rigidbody rigidbody;

    void FixedUpdate()
    {
        // movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        rigidbody.velocity = movement * moveSpeed;
    }
}