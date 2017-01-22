using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private GameObject target;
	private Vector3 offset;

	public void Start() 
	{
		target = GameObject.Find("/Ooblog");
		if (target != null)
		{
			offset = transform.position - target.transform.position;
		}
	}

	public GameObject Target 
	{ 
		get 
		{
			return target;
		}

		set
		{ 
			target = value;
			//			offset = transform.position - target.transform.position;
		}
	}

	public void LateUpdate() 
	{
		if (target != null)
		{
			transform.position = target.transform.position + offset;
		}
	}

}
