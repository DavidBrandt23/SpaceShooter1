using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    public GameObject healthText;
    public GameObject weaponText;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int currentHP = 0;
        string currentWeapon = "";
        if (player != null)
        {
            currentHP= player.GetComponent<Health>().getWholeCurrentHP();
            currentWeapon = player.GetComponent<PlayerWeaponControl>().getCurrentWeapon().DisplayName;
        }
        healthText.GetComponent<Text>().text = "HP: " + currentHP;
        weaponText.GetComponent<Text>().text = "Weapon: " + currentWeapon;

    }
}
