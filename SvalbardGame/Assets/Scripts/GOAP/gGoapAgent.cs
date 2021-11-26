using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoapAgent : MonoBehaviour
{
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
            hungerTimer = 500f;
            isHungry = false;
        }
        else if (collider.gameObject.tag == "Axe")
        {
            hasAxe = true;
        }
        else if (collider.gameObject.tag == "Wood")
        {
            hasAxe = false;
        }
    }
}
