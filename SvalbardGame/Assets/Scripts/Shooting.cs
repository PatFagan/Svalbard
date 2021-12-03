using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY, offsetZ;
    public GameObject projectile, cursor;
    Vector3 spawnPos;
    float timer;

    public bool gunEquipped = false;
    public bool hammerPulled = false;

    void Start()
    {
        spawnPos = new Vector3(offsetX, offsetY, offsetZ);
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; // timer

        if (Input.GetButtonDown("EquipGun")) // if gun isn't equipped, equip it
            gunEquipped = !gunEquipped;

        if (Input.GetButtonDown("Interact") && timer >= timeBetweenShots && gunEquipped)
        {
            if (GameObject.FindGameObjectWithTag("GunCursor")) // if cursor exists, spawn bullet
            {
                StartCoroutine(FireOne());
            }
            else if (!GameObject.FindGameObjectWithTag("GunCursor")) // spawn cursor
            {
                Instantiate(cursor, transform.position + spawnPos, Quaternion.identity);
                hammerPulled = true;
            }
        }
    }

    IEnumerator FireOne()
    {
        Instantiate(projectile, transform.position + spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        timer = 0;
        hammerPulled = false;
        Destroy(GameObject.FindGameObjectWithTag("GunCursor"));
    }
}