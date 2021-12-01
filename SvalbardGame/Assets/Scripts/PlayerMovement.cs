using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    float horizontal, vertical, BASE_MOVE_SPEED;
    public float moveSpeed;
    public Vector3 movement, shootingDirection;

    // components
    public SpriteRenderer spriteRenderer;
    public Rigidbody rigidbody;

    float MAX_SPRINT_GAUGE = 30f;
    float sprintGauge;

    void Start()
    {
        BASE_MOVE_SPEED = moveSpeed;
    }

    void FixedUpdate()
    {
        // movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        rigidbody.velocity = movement * moveSpeed;

        // shooting direction
        if (movement.x >= .3f || movement.z >= .3f || movement.x <= -.3f || movement.z <= -.3f)
            shootingDirection = movement;

        // sprite flipping
        if (horizontal > 0)
            spriteRenderer.flipX = false;
        else if (horizontal < 0)
            spriteRenderer.flipX = true;

        // sprinting
        if (Input.GetButton("Sprint") && sprintGauge > 0f) // if dodge button pressed, the dodge
        {
            moveSpeed += .5f;
            sprintGauge--;
        }
        if (!Input.GetButton("Sprint"))
        {
            moveSpeed = BASE_MOVE_SPEED;
            if (sprintGauge <= MAX_SPRINT_GAUGE)
                sprintGauge++;
        }
    }
}