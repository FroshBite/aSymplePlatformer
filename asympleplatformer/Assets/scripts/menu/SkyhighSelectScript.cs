using UnityEngine;
using UnityEngine;
using System.Collections;

public class SkyhighSelectScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnMouseDown(){
		renderer.material.color = Color.red; // changes color to red 
	}
	
	void OnMouseUp(){
		renderer.material.color = Color.white; // changes color back to white 
		Application.LoadLevel (2);
		
	}
}