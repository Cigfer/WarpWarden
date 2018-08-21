using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepSwitch : MonoBehaviour {

    public int currentWeapon = 0;

    public Weapon_Pistol pistolMotor;
    public Weapon_SMG smgMotor;
    public Weapon_Heavy heavyMotor;
    public Weapon_Sniper sniperMotor;

    void Start ()
    {
        SelectWeapon();
	}
	
	void Update ()
    {
        int previousSelectedWeapon = currentWeapon;

        Debug.Log(pistolMotor.isReloading);

        if (pistolMotor.isReloading == false)
        {
            //above 0 is scroll up, below 0 is scroll down
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                //wraps around if more than childcount
                if (currentWeapon >= transform.childCount - 1)
                    currentWeapon = 0;
                else
                    currentWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon <= 0)
                    currentWeapon = transform.childCount - 1;
                else
                    currentWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                currentWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                currentWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                currentWeapon = 3;
            }

            if (previousSelectedWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }

        if (smgMotor.isReloading == false)
        {

            //above 0 is scroll up, below 0 is scroll down
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                //wraps around if more than childcount
                if (currentWeapon >= transform.childCount - 1)
                    currentWeapon = 0;
                else
                    currentWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon <= 0)
                    currentWeapon = transform.childCount - 1;
                else
                    currentWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                currentWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                currentWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                currentWeapon = 3;
            }

            if (previousSelectedWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }

        if (heavyMotor.isReloading == false)
        {
            //above 0 is scroll up, below 0 is scroll down
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                //wraps around if more than childcount
                if (currentWeapon >= transform.childCount - 1)
                    currentWeapon = 0;
                else
                    currentWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon <= 0)
                    currentWeapon = transform.childCount - 1;
                else
                    currentWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                currentWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                currentWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                currentWeapon = 3;
            }

            if (previousSelectedWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }

        if (sniperMotor.isReloading == false)
        {
            //above 0 is scroll up, below 0 is scroll down
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                //wraps around if more than childcount
                if (currentWeapon >= transform.childCount - 1)
                    currentWeapon = 0;
                else
                    currentWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon <= 0)
                    currentWeapon = transform.childCount - 1;
                else
                    currentWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                currentWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                currentWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                currentWeapon = 3;
            }

            if (previousSelectedWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }

        else
        {
            Debug.Log("igfgf");
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        // for each transform (gun) that is a child under current Transform (Weapon Holder), named "weapon"
        foreach (Transform weapon in transform)
        {
            //if i (inputted number) matches current weapon, make it active, everything else is not active
            if (i == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
            //loops over all of the weapons
        }
    }
}
