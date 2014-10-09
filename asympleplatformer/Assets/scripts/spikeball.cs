using UnityEngine;
using System.Collections;

public class spikeball : MonoBehaviour {
	
	bool isGrabbed = false, isFlying = false;
	Vector3 offset, startPoint;
	public float gravity=1.0f;
	public Transform player1;
	
	void Start () {
		startPoint = new Vector3(60,75,0);
		offset = player1.transform.position-startPoint;
		ResetPosition();
	}
	
	
	void ResetPosition(){
		rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.angularVelocity = 0;
		rigidbody2D.gravityScale = 0;
		
		isGrabbed = false;
		isFlying = false;
		
		transform.position = player1.transform.position- offset;
		transform.rotation = Quaternion.identity;
		transform.localScale = new Vector3(23,23,0);
		
	}
	
	void FixedUpdate(){
		
		if (!isGrabbed && !isFlying) {
			transform.position = player1.transform.position- offset;
			
		}
		
		if(isGrabbed){ //moves the skeleton along with the mouse
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			this.transform.position = worldPosition;
		}
		if (isFlying) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y - gravity);
			transform.localScale = new Vector3(29,29,0);
		}
		
		if (rigidbody2D.position.y < -50) {
			ResetPosition ();
		}

		if (Input.GetKeyDown (KeyCode.R)){
			ResetPosition();
		}
		
	}
	
	void OnMouseDown(){
		isGrabbed = true;
		isFlying = false;
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
			
		}
	}
}