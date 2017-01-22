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
}
