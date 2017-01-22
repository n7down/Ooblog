using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	private float movementSpeed = 500.0f;
	private float projectileDirection;
	private GameObject upSprite;
	private GameObject downSprite;
	private State currentState;
	private float currentTime;

	private enum State
	{
		UP,
		DOWN
	}

	public void Start ()
	{
		upSprite = GameObject.Find("up");
		downSprite = GameObject.Find("down");
		downSprite.SetActive(false);
		currentState = State.UP;
	}

	public float ProjectileDirection
	{
		get
		{ 
			return projectileDirection;
		}
	}

	public void Update () 
	{
		if (currentTime > 0.1f)
		{
			if (currentState == State.UP)
			{
				if (upSprite != null)
				{
					upSprite.SetActive(false);
				}
				if (downSprite != null)
				{
					downSprite.SetActive(true);
				}
				currentState = State.DOWN;
			}
			else
			{
				if(upSprite != null)
				{
					upSprite.SetActive(true);
				}
				if (downSprite != null)
				{
					downSprite.SetActive(false);
				}
				currentState = State.UP;
			}
			currentTime = 0.0f;
		}
		else
		{
			currentTime += Time.deltaTime;
		}
	}

	public void FireProjectile(float direction)
	{
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
		rigidBody2D.AddForce(Vector2.right * direction * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
		projectileDirection = direction;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Human")
		{
			HumanController humanController = collision.gameObject.GetComponent<HumanController>();
			humanController.SetMindControlled();
		}
		Destroy(gameObject);
	}
}
