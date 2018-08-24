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
            bigmap.SetActive(true);
            minimap.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            bigmap.SetActive(false);
            minimap.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
