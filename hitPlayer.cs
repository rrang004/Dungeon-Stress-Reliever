using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour {
	//int trigger = 0;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider target){
		if(target.gameObject.name == "crawler1"){//sword.playerSword){
			print ("hit");
			//trigger = 1;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
