using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour {

    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    //public AudioSource audioSource;


	void Start ()
    {
        StartCoroutine(PlayScene());
	}

    IEnumerator PlayScene()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        //audioSource.Play();
    }
}
