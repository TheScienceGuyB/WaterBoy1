using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPrison : MonoBehaviour {

    public GameObject gameO;
    public bool enabledGO;
    public bool disabledGO;

    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shark")
        {
            gameO.SetActive(true);
            enabledGO = true;
            disabledGO = false;
        }

    }
}
