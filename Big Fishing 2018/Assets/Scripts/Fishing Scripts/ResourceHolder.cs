using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResourceHolder : ScriptableObject
{
	[SerializeField]
	private int EXP = 0;
	[SerializeField]
	private int LootBoxCount = 5;
	[SerializeField]
	private int Powerlevel = 0;

	public void ModifyEXP(int modifier)
	{
		EXP += modifier;
	}

	public int GetEXPTotal()
	{
		return EXP;
	}

	public void ModifyLootBoxes(int modifier)
	{
		LootBoxCount += modifier;
	}

	public int GetLootBoxCount()
	{
		return LootBoxCount;
	}

	public void SetPowerlevel(int level)
	{
		Powerlevel = level;
	}

	public int GetPowerLevel()
	{
		return Powerlevel;
	}
}
