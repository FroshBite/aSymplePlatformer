using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	public float speed=1, gravity=1, jumpScale=1;
	new Vector2 startPoint;
	// Use this for initialization
	void Start () {
		startPoint = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float right=0, left=0, up=0, down=0;
		this.rigidbody2D.gravityScale = 1.0f;

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

		if (Input.GetKeyDown (KeyCode.R)){
			this.transform.position=startPoint;
			this.rigidbody2D.velocity=Vector2.zero;
		}


		rigidbody2D.velocity = new Vector2 (right * speed + left * speed, rigidbody2D.velocity.y - gravity  + up * jumpScale);
	
	}

}
