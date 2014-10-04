using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform player;
	public float number =1.0f;
	private Vector2 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += player.position + offset;
	}
}
