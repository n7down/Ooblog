using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour 
{
	private enum State
	{
		MindControlled,
		Sentient
	};

	private State currentState;

	public void Start () 
	{
		currentState = State.Sentient;
	}

	public void Update () 
	{

	}

	public void SetMindControlled()
	{		
		if (currentState == State.MindControlled)
		{
			GameObject.Find("human").SetActive(false);
			GameObject.Find("mind controlled human").SetActive(true);
		}
	}
		
	public void OnCollisionEnter2D(Collision2D collision)
	{
		
	}
}
