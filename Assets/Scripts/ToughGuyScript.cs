using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughGuyScript : MonoBehaviour {

    public GameObject freeze;
    public Transform prefabAnim;
    public bool frozen;


    private void Start()
    {
        prefabAnim = transform.parent;
        freeze = GameObject.FindWithTag("FreezePower");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            frozen = true;
            StartCoroutine(Frozen());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }


    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent = iceBlock.transform;
        yield return new WaitForSeconds(2.51f);
        frozen = false;
        gameObject.transform.parent = prefabAnim;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(iceBlock);


    }


}
