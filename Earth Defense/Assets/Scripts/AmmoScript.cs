using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoScript : MonoBehaviour {

    public Weapon_Pistol gun;
    public TextMeshProUGUI textObject;
	
	void Start ()
    {
        textObject = GetComponent<TextMeshProUGUI>();
	}
	
	
	void Update ()
    {
        textObject.text = gun.currentAmmo + " / " + gun.maxAmmo;
	}
}
