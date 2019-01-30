using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunLevelSelect : MonoBehaviour {

    // Use this for initialization
    public bool activateIceState = false;
	void Start () {
        StartCoroutine(WaitTime());
        if (activateIceState == true)
        {
            StartCoroutine(WaitTimeIceState());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<LevelManager>().i = 1;
    }
    IEnumerator WaitTimeIceState()
    {
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<LevelManager>().ice = 1;
    }

}
