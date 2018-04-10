using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeScript : MonoBehaviour
{
    public Text PowerLevelText;
    public int BasePowerLevel = 100;

    private bool _ChangeMade = true;
    private int _PowerLevelFlatAdd = 0;
    private float _PowerLevelMultiplier = 0.0f;

    private void Awake()
    {
        if (PowerLevelText != null)
        {
            PowerLevelText = GetComponent<Text>();
        }
    }

    void Update ()
    {
        if (_ChangeMade && PowerLevelText != null)
        {
            PowerLevelText.text = "Power Level = " + PowerLevelCalculation(BasePowerLevel, _PowerLevelFlatAdd, _PowerLevelMultiplier);
            _ChangeMade = false;
        }
	}

    public void AddPowerFlat(int powerFlat = 0)
    {
        _ChangeMade = true;
        _PowerLevelFlatAdd += powerFlat;
    }

    public void AddPowerMult(float powerMult = 0.0f)
    {
        _ChangeMade = true;
        _PowerLevelMultiplier += powerMult/100.0f;
    }

    string PowerLevelCalculation(int powerBase, int powerFlat, float powerMult)
    {
        return (powerBase + ((int)(powerBase * powerMult)) + powerFlat).ToString();
    }
}
