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
    public Vector3 movement;
    public bool immobile = false;

    // components
    public SpriteRenderer spriteRenderer;
    public Rigidbody rigidbody;
    public Animator animator;

    float MAX_SPRINT_GAUGE = 20f;
    float sprintGauge;

    Shooting shootingScript;
    void Start()
    {
        BASE_MOVE_SPEED = moveSpeed;
        shootingScript = GameObject.Find("Player/Shooting").GetComponent<Shooting>();
    }

    void FixedUpdate()
    {
        // movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        if (immobile == false)
        {
            rigidbody.velocity = movement * moveSpeed; 
        }
        else if (immobile == true) // shooting stance
        {
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }

        // sprite flipping
        if (horizontal > 0)
            spriteRenderer.flipX = true;
        else if (horizontal < 0)
            spriteRenderer.flipX = false;

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

        // gun
        spriteRenderer.flipY = shootingScript.gunEquipped; // FOR TESTING

        // anims
        //if (rigidbody.velocity.z == 0)
        //    animator.Play("right-arrow-anim");
        //else if (vertical == -1 && (horizontal == 1 || horizontal == -1))
        //    animator.Play("down-right-arrow-anim");
        //else if (vertical == 1 && (horizontal == 1 || horizontal == -1))
        //    animator.Play("up-right-arrow-anim");
        //else if (vertical == 1)
        //    animator.Play("up-arrow-anim");
        //else if (vertical == -1)
        //    animator.Play("down-arrow-anim");
    }
}