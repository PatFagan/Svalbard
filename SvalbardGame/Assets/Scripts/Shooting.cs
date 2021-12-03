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

    PlayerMovement playerMovementScript;
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        spawnPos = new Vector3(offsetX, offsetY, offsetZ);
        timer = 0;
    }

    void Update()
    {
        equipProgress.fillAmount = equipTimer / EQUIP_TIME; // displays the equip progress bar

        timer += Time.deltaTime; // timer

        if (Input.GetButtonDown("EquipGun") || Input.GetButtonUp("EquipGun")) // resets the equip button hold down timer
            equipTimer = 0f;

        if (Input.GetButton("EquipGun") && hammerPulled == false) // if gun isn't equipped, equip it
        {
            if (equipTimerLocked == false) // timer lock gives a brief break between equips, so you don't accidentally equip & re-equip at once
                equipTimer++;

            if (hammerPulled == false && equipTimer > EQUIP_TIME) // (can't unequip gun if hammer is pulled)
            {
                gunEquipped = !gunEquipped;
                StartCoroutine(EquipTimer());
            }
        }

        if (Input.GetButtonDown("Interact") && timer >= timeBetweenShots && gunEquipped) // press FIRE
        {
            if (GameObject.FindGameObjectWithTag("GunCursor")) // if cursor exists, spawn bullet
            {
                StartCoroutine(FireOne());
            }
            else if (!GameObject.FindGameObjectWithTag("GunCursor")) // if not, then spawn cursor
            {
                Instantiate(cursor, transform.position + spawnPos, Quaternion.identity);
                hammerPulled = true;
                playerMovementScript.immobile = hammerPulled; // make player immobile if hammer is pulled
            }
        }
    }

    IEnumerator FireOne() // fire bullet, destroy cursor
    {
        Instantiate(projectile, transform.position + spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        timer = 0;
        hammerPulled = false;
        playerMovementScript.immobile = hammerPulled; // make player immobile if hammer is pulled
        Destroy(GameObject.FindGameObjectWithTag("GunCursor"));
    }

    IEnumerator EquipTimer() // reset equip timer and start brief cooldown between equips
    {
        equipTimer = 0f;
        equipTimerLocked = true;
        yield return new WaitForSeconds(2f);
        equipTimerLocked = false;
    }
}