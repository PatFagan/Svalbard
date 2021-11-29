using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    float timer;
    PlayerMovement playerMovementScript;
    ParticleSystem ps;
    void Start()
    {
        timer = 500f;
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //var weather = ps.main;
        var em = ps.emission;

        //weather.startDelay = 0f;
        //print(timer);
        timer--;

        if (timer < 0f)
        {
            em.enabled = false;
        }
        else
        {
            em.enabled = true;
        }
    }
}
