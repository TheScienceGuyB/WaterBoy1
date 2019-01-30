using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    public Transform playerCheck;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    public Animator myAnim;
    public bool playerNear;
    public GameObject freeze;
    public Transform prefabAnim;
    public bool frozen = false;
    public bool disableColliders;

    void Start()
    {

        prefabAnim = transform.parent;
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
    }
	
	// Update is called once per frame
	void Update () {

        

        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        if (playerNear == true)
        {
            myAnim.SetBool("playerClose", true);
        }
        if (disableColliders == true)
        {
            foreach (CircleCollider2D c in GetComponents<CircleCollider2D>())
            {
                c.enabled = false;
            }
        }
        else if (disableColliders == false)
        {
            foreach (CircleCollider2D c in gameObject.GetComponents<CircleCollider2D>())
            {
                c.enabled = true;
            }
        }


	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
            disableColliders = true;
            
        }
    }


    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent = iceBlock.transform;
        yield return new WaitForSeconds(3.34f);
        frozen = false;
        gameObject.transform.parent = prefabAnim;
        disableColliders = false;
        Destroy(iceBlock);
        

    }




}
