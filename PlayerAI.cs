using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {

	public GameObject PlayerCam;
	public static Vector3 playerPosition; 
	public static Vector3 playerRotation;
	public static int numKills = 0;
	// Use this for initialization
	void Start () {
		playerPosition = PlayerCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		playerRotation = transform.localEulerAngles;
		//print (playerPosition);
		playerPosition = new Vector3(PlayerCam.transform.position.x, 2.3f, PlayerCam.transform.position.z); 
		/*if (OVRInput.GetDown (OVRInput.Button.One)) {
			GameRestart ();
		}*/
	}
}
