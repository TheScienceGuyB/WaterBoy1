using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour {
    public string levelName;
    // Use this for initialization



    public void loadLevel()
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1;

    }
    
}
