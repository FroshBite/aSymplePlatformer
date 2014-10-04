using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	void ResetPosition(){
		this.transform.position = startPoint;
		this.rigidbody2D.velocity = Vector2.zero;
	}

	public float gravity=1, jumpScale=1, speed=1,turboFactor=1f;	
	new Vector2 startPoint;


	
	// Use this for initialization
	void Start () {

		startPoint = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float right = 0f, left = 0f, up = 0f, turbo = 1.0f, turboY = 1.0f;

		if (Input.GetKey(KeyCode.D)){
			right=1.0f;
		}

		if (Input.GetKey(KeyCode.A)){
			left=-1.0f;
		}

		if ((Input.GetKey (KeyCode.Space) && rigidbody2D.velocity.y == 0)){
			up=6.0f;
		}

		if ((Input.GetKeyUp (KeyCode.Space) && rigidbody2D.velocity.y != 0)){
			up=-2.0f;
		}

		if (Input.GetKey (KeyCode.LeftShift)){
			turbo=turboFactor;
			turboY=0f;

			
		}

		if (Input.GetKeyDown (KeyCode.R)){
			ResetPosition();
		}


		rigidbody2D.velocity = new Vector2 (right*speed*turbo + left * speed*turbo, turboY* (rigidbody2D.velocity.y - gravity  + up * jumpScale));
	
	}

}
