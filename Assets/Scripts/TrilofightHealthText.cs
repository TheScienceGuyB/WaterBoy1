using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrilofightHealthText : MonoBehaviour {
    private Text trilohealth;
    void Start()
    {
        trilohealth = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        trilohealth.text = "" + Mathf.RoundToInt(value);
    }
}
