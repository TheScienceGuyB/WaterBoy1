using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour {

    public GUISkin customSkin;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    private void OnGUI()
    {
        GUI.skin = customSkin;
        GUIStyle customButton = new GUIStyle("button");
        customButton.fontSize = 39;

        if (GUI.Button(new Rect(300, 300, 200, 100), "load",customButton))
        {
            LevelManager.control.Load();
            Time.timeScale = 1;
        }

        
    }
    */

    public void Click()
    {
        LevelManager.control.Load();
        Time.timeScale = 1;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GameStart");
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
