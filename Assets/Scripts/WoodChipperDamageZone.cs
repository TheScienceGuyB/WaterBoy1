using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WoodChipperDamageZone : MonoBehaviour {

    public Slider slider;
    public GameObject Boss;
    public Animator bossAnim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Boss.GetComponent<WoodChipperHealth>().health;
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WaterBall")
        {
            Boss.GetComponent<WoodChipperHealth>().health -= 1;
            bossAnim.Play("Transition");
        }
    }


}
