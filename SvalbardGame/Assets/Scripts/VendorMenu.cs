using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorMenu : MonoBehaviour
{
    public GameObject vendorMenu;
    bool vendorMenuBool = true;
    public Button vendorButton;

    void Start()
    {
        vendorButton.onClick.AddListener(OpenVendorMenu);
    }

    public void OpenVendorMenu()
    {
        //vendorMenuBool = !vendorMenuBool;
        print("barter");
        vendorMenu.SetActive(vendorMenuBool);
    }
}