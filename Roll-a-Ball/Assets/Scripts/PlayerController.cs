﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private int count;
	private Rigidbody rb;

	public Text winText;
	public Text countText;
	public float speed;
	
	void Start() {
		
	rb = GetComponent<Rigidbody>();
	count = 0;
	SetCountText();
	winText.text = "";
	}

	// For physics updates
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.AddForce (movement * speed);
		
	}

    void OnTriggerEnter(Collider other) {
	    
    	if (other.gameObject.CompareTag("Pick Up")) {
    		other.gameObject.SetActive (false);
    		count ++;
		SetCountText();
    	}	  
    }	

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 10) {
			winText.text = "YOU WIN!";
		}
	}
}
