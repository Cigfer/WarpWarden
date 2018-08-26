using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] songs;
    int currentSong = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            currentSong++;
            if (currentSong >= songs.Length)
            {
                GetComponent<AudioSource>().clip = songs[currentSong];
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
