using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour {

	public Text scoreText;
	// Use this for initialization
	//public GameObject textBox = GameObject.FindWithTag("textBox");

	//scoreText = GetComponent<scoreTxt> ();
	void Start () {
		
		scoreText.text = "changed";
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = PlayerAI.numKills.ToString();
	}
}
