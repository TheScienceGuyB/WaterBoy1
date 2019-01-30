using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCont : MonoBehaviour {


    string levelName;
    bool dontDestroy;
    public static TutorialCont tutControl;
    public string nameOfGunTutorial;
    public GameObject secretPath;
    public GameObject door;
    public GameObject doorSwitch;
    public GameObject snail;
    [SerializeField]
    int i =0;
    
    public int u = 0;
    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
        if (levelName == nameOfGunTutorial && tutControl == null)
        {
            DontDestroyOnLoad(gameObject);
            tutControl = this;
            
        }
        else if (tutControl != this)
        {
            Destroy(gameObject);
        }

    }

    void Start () {
        levelName = SceneManager.GetActiveScene().name;
        if (levelName != nameOfGunTutorial)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {

        door = GameObject.Find("SwitchDoor");
        doorSwitch = GameObject.Find("Switch");
        if (doorSwitch.GetComponent<SwitchScript>().switchIsOn == true)
        {
            i = 1;
        }
        if (i == 1)
        {
            Destroy(door);
        }
        if (u == 1)
        {
           Destroy(GameObject.Find("TutorialSnail"));
        }
    }
    
}
