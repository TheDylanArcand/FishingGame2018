using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Toggle GoodFishingButton;

    private const string SCENE_MAINMENU = "Main-Menu Scene";
    private const string SCENE_LOOTBOX = "Loot-Box Scene";
	private const string SCENE_FISHING = "Fishing Scene";
	private const string SCENE_FISHING_BETTER = "Fishing Scene Updated";
    private const string SCENE_SKILLTREE = "Skill Tree Scene";

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(SCENE_MAINMENU);
    }

    public void GotoLootBox()
    {
        SceneManager.LoadScene(SCENE_LOOTBOX);
    }

    public void GotoFishing()
    {
		if (GoodFishingButton.isOn)
			SceneManager.LoadScene(SCENE_FISHING_BETTER);
		else
			SceneManager.LoadScene(SCENE_FISHING);
    }

    public void GotoSkillTree()
    {
        SceneManager.LoadScene(SCENE_SKILLTREE);
    }
}
