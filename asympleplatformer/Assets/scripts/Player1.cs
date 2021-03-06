﻿using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {


	public float gravity=1, jumpScale=1, speed=1,turboFactor=1f, controlFreakDuration=5f;

	private string[] controls=new string[]{"A","D","Space","Shift"};
	bool isAlive = true, win=false, paused=false, shiftPressed=false;
	float startTime; //used for the shift boost functionality
	float controlFreakStartTime=10e8f; //used for effect time of the control freak, can also be used for other effects
	Vector2 startPoint;


	void ResetPosition(){
		gameObject.SetActive(true);
		transform.position = startPoint;
		rigidbody2D.velocity = Vector2.zero;
	}

	void OnGUI() {
		if (!isAlive && paused == false) {
			GUI.Box (new Rect (Screen.width/2 - 250, Screen.height/2 - 50, 500, 100), "Player 2 Wins!");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2 - 185,Screen.height/2 - 10,80,40), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 10,80,40), "Main Menu")) {
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(Screen.width/2 + 105,Screen.height/2 - 10,80,40), "Quit")) {
				Application.Quit ();
			}
			renderer.enabled = false;
		}

		if (win && paused == false) {
			GUI.Box (new Rect (Screen.width/2 - 250, Screen.height/2 - 50, 500, 100), "Player 1 Wins!");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2 - 185,Screen.height/2 - 10,80,40), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 10,80,40), "Main Menu")) {
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(Screen.width/2 + 105,Screen.height/2 - 10,80,40), "Quit")) {
				Application.Quit ();
			}
			renderer.enabled = false;

		}

		if (paused == true) {
			Time.timeScale = 0;
			GUI.Box (new Rect (Screen.width/2 - 125, Screen.height/2 - 225, 250, 450), "Paused");
			if(GUI.Button(new Rect (Screen.width/2 - 115, Screen.height/2 - 170, 230, 80), "Resume")){
				Time.timeScale = 1;
				paused = false;
			}
			if(GUI.Button(new Rect (Screen.width/2 - 115, Screen.height/2 - 75, 230, 80), "Restart")){
				Application.LoadLevel(1);
				Time.timeScale = 1;
				paused = false;
			}
			if(GUI.Button(new Rect (Screen.width/2 - 115, Screen.height/2 + 20, 230, 80), "Main Menu")){
				Time.timeScale = 1;
				paused = false;
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect (Screen.width/2 - 115, Screen.height/2 + 135, 230, 80), "Quit Game")){
				Application.Quit();
			}


		}

	}

	void screwUpControls(){
		
		controls=new string[]{"D","A","Space","Shift"};
	}
	
	void  resetControls(){
		controls=new string[]{"A","D","Space","Shift"};
	}

	// Use this for initialization
	void Start () {
		
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//DELETE
		print (transform.position);

		float right = 0f, left = 0f, up = 0f, turbo = 1.0f, turboY = 1.0f, timeDif;
		
		if (Input.GetButton(controls[1])){ //if D is pressed
			right=1.0f;
			transform.localScale = new Vector3(-20,transform.localScale.y,transform.localScale.z);
		}
		
		if (Input.GetButton(controls[0])){//if A is pressed
			left=-1.0f;
			transform.localScale = new Vector3(20,transform.localScale.y,transform.localScale.z);
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
		
		if (transform.position.y<-100){
			isAlive = false;
			win = false;

		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused=true;
		}


		if (isAlive){
			//moves the player according to the controls
			rigidbody2D.velocity = new Vector2 (right*speed*turbo + left * speed*turbo, turboY* (rigidbody2D.velocity.y - gravity  + up * jumpScale));
		}

		if (!isAlive){
			rigidbody2D.velocity = Vector2.zero;
		}

		if (win){
			rigidbody2D.velocity = Vector2.zero;
		}

		if ((Time.time-controlFreakStartTime)>controlFreakDuration){
			resetControls();
			controlFreakStartTime=10e8f; //resets the timer
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		
		
		if (other.gameObject.tag == "enemy") {
			isAlive=false;
			print ("Player 1 Died!");

		}

		if (other.gameObject.tag == "controlfreak") {
			screwUpControls();
			controlFreakStartTime=Time.time;
		}

		if (other.gameObject.tag == "finish") {
			print ("Congratulations, Player 1 won!");
			win=true;
			}
		
	}
	
}