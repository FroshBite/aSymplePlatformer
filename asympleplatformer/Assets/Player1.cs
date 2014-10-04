using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	public float speed=1, gravity=1, jumpScale=1;
	// Use this for initialization
	void Start () {

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
		if ((Input.GetKeyDown (KeyCode.Space) && rigidbody2D.velocity.y == 0)){
			up=5.0f;
		}

		rigidbody2D.velocity = new Vector2 (right * speed + left * speed, rigidbody2D.velocity.y - gravity  + up * jumpScale);
	
	}

}
