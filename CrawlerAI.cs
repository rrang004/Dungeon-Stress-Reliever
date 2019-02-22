using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrawlerAI : MonoBehaviour {
	float speed;

	public GameObject[] crawlers;
	public float[] distanceToPlayers = new float[] {1000f, 1000f,1000f, 1000f,1000f, 1000f,1000f, 1000f, 1000f, 1000f};
	public float distanceToPlayer;
	public bool FollowFlag = false;
	public bool[] FollowFlags = new bool[] { false, false, false, false, false, false, false, false, false, false};
	public bool[] isSpawned = new bool[] { true, false, false, false, false, false, false, false, false, false};
	System.Random Rnd = new System.Random();
	Vector3[] locations = new [] {
		new Vector3 (-67.13327f, 1.5f, -55.5085f), //a
		new Vector3 (-68.68f, 1.5f, 15.04f), //a
		new Vector3 (-58.63f, 1.5f, 65.96f), //a
		new Vector3 (8.2365f, 1.5f, 67.02f), //a
		new Vector3 (54.045f, 1.5f, 66.355f), //a
		new Vector3 (57.588f, 1.5f, 15.887f), //a
		new Vector3 (70.131f, 1.5f, -30.1f), //a
		new Vector3 (72.62f, 1.5f, -72.17f), //a
		new Vector3 (-65.861f, 1.5f, 27.8131f),
		new Vector3 (69.19882f, 1.5f, -25.56068f),
	};

	public float[] speeds = new float[] {0.015f,0.018f,0.023f,0.027f,0.030f,0.033f,0.038f,0.040f,0.045f,0.47f};
	public Vector3[] positions = new Vector3[] {
		new Vector3(1.0f, 0,1.0f),
		new Vector3(2.0f, 0,0.5f),//PlayerAI.playerPosition.y, PlayerAI.playerPosition.z),
		new Vector3(3.0f,0,1.5f),//PlayerAI.playerPosition.y, PlayerAI.playerPosition.z),
		new Vector3(4.0f,0,2.0f),
		new Vector3(5.0f,0,2.5f),
		new Vector3(-1.0f,0,3.0f),
		new Vector3(-2.0f,0,3.3f),
		new Vector3(-3.0f,0,3.7f),
		new Vector3(-4.0f,0,4.0f),
		new Vector3(-5.0f,0,4.3f)

	};

	Vector3 shadowRealm = new Vector3 (-4.311f, 10f, 395.0932f); //this is the location crawlers 2-10 will be at at the start of the game

	// Use this for initialization
	void Start () {
		//crawler1.transform.position = locations[Rnd.Next(0,5)];
		crawlers = new GameObject[10];
		for (int i = 1; i <= 10; i++) {
			crawlers [i-1] = new GameObject ();
		}

				
		crawlers[0] = GameObject.FindGameObjectWithTag ("crawler1");
		crawlers[1] = GameObject.FindGameObjectWithTag ("crawler2");
		crawlers[2] = GameObject.FindGameObjectWithTag ("crawler3");
		crawlers[3] = GameObject.FindGameObjectWithTag ("crawler4");
		crawlers[4] = GameObject.FindGameObjectWithTag ("crawler5");
		crawlers[5] = GameObject.FindGameObjectWithTag ("crawler6");
		crawlers[6] = GameObject.FindGameObjectWithTag ("crawler7");
		crawlers[7] = GameObject.FindGameObjectWithTag ("crawler8");
		crawlers[8] = GameObject.FindGameObjectWithTag ("crawler9");
		crawlers[9] = GameObject.FindGameObjectWithTag ("crawler10");
	

		//crawler1.transform.position = locations [0];
		crawlers[0].transform.position = locations[0];
		for (int i = 1; i < 10; i++) {
			crawlers[i].transform.position = shadowRealm;
		}
		//print (this.transform.position);
	}
		
	void Update () {
		TrackPlayer ();
		SwitchPosition ();
		MirrorCrawler ();
		SpawnCrawler ();
		}


	void TrackPlayer(){
		/*
		distanceToPlayer = Vector3.Distance (PlayerAI.playerPosition, crawler1.transform.position);
	//	print (distanceToPlayer);
		if (distanceToPlayer <= 40)
			FollowFlag = true;

		if (FollowFlag) {
			Vector3 targetDir = PlayerAI.playerPosition - crawler1.transform.position;
			float step = 5 * Time.deltaTime;
			crawler1.transform.position = Vector3.MoveTowards (crawler1.transform.position, PlayerAI.playerPosition, .05f);
		}
		*/

		//ARRAY VERSION
		//array is not ordered with the ones in the order we want
		for (int i = 0; i < 10; i++) {
			distanceToPlayers[i] = Vector3.Distance(PlayerAI.playerPosition, crawlers[i].transform.position);
		}

		for (int i = 0; i < 10; i++) {
			if (distanceToPlayers [i] <= 40)
				FollowFlags [i] = true;
		}

		for (int i = 0; i < 10; i++) {
			if (FollowFlags[i]){
				Vector3 targetDir = PlayerAI.playerPosition - crawlers[i].transform.position;
				float step = 5 * Time.deltaTime;
				//PlayerAI.playerPosition
				crawlers [i].transform.position = Vector3.MoveTowards (crawlers [i].transform.position, PlayerAI.playerPosition -  positions[Rnd.Next (0, 10)], speeds[9 - i]); 
			}
		}
	}

	void SwitchPosition(){
		//if (hitCrawler.trigger == 1) {
		//	crawler1.transform.position = locations [Rnd.Next (0, 1)];
		//	hitCrawler.trigger = 0;
		//}

		//the below code should work for any crawler
		if (hitCrawler.trigger > 0) {
			crawlers [hitCrawler.trigger - 1].transform.position = locations [Rnd.Next (0, 10)];
			hitCrawler.trigger = 0;
		}
	}

	void MirrorCrawler(){
		//print (PlayerAI.playerRotation);
		for (int i = 0; i < 10; i++) {
			crawlers[i].transform.eulerAngles = new Vector3 (PlayerAI.playerRotation.z * -1.0f, PlayerAI.playerRotation.y + 270.0f, PlayerAI.playerRotation.z * -1.0f);
		}
	}

	void SpawnCrawler(){
		for(int i = 1; i < 10; i++){
			if(!isSpawned[i] && PlayerAI.numKills == i)
				crawlers[i].transform.position = locations[i];
		}
	}
		
}
	


