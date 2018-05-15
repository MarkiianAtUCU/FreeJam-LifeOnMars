using UnityEngine;

public class Laser : MonoBehaviour {

    public int damage = 1;
    public float range = 100f;
    public GameObject laser;

    public GameObject tracker;
    public GameObject Inv;

    public AudioClip shot;

    public float lastUse;
    public float timePerOne = 0.25f;

    private void Start()
    {
        lastUse=  Time.timeSinceLevelLoad;
        GetComponent<AudioSource>().clip = shot;
    }
    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            GetComponent<AudioSource>().clip = shot;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        } else{
            laser.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<AudioSource>().Stop();
        }
	}

    void Shoot()
    {
        InventoryFirst invfi = Inv.GetComponent<InventoryFirst>();
        if (invfi.Hydrogen>0)
        {
            if (Time.timeSinceLevelLoad - lastUse >= timePerOne)
            {
                lastUse = Time.timeSinceLevelLoad;
                invfi.Hydrogen -= 1;
            }
            
            RaycastHit hit;
            laser.GetComponent<MeshRenderer>().enabled = true;
            if (Physics.Raycast(tracker.transform.position, tracker.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().Damage(damage);
                }
            }
        } else
        {
            laser.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
}
