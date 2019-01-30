using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFish : MonoBehaviour {

    public GameObject spike;
    public Transform spikePos;
    public int MaxX;
    public int MinX;
    public int velocity;

    public bool frozen = false;
    public GameObject freeze;


    float shotTimer;
	
	void Start () {
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
    }
	
	// Update is called once per frame
	void Update () {
        shotTimer += Time.deltaTime;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);

        if (transform.localPosition.x >= MaxX && velocity >= 0)
        {
            velocity = -velocity;
            transform.localScale = new Vector3(1, 1, 1);


        }else if (transform.localPosition.x <= MinX)
        {
            velocity = Mathf.Abs(velocity);
            transform.localScale = new Vector3(-1, 1, 1);

        }else if (frozen == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            
        }



        if (shotTimer >= 3 && transform.localScale.x < 0)
        {
            GameObject Spike = Instantiate(spike, spikePos.position, Quaternion.identity);
            Spike.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3, -5), Random.Range(7, 10));
            shotTimer = 0;
        }
        else if (shotTimer >= 3 && transform.localScale.x > 0)
        {
            GameObject Spike = Instantiate(spike, spikePos.position, Quaternion.identity);
            Spike.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3, 5), Random.Range(7, 10));
            shotTimer = 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            frozen = true;
        }
    }

    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(iceBlock);
        frozen = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

    }
}
