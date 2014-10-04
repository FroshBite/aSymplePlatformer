using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	void ResetPosition(){
		this.transform.position = startPoint;
		this.rigidbody2D.velocity = Vector2.zero;
	}

	void screwUpControls(){

		controls=new string[]{"D","A","Shift","Space"};
	}

	void  resetControls(){
		controls=new string[]{"A","D","Space","Shift"};
	}

	public float gravity=1, jumpScale=1, speed=1,turboFactor=1f;
	private string[] controls=new string[]{"A","D","Space","Shift"};
	float startTime;
	bool shiftPressed=false;
	 Vector2 startPoint;


	
	// Use this for initialization
	void Start () {

		startPoint = transform.position;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float right = 0f, left = 0f, up = 0f, turbo = 1.0f, turboY = 1.0f, timeDif;

		if (Input.GetButton(controls[1])){ //if D is pressed
			right=1.0f;
<<<<<<< HEAD
			transform.localScale = new Vector3(-20, transform.localScale.y, transform.localScale.x);
=======
			transform.localScale = new Vector3(-20,transform.localScale.y,transform.localScale.z);
>>>>>>> origin/master
		}

		if (Input.GetButton(controls[0])){//if A is pressed
			left=-1.0f;
<<<<<<< HEAD
			transform.localScale = new Vector3(20, transform.localScale.y, transform.localScale.x);
=======
			transform.localScale = new Vector3(20,transform.localScale.y,transform.localScale.z);

>>>>>>> origin/master
		}

		if ((Input.GetButton (controls[2]) && rigidbody2D.velocity.y == 0)){ //if space key is pressed
			up=6.0f;
		}

		if ((Input.GetButtonUp (controls[2]) && rigidbody2D.velocity.y != 0)){ //if space key is pressed{
			up=-2.0f;
		}

		if (Input.GetButton (controls[3])){ // if shift key is pressed

			if (shiftPressed==false){

				startTime=Time.realtimeSinceStartup;
				shiftPressed=true;

			}

			timeDif=Time.realtimeSinceStartup-startTime;

			if (timeDif<=0.2){
				turbo=turboFactor;
				turboY=0f;
			}
		}

		if (Input.GetButtonUp (controls[3])){ //if shift key is pressed

		
			shiftPressed=false;
		}

		if (this.transform.position.y<-30){
			ResetPosition();
		}

		if (Input.GetKeyDown (KeyCode.T)){
			screwUpControls();
		}
		if (Input.GetKeyDown (KeyCode.U)){
			resetControls();
		}


		rigidbody2D.velocity = new Vector2 (right*speed*turbo + left * speed*turbo, turboY* (rigidbody2D.velocity.y - gravity  + up * jumpScale));
	
	}

	void OnGUI() {
		GUI.Box (new Rect (375, 500, 350, 75), "Player 2");
	}

}
