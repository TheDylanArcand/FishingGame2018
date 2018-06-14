using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStatsScript : MonoBehaviour
{
	public static UserStatsScript Instance;
	private bool _Created = false;

	public int PowerRank = 100;
	public int EXP = 0;
	public int LootBoxCount = 5;
	public float Fishing_MinimumWait = 0.5f;
	public float Fishing_MaximumWait = 4.0f;

	private void Awake()
	{
		Instance = this;

		if(!_Created)
		{
			DontDestroyOnLoad(this.gameObject);
			_Created = true;
		}
	}
}
