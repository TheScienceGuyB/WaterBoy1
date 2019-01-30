using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager control;
    public Chest chest;
    public PlayerController playerCont;
    public int i; // watergun
    public int ice; // icestate
    public int x;
    public GameObject loadButton;
    
    public string nameOFLevel;
    
    Scene levelName;
    

    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        
       
        
    }

    private void Start()
    {

        
    }

    public void Update()
    {
        nameOFLevel = SceneManager.GetActiveScene().name;
        x = SceneManager.GetActiveScene().buildIndex;

        //levelName = SceneManager.GetActiveScene();
        
        //nameOFLevel = SceneManager.GetActiveScene().name;  //levelName.name;
        

        if (nameOFLevel == "Start Menu")
        {
            loadButton.SetActive(true);

        }
        else
        {
            loadButton.SetActive(false);
        }

        if (i == 1)
        {
            FindObjectOfType<PlayerController>().waterGun = true;
            //playerCont.waterGun = true;
        }
        if (ice == 1)
        {
            FindObjectOfType<IceState>().enabled = true;
        }else if (ice == 0)
        {
            FindObjectOfType<IceState>().enabled = false;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameStart");
        
    }
    


    public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerData data = new PlayerData();
        data.i = i;
        data.x = x;
        data.levelName = nameOFLevel;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("saving game" + nameOFLevel);
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            i = data.i;
            x = data.x;
            nameOFLevel = data.levelName;
            SceneManager.LoadScene(x);
            Debug.Log("Loading Scene" + nameOFLevel);
            Pause.gameIsPaused = false;
        }
    }

}

[Serializable]
class PlayerData
{
    public int i;
    public string levelName;
    public int x;
    
}
