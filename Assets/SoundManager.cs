using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip errorSound;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		
	}

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();

    }

    public void GenericErrorSound()
    {
        audioSource.clip = errorSound;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
