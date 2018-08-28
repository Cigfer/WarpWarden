using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpMap : MonoBehaviour {

    public GameObject bigmap;
    public GameObject minimap;

	void Start ()
    {
        bigmap.SetActive(false);
        minimap.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            bigmap.SetActive(true);
            minimap.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Cursor.visible = false;
            bigmap.SetActive(false);
            minimap.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
