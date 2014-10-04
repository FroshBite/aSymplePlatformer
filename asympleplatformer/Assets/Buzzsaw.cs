using UnityEngine;
using System.Collections;

public class Buzzsaw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Player1") {
			GameObject.Destroy(coll.gameObject);
		}
	}
	
}
