using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepSwitch : MonoBehaviour {

    public int currentWeapon = 0;

    public Weapon_Pistol PistolMotor;
    public Weapon_Pistol SMGMotor;
    public Weapon_Pistol HeavyMotor;
    public Weapon_Pistol SniperMotor;

    public Vector3 originalPosition;
    public Vector3 aimPosition;
    public float adsSpeed = 1f;

    public Vector3[] aimPositions;

    float aimTimer = 0f;
    public float recoilValue = 0f;

    public Camera thisCamera;

    public float[] zoom;
    int normal = 60;
    float smooth = 10;

    void Start ()
    {
        SelectWeapon();

        thisCamera = transform.parent.GetComponent<Camera>();
	}
	
	void Update ()
    {
        int previousSelectedWeapon = currentWeapon;

        bool isReloading = PistolMotor.isReloading || SMGMotor.isReloading || HeavyMotor.isReloading || SniperMotor.isReloading;

        if (isReloading == false)
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

        if (Input.GetButton("Fire2") && !isReloading)
        {

            transform.localPosition = Vector3.Slerp(transform.localPosition, aimPositions[currentWeapon], aimTimer * adsSpeed);
            thisCamera.fieldOfView = Mathf.Lerp(thisCamera.fieldOfView, zoom[currentWeapon], Time.deltaTime * smooth);

            aimTimer += Time.deltaTime;
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, originalPosition, aimTimer * adsSpeed);
            thisCamera.fieldOfView = Mathf.Lerp(thisCamera.fieldOfView, normal, Time.deltaTime * smooth);

            aimTimer -= Time.deltaTime;
        }

        aimTimer = Mathf.Clamp(aimTimer, 0, 1);
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

    public void recoil()
    {
        recoilValue = 1f;


    }
}
