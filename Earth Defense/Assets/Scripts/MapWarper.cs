using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapWarper : MonoBehaviour {

    public WarpManager warpManager;

    public int cubby;

    public GameObject player;

	public void MapWarp ()
    {
        player.transform.position = warpManager.tpLocations[cubby].transform.position;
        player.transform.rotation = warpManager.tpLocations[cubby].transform.rotation;
    }
}
