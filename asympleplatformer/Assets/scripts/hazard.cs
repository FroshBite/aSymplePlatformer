using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
	bool isGrabbed = false, isFlying = false, walk =false;
	Vector3 offset, startPoint;
	float walkVel;
	public float speed=1.0f, gravity=1.0f;
	public Transform player1;
	
	void Start () {
		startPoint = new Vector3(55, 75,1);
		offset = player1.transform.position-startPoint;
		walk = false;
		ResetPosition();
		rigidbody2D.gravityScale = 0;
		
	}
	
	
	void ResetPosition(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		
		walk = false;
		isGrabbed = false;
		isFlying = false;
		
		transform.position = player1.transform.position- offset;
		transform.localScale = new Vector3(25,25,0);
		//this.collider2D.enabled = false;
		print (startPoint);
		
	}
	
	void FixedUpdate(){
		if (walk) {
			isFlying=false;
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