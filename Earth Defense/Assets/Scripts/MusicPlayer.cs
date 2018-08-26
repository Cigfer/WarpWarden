using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] songs;
    public AudioSource musicSource;

    // Use this for initialization
    void Start () {
        musicSource.loop = false;
	}

    private AudioClip GetRandomClip()
    {
        return songs[Random.Range(0, songs.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = GetRandomClip();
            musicSource.Play();
            Debug.Log(songs.Length);
        }

    }
}
