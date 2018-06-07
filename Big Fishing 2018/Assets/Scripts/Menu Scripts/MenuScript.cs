using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class MenuScript : MonoBehaviour {

	public Toggle GoodFishingButton;
	public Text VersionNumber;

	private void Awake()
	{
		//if (VersionNumber != null)
		//	VersionNumber.text = "Version: " + PlayerSettings.bundleVersion;
	}

	public void GotoMainMenu()
    {
        SceneManager.LoadScene(ConstSceneScript.SCENE_MAINMENU);
    }

    public void GotoLootBox()
    {
        SceneManager.LoadScene(ConstSceneScript.SCENE_LOOTBOX);
    }

    public void GotoFishing()
    {
		if (GoodFishingButton.isOn)
			SceneManager.LoadScene(ConstSceneScript.SCENE_FISHING_BETTER);
		else
			SceneManager.LoadScene(ConstSceneScript.SCENE_FISHING);
    }

    public void GotoSkillTree()
    {
        SceneManager.LoadScene(ConstSceneScript.SCENE_SKILLTREE);
    }

	public void CloseProgram()
	{
		Application.Quit();
	}
}
