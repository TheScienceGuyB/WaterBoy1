using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPathTrigger : MonoBehaviour {

    public GameObject secretPath;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            secretPath.SetActive(true);
        }
    }
}
