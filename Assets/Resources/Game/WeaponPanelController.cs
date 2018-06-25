using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanelController : MonoBehaviour {

    public GameObject pistolPanel;
    public GameObject assaultRiflePanel;
    public Text ammo;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeWeapon(int weapon, float actualAmmo, float actualCharger)
    {
        Color color = pistolPanel.GetComponent<Image>().color;
        // 1 assault
        if (weapon == 1)
        {
            color.a = .5f;
            pistolPanel.GetComponent<Image>().color = color;
            color.a = 1f;
            assaultRiflePanel.GetComponent<Image>().color = color;
        }
        //2 pistol
        if (weapon == 2)
        {      
            color.a = .5f;
            assaultRiflePanel.GetComponent<Image>().color = color;
            color.a = 1f;
            pistolPanel.GetComponent<Image>().color = color;


        }
        updateAmmoPanel(actualAmmo, actualCharger);
    }

    public void updateAmmoPanel(float actualAmmo, float actualCharger)
    {
        ammo.text = actualCharger + "/" + actualAmmo;
    }
}
