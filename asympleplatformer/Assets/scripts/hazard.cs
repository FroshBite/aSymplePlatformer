﻿using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
	bool isGrabbed = false, isFlying = false, walk =false;
	Vector3 offset, startPoint;
	float walkVel;
	public float speed=1.0f, gravity=1.0f;
	public Transform player1;
	
	void Start () {
<<<<<<< HEAD

			startPoint = new Vector3(55, 2,1);
		offset = player1.transform.position-startPoint;
		walk = false;
		startPoint = transform.position;
		ResetPosition();
=======
		startPoint = new Vector3(55, 75,1);
		offset = player1.transform.position-startPoint;
		walk = false;
		ResetPosition();
		rigidbody2D.gravityScale = 0;
		
>>>>>>> origin/master
	}
	
	
	void ResetPosition(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		
		walk = false;
		isGrabbed = false;
		isFlying = false;
<<<<<<< HEAD
		transform.position = player1.transform.position- offset;
		transform.localScale = new Vector3(25,25,0);
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			this.isGrabbed = false;
			this.isFlying = false;
			this.rigidbody2D.velocity = Vector2.zero;
			ResetPosition();
		}
=======
		
		transform.position = player1.transform.position- offset;
		transform.localScale = new Vector3(25,25,0);
		//this.collider2D.enabled = false;
		print (startPoint);
		
>>>>>>> origin/master
	}
	
	void FixedUpdate(){
		if (walk) {
<<<<<<< HEAD
		if(walkVel>0){
				transform.localScale = new Vector3(-30,30,30);
			}else{
				transform.localScale = new Vector3(30,30,30);
			}
			rigidbody2D.velocity = new Vector2 (speed*walkVel,rigidbody2D.velocity.y);
			
=======
>>>>>>> origin/master
			
			if(walkVel>0){
				transform.localScale = new Vector3(-35,35,0);
				rigidbody2D.velocity = new Vector2 (speed,rigidbody2D.velocity.y-gravity);
			}
			else{
				transform.localScale = new Vector3(35,35,0);
				rigidbody2D.velocity = new Vector2 (-speed,rigidbody2D.velocity.y-gravity);
			}
		}
		
		if (!walk && !isGrabbed && !isFlying) {
			transform.position = player1.transform.position- offset;
			
		}
		
		if(isGrabbed){ //moves the skeleton along with the mouse
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			this.transform.position = worldPosition;
		}
		if (isFlying) {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y - gravity);
			transform.localScale = new Vector3(35,35,0);
		}
		
		
		if (rigidbody2D.position.y < -50) {
			ResetPosition ();
		}
<<<<<<< HEAD
		//if(isFlying)
		//		rigidbody2D.velocity = new Vector2 (speed*walkVel,-gravity);
			
			//if(!isFlying){
			//	this.rigidbody2D.gravityScale = 0;
			//} else {
			//	this.rigidbody2D.gravityScale = gravity;
			
			//}
			
			
=======
		
		
>>>>>>> origin/master
	}
	
	void OnMouseDown(){
		isGrabbed = true;
		isFlying = false;
		walk = false;
		this.collider2D.enabled = false;
		transform.localScale = new Vector3(25,25,0);
		
	}
	
	void OnMouseUp(){
		
		if(isGrabbed){
			if(Vector2.Distance(player1.position, this.transform.position)<5){
				this.transform.position = player1.position + new Vector3(5, 0, 0);
			}
			
			isGrabbed = false;
			isFlying = true;
			this.collider2D.enabled = true;
			walkVel = (player1.position.x)-this.transform.position.x;
			
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.name != "Player1") {
			walk = true;
			isFlying=false;
		}
		
	}
}
