using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
<<<<<<< HEAD
	public GameObject player;
	private Vector3 offset;

=======
	public Transform player;
	public float number =1.0f;
	private Vector2 offset;
>>>>>>> origin/master
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
<<<<<<< HEAD
	void Update () {
		transform.position = player.transform.position + offset;
=======
	void FixedUpdate () {
		transform.position += player.position + offset;
>>>>>>> origin/master
	}
}
