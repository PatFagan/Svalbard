using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowmobile : MonoBehaviour
{
    bool ridingSnowmobile = false;
    bool atSnowmobile = false;

    // movement variables
    float horizontal, vertical, BASE_MOVE_SPEED;
    public float moveSpeed;
    public Vector3 movement;
    float hMult = 1f, vMult = 1f;

    PlayerMovement playerMovementScript;
    GameObject player;
    Shooting shootingScript;
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        shootingScript = GameObject.Find("Player/Shooting").GetComponent<Shooting>();
    }

    void Update()
    {
        // getting on snowmobile
        if (atSnowmobile)
        {
            if (Input.GetButtonDown("Interact") && ridingSnowmobile == false) // get on
            {
                shootingScript.gunEquipped = false;
                player.transform.parent = gameObject.transform; // set snowmobile to parent of player
                playerMovementScript.immobile = true;
                ridingSnowmobile = true;
            }
            else if (Input.GetButtonDown("Interact") && ridingSnowmobile == true) // get off
            {
                player.transform.parent = null; // set snowmobile to parent of player
                playerMovementScript.immobile = false;
                ridingSnowmobile = false;
            }
        }

        if (ridingSnowmobile)
        {
            player.transform.position = gameObject.transform.position;

            // movement
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            movement = new Vector3(horizontal * hMult, 0f, vertical * vMult);
            GetComponent<Rigidbody>().velocity = movement * moveSpeed;

            print(hMult);

            if (horizontal != 0 && hMult < 7f)
                hMult += .01f;
            if (vertical != 0 && vMult < 7f)
                vMult += .01f;
            else if (vertical == 0 && horizontal == 0)
            {
                hMult = 1f;
                vMult = 1f;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            atSnowmobile = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            atSnowmobile = false;
        }
    }
}
