using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public int maxHealth;
    public GameObject cubicle;
    public float offset;
    public GameObject cam;
    public GameObject player;
    
    private int health;
    private Vector3 start;
    private GameObject[,] cubicles;
    private bool dropped = false;
	// Use this for initialization
	void Start () {
        health = maxHealth;

        cubicles = new GameObject[50,15];
        
        for (int i=0; i<50; i++) {
            FillColumn(i);
		}
	}

	
	// Update is called once per frame
	void Update () {
        transform.rotation = cam.transform.rotation;
    }
	
	void FillColumn(int index) {
        start = gameObject.transform.position - new Vector3(offset * 25, 0, 0);
        Vector3 columnStart = start + new Vector3(offset*index, 0, 0);
        int ind = 0;
	    for (int i=0; i<5; i++) {
            for (int  j=0; j<3; j++)
            {
                GameObject newCubicle = Instantiate(cubicle, columnStart + new Vector3(0, offset * i, offset * j), transform.rotation) as GameObject;
                newCubicle.transform.parent = gameObject.transform;
                cubicles[index, ind] = newCubicle;
                ind++;
            }
	    }
	}

    void DropColumn(int index)
    {
        for (int i=0; i<15; i++)
        {
            cubicles[index, i].transform.parent = null;
            cubicles[index, i].AddComponent<Rigidbody>();
            Destroy(cubicles[index, i], 20);
        }
    }

    public void GiveHealth(int amount)
    {
        int newHealth = Mathf.Min(maxHealth, health + amount);

        for (int i=health; i<newHealth; i++)
        {
            FillColumn(i);
        }

        health = newHealth;
    }

    public void TakeHealth(int amount)
    {
        int newHealth = Mathf.Max(0, health - amount);

        for (int i=newHealth; i<health; i++)
        {
            DropColumn(i);
        }

        health = newHealth;

        if (health <= 0 )
        {
            Destroy(player);
        }

    }
}
