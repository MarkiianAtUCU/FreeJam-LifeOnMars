using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public Image Bar;
    public int MaxHealth;

    public AudioClip death;

    private int Health = 50;
	// Use this for initialization
	void Start () {
        Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Damage(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            GetComponent<AudioSource>().clip = death;//MakeSubclip(shot, 0, 0.9f);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
