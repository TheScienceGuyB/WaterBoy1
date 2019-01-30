using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkEnable : MonoBehaviour {

    public GameObject shark;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shark.GetComponent<SharkScript>().enabled = true;
        }
    }
}
