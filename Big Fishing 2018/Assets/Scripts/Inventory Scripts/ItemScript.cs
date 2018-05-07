﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ItemScript : ScriptableObject
{
    public Sprite Sprite;
	public string Name;
	public string SlotTag = "00";

	public void CleanItem()
	{
		Sprite = null;
		Name = null;
		SlotTag = "00";
	}

	public ItemScript()
	{
		//0
	}

	public ItemScript(ItemScript item)
	{
		Sprite = item.Sprite;
		Name = item.Name;
		SlotTag = item.SlotTag;
	}
}
