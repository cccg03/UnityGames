using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps the camera transform centered on the ball 

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 offset;
	
	void Start () {
		
		offset = transform.position - player.transform.position;	
	
	}
	
// Updates frame only after everything has been rendered (hence the "Late")	
	
	void LateUpdate () {
		
		transform.position = player.transform.position + offset;
	
	}

}
