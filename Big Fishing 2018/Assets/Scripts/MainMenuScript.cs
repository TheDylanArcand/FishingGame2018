using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10f, 10f, 200f, 50f), "Fishing Game!"))
        {
            SceneManager.LoadScene("Fishing Game");
        }

        if (GUI.Button(new Rect(10f, 70f, 200f, 50f), "Loot Opening!"))
        {
            SceneManager.LoadScene("Loot-Box Screen");
        }
    }
}
