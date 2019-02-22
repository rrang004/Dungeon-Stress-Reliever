using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource asour = GetComponent<AudioSource>();
		asour.volume = 0.0f;
		asour.Play();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
