using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{


    public Animator saving;

    public string levelName;
    private void Start()
    {
        StartCoroutine(Saveco());
        levelName = SceneManager.GetActiveScene().name;
        saving.Play("SavingAnim");
    }

    public void Update()
    {

        
        
        
    }

    IEnumerator Saveco()
    {

        yield return new WaitForSeconds(3f);
        
        LevelManager.control.Save();


    }
}




