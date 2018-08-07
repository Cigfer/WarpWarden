using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour {
   
    public GameObject currentCubby;
    public GameObject player;
    public GameObject[] tpLocations;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("[1]"))
        {
            player.transform.position = tpLocations[0].transform.position;
        }
        if (Input.GetKeyDown("[2]"))
        {
            player.transform.position = tpLocations[1].transform.position;
        }
        if (Input.GetKeyDown("[3]"))
        {
            player.transform.position = tpLocations[2].transform.position;
        }
        if (Input.GetKeyDown("[4]"))
        {
            player.transform.position = tpLocations[3].transform.position;
        }
        if (Input.GetKeyDown("[5]"))
        {
            player.transform.position = tpLocations[4].transform.position;
        }
    }
}
