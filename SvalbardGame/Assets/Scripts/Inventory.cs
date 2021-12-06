using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;
    public Image healthBar;
    bool inventoryMenuBool = false;

    public GameObject lootFeed;
    public Dictionary<string, int> items = new Dictionary<string, int>();

    void Start()
    {
        items.Add("Apples", 0);
        items.Add("Logs", 0);
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryMenuBool = !inventoryMenuBool;
            inventoryMenu.SetActive(inventoryMenuBool);
        }
    }

    public void GainItem(string name, int amount)
    {

    }
}
