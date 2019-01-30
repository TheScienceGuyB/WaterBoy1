using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public Sprite switchOff;
    public Sprite switchOn;
    public GameObject door;
    public bool switchIsOn;
    private SpriteRenderer switchSprite;
    private AudioSource audioClip;



	void Start () {
        switchSprite = GetComponent<SpriteRenderer>();
        audioClip = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switchSprite.sprite = switchOn;
            audioClip.Play();
            Destroy(door.gameObject);
            switchIsOn = true;
        }
    }

}
