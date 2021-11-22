using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorMenu : MonoBehaviour
{
    public GameObject vendorMenu;
    bool vendorMenuBool = false;
    public Button vendorButton;

    void Start()
    {
        //vendorMenu = GameObject.Find("VendorMenu");
        vendorButton.onClick.AddListener(OpenVendorMenu);
    }

    public void OpenVendorMenu()
    {
        vendorMenuBool = !vendorMenuBool;
        vendorMenu.SetActive(vendorMenuBool);
    }
}