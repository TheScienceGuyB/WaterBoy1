﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urchin : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.tag == "IceBlock")
        {
            Destroy(gameObject);
        }
        
    }


}
