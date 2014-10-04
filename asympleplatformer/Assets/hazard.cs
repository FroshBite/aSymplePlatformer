using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
	bool isGrabbed = false;
	bool isFlying = false;
	
	new Vector2 startPoint;
	

	void Start () {
		startPoint = transform.position;
		ResetPosition();

	}

	void ResetPosition(){
		this.transform.position = startPoint;
		rigidbody2D.velocity = Vector2.zero;
		isGrabbed = false;
		isFlying = false;
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			this.isGrabbed = false;
			this.isFlying = false;
			this.rigidbody2D.velocity = Vector2.zero;
			ResetPosition();
		}
	}
	
	void FixedUpdate(){
		
		if(isGrabbed){
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			//Debug.Log ("World Position: " + worldPosition.ToString());
			this.transform.position = worldPosition;
		}
		
		if(!isFlying){
			this.rigidbody2D.gravityScale = 0;
		} else {
			this.rigidbody2D.gravityScale = 5;

		}
		
	}
	
	void OnMouseDown(){
		isGrabbed = true;
	}
	
	void OnMouseUp(){
		if(isGrabbed){
			isGrabbed = false;
			isFlying = true;

		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Player1"){

			GameObject.Destroy(coll.gameObject);

		}
		
		ResetPosition ();
	}
}

