using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoapAgent : MonoBehaviour
{
    public string currentAnimation;

    public bool hasAxe;
    public bool isHungry;

    float hungerTimer;

    void Start()
    {
        hasAxe = false;
        isHungry = true;

        hungerTimer = 0;
    }

    void Update()
    {
        // isHungry
        hungerTimer--;
        if (hungerTimer < 0)
            isHungry = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Food")
        {
            print("eating...");
            hungerTimer = 5000f;
            isHungry = false;
        }
        if (collider.gameObject.tag == "Axe")
        {
            print("picking up axe...");
            hasAxe = true;
        }
        if (collider.gameObject.tag == "Wood")
        {
            print("chopping wood...");
            hasAxe = false;
        }
    }
}