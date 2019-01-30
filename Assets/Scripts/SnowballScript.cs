using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour {

    public float damage = 50f;


    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillPlane")
        {
            Hit();
        }
        if (collision.tag == "Player")
        {
            Hit();
        }
        if (collision.tag == "Ground")
        {
            Hit();
        }
    }

}
