using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLevelController : MonoBehaviour {

    public GameObject[] clouds;
    Animator myAnim;
    public bool seventh = false;
    public bool fifth = false;
    public bool sixth = false;
    
    

	void Start () {
        myAnim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (clouds[0].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("1stCloudRaining", true);
        }

        if (clouds[1].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("2ndCloudRaining", true);
        }
        if (clouds[2].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("3rdCloudRaining", true);
        }
        if (clouds[4].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("5thCloudMove", true);
        }
        if (clouds[5].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("6thCloudMove", true);
        }
        if (clouds[6].GetComponent<Clouds>().isRaining == true)
        {
            myAnim.SetBool("7thCloudMove", true);
        }

        if (seventh == true && fifth == true && sixth == true)
        {
            myAnim.SetBool("LargeCloudActive", true);
        }
       
    }

    public void Fifth()
    {
        fifth = true;
    }
    public void Sixth()
    {
        sixth = true;
    }
    public void Seventh()
    {
        seventh = true;
    }
    public void LargeCloudRain()
    {
        clouds[7].GetComponent<Clouds>().waterSat = 30;
        
    }



}
