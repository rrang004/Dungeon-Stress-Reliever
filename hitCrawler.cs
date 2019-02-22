using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCrawler : MonoBehaviour {

	// Use this for initialization
	public static int trigger = 0;
	System.Random Rnd = new System.Random();

	void Start () {
	}

	//void OnTriggerEnter(Collider target){

	//	if(target.gameObject.name == "Medieval Sward"){
	//		print ("hit");
	//		PlayerAI.numKills += 1;
	//		print ("numKills = " + PlayerAI.numKills);
	//		trigger = 1;
//		}
//	}
	void OnTriggerEnter(Collider target){

		if(target.gameObject.name == "Medieval Sward"){
			print ("hit 1");
			PlayerAI.numKills += 1;
			print ("numKills = " + PlayerAI.numKills);
			trigger = 1;
		}
	}	// Update is called once per frame
	void Update () {
	}
}
