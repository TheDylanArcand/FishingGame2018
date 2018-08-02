using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class MenuScript : MonoBehaviour
{
	public void GotoMainMenu()
	{
		SceneManager.LoadScene(ConstSceneScript.SCENE_MAINMENU, LoadSceneMode.Single);
	}

	public void GotoLootBox()
	{
		SceneManager.LoadScene(ConstSceneScript.SCENE_LOOTBOX, LoadSceneMode.Single);
	}

	public void GotoFishing()
	{
		SceneManager.LoadScene(ConstSceneScript.SCENE_FISHING, LoadSceneMode.Single);
	}

	public void GotoSkillTree()
	{
		SceneManager.LoadScene(ConstSceneScript.SCENE_SKILLTREE, LoadSceneMode.Single);
	}

	public void CloseProgram()
	{
		Application.Quit();
	}
}
