using UnityEngine;
using System.Collections;

public class spikeball : MonoBehaviour {
	//User modifyable variables
	public int hazardID=0, respawnTimer=0; //respawn timer should always be above 0
	public float gravity=1.0f;
	public Transform player1;
	
	bool isGrabbed = false, isFlying = false;
	Vector3 offset, startPoint;
	float startTime;
	
	void ResetPosition(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.angularVelocity = 0;
		
		transform.position = player1.transform.position- offset;
		transform.rotation = Quaternion.identity;
		transform.localScale = new Vector3(25,25,0);
		
		isGrabbed = false;
		isFlying = false;
	}
	
	void Start () {
		rigidbody2D.gravityScale = 0; //sets the gravity scale to 0. Gravity will simulated by another method
		startPoint = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2+50*hazardID, Screen.height, 0) );
		offset = player1.transform.position-startPoint;
		ResetPosition();
		this.collider2D.enabled = false;
	}
	
	void FixedUpdate(){
		
		//turns on the collider off if the mouse gets close enough
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Vector3.Distance(mousePosition, transform.position)<3){ 
			this.collider2D.enabled = true;
		}
		
		if (!isGrabbed && !isFlying) {
			ResetPosition();
			
			if (Vector3.Distance(mousePosition, transform.position)>3){ //turns on the collider if the mouse gets close enough
				this.collider2D.enabled = false;
			}
			
		}
		
		if(isGrabbed){ //moves the skeleton along with the mouse
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			this.transform.position = worldPosition;
			this.collider2D.enabled = false;
		}
		
		if (isFlying) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y - gravity);
			transform.localScale = new Vector3(30,30,0);
		}
		
		//resets the position of the object after a certain respawn time
		if ((Time.time-startTime)>respawnTimer) { 
			startTime=10e12f; //sets it to a really high value so it doesnt keep executing and reseting position
			ResetPosition ();
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
			if(Vector2.Distance(player1.position, this.transform.position)<25){
				this.transform.position = player1.position + new Vector3(-10, 25, 0);
			}
			
			isGrabbed = false;
			isFlying = true;
			this.collider2D.enabled = true;
			
			startTime=Time.time; //resets the timer for the respawn timer
			
		}
	}
}