﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBoxValueChecker : MonoBehaviour
{
	public ResourceHolder RS;
	public GameObject LootBoxButton;

	private void OnEnable()
	{
		if(RS != null)
		{
			if(LootBoxButton != null)
			{
				if(RS.GetLootBoxCount() < 1)
				{
					LootBoxButton.GetComponent<Button>().interactable = false; ;
				}
				else
				{
					LootBoxButton.GetComponent<Button>().interactable = true; ;
				}
			}
		}
	}
}
