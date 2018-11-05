using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponControl : MonoBehaviour
{
    public string[] weaponKeys = 
    {
        "SelectWeapon1",
        "SelectWeapon2"
    };
    public List<PlayerWeapon> availableWeapons;
    public int currentWeapon = 0;

    void Start()
    {
    }

    public void shootPressed()
    {
        PlayerWeapon currentWeapon = getCurrentWeapon();
        currentWeapon.shootPressed();
    }

    public void shootNotPressed()
    {
        PlayerWeapon currentWeapon = getCurrentWeapon();
        currentWeapon.shootNotPressed();
    }

    public PlayerWeapon getCurrentWeapon()
    {
        return availableWeapons[currentWeapon];
    }
   
    public void stopCurrentWeapon()
    {
        getCurrentWeapon().stopWeapon();
    }

    private void changeWeapon(int newWeaponIndex)
    {
        stopCurrentWeapon();
        currentWeapon = newWeaponIndex;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < weaponKeys.Length; i++)
        {
            if (Input.GetButtonDown(weaponKeys[i]))
            {
                changeWeapon(i);
            }
        }
    }
}
