using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY, offsetZ;
    public GameObject projectile, cursor;
    Vector3 spawnPos;
    float timer;

    public bool gunEquipped = false;
    public bool hammerPulled = false;

    float equipTimer = 0f;

    float EQUIP_TIME = 300f;
    public Image equipProgress;
    bool equipTimerLocked = false;

    void Start()
    {
        spawnPos = new Vector3(offsetX, offsetY, offsetZ);
        timer = 0;
    }

    void Update()
    {
        equipProgress.fillAmount = equipTimer / EQUIP_TIME;

        timer += Time.deltaTime; // timer

        if (Input.GetButtonDown("EquipGun") || Input.GetButtonUp("EquipGun"))
            StartCoroutine(EquipTimer());

        if (Input.GetButton("EquipGun") && hammerPulled == false) // if gun isn't equipped, equip it
        {
            if (equipTimerLocked == false)
                equipTimer++;

            if (hammerPulled == false && equipTimer > EQUIP_TIME)
            {
                gunEquipped = !gunEquipped;
                StartCoroutine(EquipTimer());
            }
        }

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

    IEnumerator EquipTimer()
    {
        equipTimer = 0f;
        equipTimerLocked = true;
        yield return new WaitForSeconds(2f);
        equipTimerLocked = false;
    }
}