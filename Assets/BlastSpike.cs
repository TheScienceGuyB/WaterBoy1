using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSpike : MonoBehaviour {
    float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Animator>().SetFloat("Velocity", gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}

