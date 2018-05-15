using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
