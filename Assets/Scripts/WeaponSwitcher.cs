using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    private int previousWeapon = 0;
    void Start()
    {
        setWeaponActive();
    }

    void Update()
    {
        previousWeapon = currentWeapon;
        processKeyInput();
        processScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            setWeaponActive();
        }
    }

    private void processScrollWheel()
    {

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon >= this.transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon--;
            
            if (currentWeapon < 0)
            {
                currentWeapon = this.transform.childCount - 1;
            }
        }

    }

    private void processKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
    }

    private void setWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in this.transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

}
