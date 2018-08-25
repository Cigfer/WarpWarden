using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload_Indicator : MonoBehaviour {

    public GameObject reloadUI;
    public GameObject crosshair;
    public Weapon_Pistol PistolMotor;
    public Weapon_Pistol SMGMotor;
    public Weapon_Pistol HeavyMotor;
    public Weapon_Pistol SniperMotor;

    void Update ()
    {
        bool isReloading = PistolMotor.isReloading || SMGMotor.isReloading || HeavyMotor.isReloading || SniperMotor.isReloading;

        if (isReloading)
        {
            reloadUI.SetActive(true);
            crosshair.SetActive(false);
        }
        else
        {
            reloadUI.SetActive(false);
            crosshair.SetActive(true);
        }
    }
}
