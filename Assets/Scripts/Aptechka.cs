using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aptechka : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Aptechka");
            GameObject.Find("HealthBar").GetComponent<HealthBar>().GiveHealth(10);
            Destroy(gameObject);
        }
    }
}
