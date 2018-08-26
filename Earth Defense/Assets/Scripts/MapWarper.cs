using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapWarper : MonoBehaviour {

    public WarpManager warpManager;

    public int cubby;

    public GameObject player;

    //public ParticleSystem effect;
    //bool isPlayed = false;

	public void MapWarp ()
    {
        player.transform.position = warpManager.tpLocations[cubby].transform.position;
        player.transform.rotation = warpManager.tpLocations[cubby].transform.rotation;
        //StartCoroutine("WarpEffect");

    }
    
    /*
    IEnumerator WarpEffect()
    {
        effect.Play();

        yield return new WaitForSeconds(.5f);

        effect.Stop();
    }*/
}
