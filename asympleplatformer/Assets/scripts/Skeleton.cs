using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour {
	//User modifyable variables
	public int hazardID=0, respawnTimer=0; //respawn timer should always be above 0
	public Transform player1;
	public float speed=1.0f, gravity=1.0f;

	
	Vector3 offset, startPoint;
	bool isGrabbed = false, isFlying = false, walk =false; 
	float walkVel, startTime;

	void ResetPosition(){
		rigidbody2D.velocity = Vector2.zero;

		transform.position = player1.transform.position- offset;
		transform.localScale = new Vector3(25,25,0);

		walk = false;
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

		print (transform.position);

		//turns on the collider off if the mouse gets close enough
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Vector3.Distance(mousePosition, transform.position)<3){ 
			this.collider2D.enabled = true;
		}

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
			ResetPosition();

			if (Vector3.Distance(mousePosition, transform.position)>3){ //turns on the collider if the mouse gets close enough
				this.collider2D.enabled = false;
			}

		}
		
		if(isGrabbed){ //moves the skeleton along with the mouse when the player grabs it
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			this.transform.position = worldPosition;
			this.collider2D.enabled = false;

		}
		if (isFlying) { //activates when the user lets go of the mouse
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y - gravity);
			transform.localScale = new Vector3(35,35,0);

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
		walk = false;
		this.collider2D.enabled = false;
		transform.localScale = new Vector3(25,25,0);
		
	}
	
	void OnMouseUp(){
		
		if(isGrabbed){ //checks to make sure that player2 doesnt release the object too close to  player1
			if(Vector2.Distance(player1.position, this.transform.position)<25){
				this.transform.position = player1.position + new Vector3(-10, 25, 0);
			}
			
			isGrabbed = false;
			isFlying = true;
			this.collider2D.enabled = true;
			walkVel = (player1.position.x)-this.transform.position.x;

			startTime=Time.time; //resets the timer for the respawn timer
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.name != "Player1") {
			walk = true;
			isFlying=false;
		}
		
	}
}