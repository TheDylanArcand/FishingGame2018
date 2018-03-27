using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes { MainMenu, NotMainMenu};

public class MenuScript : MonoBehaviour {

    Scenes CurrentScene;
    Scene scene;

    // Use this for initialization
    void Awake ()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            CurrentScene = Scenes.MainMenu;
        }
        else
        {
            CurrentScene = Scenes.NotMainMenu;
        }
	}

    private void OnGUI()
    {
        switch (CurrentScene)
        {
            case Scenes.MainMenu:

                if (GUI.Button(new Rect(10f, 10f, 200f, 50f), "Fishing Game!"))
                {
                    CurrentScene = Scenes.NotMainMenu;
                    SceneManager.LoadScene("Fishing Game");
                }

                if (GUI.Button(new Rect(10f, 70f, 200f, 50f), "Loot Opening!"))
                {
                    CurrentScene = Scenes.NotMainMenu;
                    SceneManager.LoadScene("Loot-Box Screen");
                }
                break;

            case Scenes.NotMainMenu:

                if (GUI.Button(new Rect(10f, 708f, 200f, 50f), "Main Menu"))
                {
                    CurrentScene = Scenes.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            default:
                break;
        }
    }
}
