using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDragon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider target){
		print ("wow");
		if(target.gameObject == sword.playerSword){
			print ("lovely");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
