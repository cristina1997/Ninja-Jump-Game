using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    // Source code adapted from:
    // - https://www.youtube.com/watch?v=8pFlnyfRfRc
    public static AudioClip jumpSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        jumpSound = Resources.Load<AudioClip>("Jump");

        audioSrc = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void PlaySound (string clip)
    {
        if (clip == "Jump")
        {
            audioSrc.PlayOneShot(jumpSound);
        }
    }
}
