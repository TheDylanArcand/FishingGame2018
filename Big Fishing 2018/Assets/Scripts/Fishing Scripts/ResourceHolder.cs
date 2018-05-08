using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object to allow data saving inbetween scenes without having to load the data when moving scenes
///		Possibly look into DontDestroyOnLoad for similar functionality
/// </summary>

[CreateAssetMenu]
public class ResourceHolder : ScriptableObject
{
	//Serialized fields for private integers to allow changing in the editor but not in game
	[SerializeField]
	private int EXP = 0;
	[SerializeField]
	private int LootBoxCount = 5;
	[SerializeField]
	private int Powerlevel = 0;

	//Getters and setters/ modifiers for use while running
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
