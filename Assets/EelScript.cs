using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EelScript : MonoBehaviour {


    public GameObject freeze;
    Vector2 velocity;
    Rigidbody2D myRB;
    int newPosition;
    public bool paused = false;
    bool frozen = false;
    public float timer;
   



    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        freeze = GameObject.FindWithTag("FreezePower");
    }
    public void Update()
    {
        
        switch (newPosition)
        {
            case 1:
                velocity = new Vector2(-3,5);
                break;
            case 2:
                velocity = new Vector2(3, -5);
                break;
            case 3:
                velocity = new Vector2(-3, -5);
                break;
            case 4:
                velocity = new Vector2(3, 5);
                break;


        }

        if (paused == false)
        {
            timer += Time.deltaTime;
            if (timer >= 0 && timer <= .3)
            {
                newPosition = (Random.Range(1, 5));
            }
            if (timer >= 1 && timer <= 1.99)
            {

                myRB.velocity = velocity;

            }
            else if (timer >= 2 && timer <= 2.99)
            {
                myRB.velocity = velocity * -1;
                timer = 0;
            }
            else if (timer >= 3)
            {
                timer = 0;
            }
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
        }
    }

    IEnumerator Frozen()
    {
        paused = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(iceBlock);
        paused = false;
        


    }


}
