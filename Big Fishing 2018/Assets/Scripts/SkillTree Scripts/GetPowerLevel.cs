using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPowerLevel : MonoBehaviour
{
	public Text PowerLevelText;

	private void Update()
	{
		PowerLevelText.text = "Power Rank: " + (UserStatsScript.Instance.PowerRankBase * (UserStatsScript.Instance.PowerRankMult / 100) + UserStatsScript.Instance.PowerRankFlat);
	}
}
