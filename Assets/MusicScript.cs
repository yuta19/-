﻿using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	public AudioClip audioClip;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X) == true) {
			//Toriger
			audioSource.Play ();
		}
	
	}
}
