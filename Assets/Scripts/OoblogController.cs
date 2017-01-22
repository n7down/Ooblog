using UnityEngine;
using System.Collections;

public class OoblogController : MonoBehaviour 
{
	private Rigidbody2D rigidBody2D;
	private float movementSpeed;
	public bool grounded;
	private float jumpPower;
	private Vector3 initialScale;

	public void Start () 
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		movementSpeed = 250.0f;
		grounded = false;
		jumpPower = 250.0f;
		initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	public void Update () 
	{
		float horizontalInput = Input.GetAxis ("Horizontal");
		Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
		newVelocity.x = horizontalInput * movementSpeed * Time.deltaTime;
		GetComponent<Rigidbody2D>().velocity = newVelocity;

		if (grounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				rigidBody2D.AddForce(Vector2.up * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
				grounded = false;
			}
		}

		if (horizontalInput != 0)
		{
			transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * initialScale.x, 
				initialScale.y, 
				initialScale.z);
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject collisionGameObject = collision.gameObject;
		if (collisionGameObject.tag == "Platform")
		{
			grounded = true;
		}
	}
}
