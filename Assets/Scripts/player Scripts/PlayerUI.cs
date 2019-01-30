using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {




    public float wetness = 100f;
    public Slider wetmeter;
    public Animator heartAnim;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public bool hasCoin1;
    public bool hasCoin2;
    public bool hasCoin3;



    private PlayerController playercont;
    

	void Start () {

       
        wetmeter.value = 50f;

        wetness = 100f;

        playercont = GameObject.Find("Player").GetComponent<PlayerController>();
	}


   


    // Update is called once per frame
    void Update () {
        wetmeter.value = wetness;
        if (playercont.GetComponent<PlayerController>().wetnessRefresh == false)
        {
            wetness -= 2.5f * Time.deltaTime;
        }
        else
        {
            wetness = 100f;

        }
        if (wetness > 100f)
        {
            wetness = 100;
        }
        if (wetness < 0)
        {
            wetness = 0;
        }
        if (wetness <= 0f)
        {
            heartAnim.SetBool("NoWater", true);
        }
        else
        {
            heartAnim.SetBool("NoWater", false);
        }

       

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pearl")
        {
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            hasCoin1 = true;
            Destroy(coin1);
        }
        if (other.tag == "Pearl2")
        {
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            hasCoin2 = true;
            Destroy(coin2);
        }
        if (other.tag == "Pearl3")
        {
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            hasCoin3 = true;
            Destroy(coin3);
        }

    }

}
