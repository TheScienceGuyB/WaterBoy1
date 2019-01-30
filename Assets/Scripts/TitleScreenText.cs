using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenText : MonoBehaviour {

    private Text titleScreenText;
    public Save text;
	void Start () {
        titleScreenText = GetComponent<Text>();
	}

    public void Update()
    {
        Debug.Log(text.levelName);
        titleScreenText.text = text.levelName;
    }
}
