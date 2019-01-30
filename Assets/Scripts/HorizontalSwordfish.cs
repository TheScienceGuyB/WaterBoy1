using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSwordfish : MonoBehaviour {
    public Transform pos1;
    public Transform pos2;
    public GameObject freeze;
    public float timeTillRepeat;
    public float timer;
    public bool frozen = false;
    Animator myAnim;
    void Start()
    {
        //InvokeRepeating("StartCo", 0, timeTillRepeat);
        myAnim = GetComponent<Animator>();
        freeze = GameObject.FindWithTag("FreezePower");
    }

    private void Update()
    {
        if (frozen == false)
        {
            timer += Time.deltaTime;
            if (timer >= 0 && timer <= (timeTillRepeat / 2))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos2.position.x, pos2.position.y), 10 * Time.deltaTime);
                myAnim.Play("SwimmingHSwordF");

            }
            if (timer > (timeTillRepeat / 2) && timer <= timeTillRepeat)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos1.position.x, pos1.position.y), 10 * Time.deltaTime);
                myAnim.Play("SwimmingHSwordFLeft");
            }
            if (timer >= timeTillRepeat + .001f)
            {
                timer = 0;
            }
        }
    }



    void StartCo()
    {
       // StartCoroutine(Move1());
    }


    IEnumerator Move1()
    {
        if (frozen == false)
        {
            while (transform.position.x != pos2.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos2.position.x, pos2.position.y), 10 * Time.deltaTime);
                myAnim.Play("SwimmingHSwordF");
                yield return null;
            }
            myAnim.Play("FlipLeft");
            yield return new WaitForSeconds(.2f);

            while (transform.position.x != pos1.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos1.position.x, pos1.position.y), 10 * Time.deltaTime);
                myAnim.Play("SwimmingHSwordFLeft");
                yield return null;
            }
            myAnim.Play("FlipRight");
            yield return new WaitForSeconds(.2f);
            //yield return new WaitForSeconds(1);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
        }

        StartCoroutine(DisableCollider());
    }

    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(iceBlock);
        frozen = false;



    }
    IEnumerator DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.4f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
