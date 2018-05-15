using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public GameObject InventoryCont;
    private bool showed = false;
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (showed)
            {
                InventoryCont.SetActive(false);
                showed = false;
            }
            else
            {
                InventoryCont.SetActive(true);
                showed = true;
            }
        }
        
        
	}
}
