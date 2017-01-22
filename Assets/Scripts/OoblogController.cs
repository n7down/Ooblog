using UnityEngine;
using System.Collections;

public class OoblogController : MonoBehaviour {
	private Rigidbody2D rigidBody2D;
	private float movementSpeed;

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
		movementSpeed = 250.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");
		Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
		newVelocity.x = horizontalInput * movementSpeed * Time.deltaTime;
		GetComponent<Rigidbody2D>().velocity = newVelocity;
	
	}
}
