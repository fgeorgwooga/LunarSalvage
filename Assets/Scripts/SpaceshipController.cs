﻿using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {
	
	public GameInfo gameInfo;
	public GameObject explosionPrefab;
	public InputParser inputParser;
	public ThrusterRenderer leftThruster;
	public ThrusterRenderer rightThruster;
	[SerializeField] public GameInfo gameInfo;
	[SerializeField] public GameObject explosionPrefab;

	[SerializeField] private bool inTakeOffZone = true;
	void OnStart()
	{
		
	}
	
	void FixedUpdate() {
		Vector3 force = new Vector3();
		if (inputParser.leftThrust > 0)
		{
			force += new Vector3(10, 20, 0);
		}
		if (inputParser.rightThrust > 0)
		{
			force += new Vector3(-10, 20, 0);
		}
		rigidbody2D.AddForce(force);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.name == "TakeOffZone" && inTakeOffZone != true) 
		{
			Debug.Log("Entered SaveZone");
			inTakeOffZone = true; 
			return;
		} 

		
	}

	void OnTriggerExit2D (Collider2D other) {
		
		if (other.gameObject.name == "TakeOffZone" && inTakeOffZone != false) 
		{ 
			Debug.Log("Exited SaveZone");
			inTakeOffZone = false; 
			return;
		} 
		
	}


	void OnCollisionEnter2D (Collision2D other)
	{

		if (inTakeOffZone == true) return;

		gameInfo.gameStatus = 3;	
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}



}
