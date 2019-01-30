using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidScript : MonoBehaviour {
    public GameObject canvas;
    public GameObject inkSquirt;
    Vector2 position;
    public float Timer;
    public bool refreshTimerBool;
    public bool refresh;
    public bool inkUp = false;
    public float refreshTimer;
    public bool canShoot;
    public bool isPaused = false;


    // for freezing
    public GameObject freeze;
    public Transform prefabAnim;
    


    // ink blot required in the water so the reference to inkhit can be made


    void Start () {
        canvas = GameObject.FindGameObjectWithTag("InkCanvas");
        canShoot = true;
        prefabAnim = transform.parent;
        freeze = GameObject.FindWithTag("FreezePower");
    }
	
	// Update is called once per frame
	void  FixedUpdate () {
        if (isPaused == false)
        {
            Timer += Time.deltaTime;
            position = new Vector2(transform.position.x, transform.position.y + transform.up.y);
            if (inkUp == true)
            {
                refresh = true;
                refreshTimerBool = true;
                Debug.Log("InkHit");
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                //StartCoroutine(InkDissapear());
            }

            if (refreshTimer >= 2)
            {
                Debug.Log("Timer");
                canvas.transform.GetChild(0).gameObject.SetActive(false);
                inkUp = false;
                refreshTimer = 0;
                refreshTimerBool = false;
            }


            if (refreshTimerBool == true)
            {
                refreshTimer += Time.deltaTime;
            }
            else
            {
                refreshTimer = 0;
            }

            if (Timer >= 6)
            {
                Timer = 0;
            }
            if (canShoot == true)
            {
                if (Timer >= 1.5f && Timer <= 1.7f || Timer >= 4.5f && Timer <= 4.7f)
                {
                    Shoot();
                }
            }
        }
        
       
	}
    // used in Animator
    public void Shoot()
    {
        GameObject projectile = Instantiate(inkSquirt, position, Quaternion.identity);
        
        projectile.GetComponent<Rigidbody2D>().velocity = transform.up * 7;
        FindObjectOfType<SquidAnimationScript>().shoot = false;
        canShoot = false;
        StartCoroutine("CanShootBool");
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        { 
            StartCoroutine(Frozen());
        }
    }


    IEnumerator CanShootBool()
    {

        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }


    IEnumerator Frozen()
    {
        isPaused = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent = iceBlock.transform;
        yield return new WaitForSeconds(6f);
        isPaused = false;
        gameObject.transform.parent = prefabAnim;
        Destroy(iceBlock);


    }


}
