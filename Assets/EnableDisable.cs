using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour {

    public GameObject gameO;
    bool enabledGO;
    bool disabledGO;

	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameO.SetActive(true);
            enabledGO = true;
            disabledGO = false;
            Debug.Log("enableLevel");
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameO.SetActive(false);
            disabledGO = true;
            enabledGO = false;
                
        }
    }
    
        
    


}
