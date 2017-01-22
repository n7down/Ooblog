using UnityEngine;
using System.Collections;

public class OoblogController : MonoBehaviour 
{
	private Rigidbody2D rigidBody2D;
	private float movementSpeed;
	public bool grounded;
	private float jumpPower;
	private Vector3 initialScale;
	private Animator animator;
	public float facingDirection;
	private GameObject projectileEmitter;

	public void Start () 
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		movementSpeed = 250.0f;
		grounded = false;
		jumpPower = 250.0f;
		initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
		animator = GetComponent<Animator>();
		GameObject.Find("placeholder").SetActive(false);
		facingDirection = 1;
		projectileEmitter = GameObject.Find("projectile emitter");
	}

	public void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject bulletGameObject = Instantiate(Resources.Load("Prefabs/Bullet"), 
				projectileEmitter.transform.position,
				Quaternion.identity) as GameObject;
			Destroy(bulletGameObject, 1.0f);
			BulletController bulletController = bulletGameObject.GetComponent<BulletController>();
			bulletController.SendMessage("FireProjectile", facingDirection);
		}

		float horizontalInput = Input.GetAxis ("Horizontal");
		Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
		newVelocity.x = horizontalInput * movementSpeed * Time.deltaTime;
		GetComponent<Rigidbody2D>().velocity = newVelocity;
		animator.SetFloat("IsMoving", Mathf.Abs(horizontalInput));

		if (grounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				rigidBody2D.AddForce(Vector2.up * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
				grounded = false;
				animator.enabled = false;
			}
		}

		if (horizontalInput != 0)
		{
			transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * initialScale.x, 
				initialScale.y, 
				initialScale.z);
			facingDirection = Mathf.Sign(horizontalInput);
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject collisionGameObject = collision.gameObject;
		if (collisionGameObject.tag == "Platform")
		{
			grounded = true;
			animator.enabled = true;
		}
	}
}
