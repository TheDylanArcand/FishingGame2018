using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class CustomBuildProcess
{
	private const string EXECUTABLENAME = "/BuiltGame.exe";
	private const string README = "/Readme.txt";

	public static bool isManualBuild = false;

	[MenuItem("Tools/Windows Build With Postprocess")]
	public static void BuildGame()
	{
		isManualBuild = true;
		//Pree process example
		BuildVersionMenu.IncrementPatchVersion();
		BuildVersionMenu.SaveToFile();

		//Build settings
		string filePath = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
		string[] scenes = new string[]
		{
			ConstSceneScript.SCENE_MAINMENU,
			ConstSceneScript.SCENE_FISHING,
			ConstSceneScript.SCENE_FISHING_BETTER,
			ConstSceneScript.SCENE_LOOTBOX,
			ConstSceneScript.SCENE_SKILLTREE
		};

		//Build player
		BuildPipeline.BuildPlayer(scenes, filePath + EXECUTABLENAME, BuildTarget.StandaloneWindows, BuildOptions.None);

		//Copy a file from the project folder to the build folder, alongside the built game
		//Post process example
		FileUtil.ReplaceFile("Assets/Templates" + README, filePath + README);

		Process p = new Process();
		p.StartInfo.FileName = filePath + EXECUTABLENAME;
		p.Start();
		isManualBuild = false;
	}
}
