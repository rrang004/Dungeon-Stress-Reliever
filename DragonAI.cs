using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragonAI : MonoBehaviour {

	public GameObject dragon;
	public float distanceToPlayer;
	public bool FollowFlag = false;
	System.Random Rnd = new System.Random();
	Vector3[] locations = new [] {
		new Vector3 (-67.13327f, 2.3f, -55.5085f),
		new Vector3 (-65.861f, 2.3f, 27.8131f),
		new Vector3 (69.19882f, 2.3f, -25.56068f),
		new Vector3 (-8.743721f, 2.3f, -27.6f),
		new Vector3 (7.2911f, 2.3f, 67.2789f)
	};
	Rigidbody dragonRigidBody;
	//dragonRigidBody = dragon.
	// Use this for initialization
	void Start () {
		dragon.transform.position = locations [0];//Rnd.Next(0,5)];
		print("s");
	}
	
	// Update is called once per frame
	/*void FixedUpdate(){
		dragonRigidBody = dragon.GetComponent<Rigidbody>;	
		Vector3 dragonVelocity = transform.up;
		transform.up = dragonRigidBody.velocity;
		print ("velocity: " + dragonVelocity);

	}*/
	void Update () {
		TrackPlayer ();

		//transform.LookAt (new Vector3(PlayerAI.playerPosition.x, dragon.transform.position.y,PlayerAI.playerPosition.z), Vector3.up);
		//float ang = SignedAngleBetween (PlayerAI.playerPosition - dragon.transform.position, dragon.transform.forward, new Vector3(0,1,0));
		float distance = Vector3.Distance(PlayerAI.playerPosition, dragon.transform.position);
		if (distance > 1){
			Vector3 relativePosition = PlayerAI.playerPosition - dragon.transform.position;
			relativePosition.z = 0;
			Vector3 dragonForward2D = dragon.transform.forward;//dragon.transform.eulerAngles;
			dragonForward2D.z = 0;
			float ang = Vector3.Angle(relativePosition, dragonForward2D);
			//Vector3 dragonVelocity = transform.up;
			//dragonVelocity = 

			//print("dragon.transform.forward: " + dragon.transform.forward);
			//transform.Rotate (0, -ang, 0);
			Vector3 newYDirection = Vector3.Cross(relativePosition, dragonForward2D).normalized;
			//print ("TestTestTest: " + newYDirection);
			print (ang);
			if(newYDirection.z >= 0)
				if( ang > 1 )
					transform.RotateAround (dragon.transform.position, Vector3.up, -ang);
			else if(newYDirection.z < 0)
				if( ang > 1 )
					transform.RotateAround (dragon.transform.position, Vector3.up, ang);
		}
	}

	void TrackPlayer(){
		distanceToPlayer = Vector3.Distance (PlayerAI.playerPosition, dragon.transform.position);
		//print (distanceToPlayer);
		if (distanceToPlayer <= 40)
			FollowFlag = true;
		
		if (FollowFlag && distanceToPlayer >= 14) {
			dragon.transform.position = Vector3.MoveTowards (dragon.transform.position, PlayerAI.playerPosition, .05f);
		}
	}

	float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n){
		// angle in [0,180]
		float angle = Vector3.Angle(a,b);
		float sign = Mathf.Sign(Vector3.Dot(n,Vector3.Cross(a,b)));

		// angle in [-179,180]
		float signed_angle = angle * sign;

		// angle in [0,360] (not used but included here for completeness)
		//float angle360 =  (signed_angle + 180) % 360;

		return signed_angle;
	}

}


