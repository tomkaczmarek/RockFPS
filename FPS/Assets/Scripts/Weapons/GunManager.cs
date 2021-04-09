using Assets.Scripts.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text weaponName;
    public Text ammoInfo;
   
    void Start()
    {
        SetWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        int weaponIndex = 0;
        int activeIndex = 0;
        int nextIndex = 0;
        foreach( Transform weapons in transform)
        {
            if (weapons.gameObject.activeSelf)
            {
                activeIndex = weaponIndex;
                weapons.gameObject.SetActive(false);
            }
                
            if (activeIndex == transform.childCount - 1)
                nextIndex = 0;
            else
                nextIndex = activeIndex + 1;
            weaponIndex++;
        }
        SetWeapon(nextIndex);
    }

    private void SetWeapon(int index)
    {
        GameObject weapon = transform.GetChild(index).gameObject;
        weapon.SetActive(true);
        AbstractWeapons currentWeapon = WeaponFactory.GetWeapon(weapon.gameObject.name, transform.gameObject);
        weaponName.text = currentWeapon.GetName();
        ammoInfo.text = currentWeapon.GetAmmoInfo();
    }
}
