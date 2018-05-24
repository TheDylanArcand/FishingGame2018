using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.Build;

public class PrePostBuildMethods : IPreprocessBuild, IPostprocessBuild
{
	private const string README = "/Readme.txt";

	public int callbackOrder { get { return 0; } }

	public void OnPreprocessBuild(BuildTarget target, string path)
	{
		if (CustomBuildProcess.isManualBuild) return;
		BuildVersionMenu.IncrementPatchVersion();
		BuildVersionMenu.SaveToFile();
	}

	public void OnPostprocessBuild(BuildTarget target, string path)
	{
		if (CustomBuildProcess.isManualBuild) return;
		FileUtil.CopyFileOrDirectory("Assets/Templates" + README, path + "/.." + README);
	}
}

//public class PostBuildMethods : IPostprocessBuild
//{
//	public int callbackOrder { get { return 0; } }
//
//	public void OnPostprocessBuild(BuildTarget target, string path)
//	{
//		if (CustomBuildProcess.isManualBuild) return;
//		FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "/../Readme.txt");
//	}
//}
