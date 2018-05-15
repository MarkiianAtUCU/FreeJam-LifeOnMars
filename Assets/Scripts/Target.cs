using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int damage = 10;
    public float lifespan = 5.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifespan);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "weapon" && other.gameObject.tag != "Player")
        {
            Debug.Log(other.gameObject.ToString());
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
                Destroy(gameObject);
            }
            Destroy(gameObject);

        }
    }
}
