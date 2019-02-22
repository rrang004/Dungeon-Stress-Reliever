using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {

	public static GameObject playerSword;

	// Use this for initialization
	void Start () {
		playerSword =  GameObject.Find("Medieval Sward");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
