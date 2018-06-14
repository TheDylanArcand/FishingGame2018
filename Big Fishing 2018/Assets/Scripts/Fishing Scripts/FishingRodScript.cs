using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///		Script for simulating a fishing line
/// </summary>

public class FishingRodScript : MonoBehaviour
{
	public Transform Bobber;
	public Transform Rod;

	private void Update()
	{
		if(Bobber.gameObject.activeSelf == true)
		{
			transform.LookAt(Bobber);
		}
		else
		{
			transform.LookAt(Rod);
		}
	}
}
