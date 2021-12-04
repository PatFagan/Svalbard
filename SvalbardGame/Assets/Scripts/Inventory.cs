using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;
    public Image healthBar;
    bool inventoryMenuBool = false;

    // items
    int apples;
    int wood;
    // stats
    public float health;
    int warmth;
    int hunger;
    int thirst;
    int energy;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryMenuBool = !inventoryMenuBool;
            inventoryMenu.SetActive(inventoryMenuBool);
        }

        //print(health);
        healthBar.fillAmount = health;
    }
}
