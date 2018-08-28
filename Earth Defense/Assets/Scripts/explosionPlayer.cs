using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionPlayer : MonoBehaviour {

    public AudioClip[] splosion;
    public AudioSource splosionSource;

    void Start ()
    {
        PlayExplosion();
	}

    private AudioClip GetRandomClip()
    {
        return splosion[Random.Range(0, splosion.Length)];
    }

    void PlayExplosion()
    {
        splosionSource.clip = GetRandomClip();
        splosionSource.Play();
    }
    
}
