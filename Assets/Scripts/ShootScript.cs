using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public GameObject rocket;
    public float power;
    public float shotTimeout = 0.3f;
    public float reloadTime = 3.0f;
    public AudioClip shot;

    private float lastShot;
    private int shotsFired = 0;

    public GameObject Inv;

    void Start()
    {
        lastShot = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        InventoryFirst invfi = Inv.GetComponent<InventoryFirst>();
        int New_Ammo=invfi.Ammo;
        if (Input.GetButtonDown("Fire1") && New_Ammo > 0)
        {
            print(New_Ammo);
            if (shotsFired < 4)
            {
                if (Time.timeSinceLevelLoad - lastShot > shotTimeout)
                {
                    Fire();
                    shotsFired++;
                    invfi.Ammo-=1;
                }
            }
            else
            {
                if (Time.timeSinceLevelLoad - lastShot > reloadTime)
                {
                    Fire();
                    shotsFired = 1;
                    invfi.Ammo -= 1;
                }
            }
        }
    }

    void Fire()
    {
        GameObject newRocket = Instantiate(rocket, transform.position, transform.rotation) as GameObject;

        if (!newRocket.GetComponent<Rigidbody>())
        {
            newRocket.AddComponent<Rigidbody>();
        }
        newRocket.GetComponent<Rigidbody>().useGravity = false;

        newRocket.transform.RotateAround(newRocket.transform.position, newRocket.transform.up, 180f);

        newRocket.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

        lastShot = Time.timeSinceLevelLoad;

        GetComponent<AudioSource>().clip = MakeSubclip(shot, 0, 0.9f);
        GetComponent<AudioSource>().Play();
    }

    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 1, frequency, false);
        /* Create a temporary buffer for the samples */
        float[] data = new float[samplesLength];
        /* Get the data from the original clip */
        clip.GetData(data, (int)(frequency * start));
        /* Transfer the data to the new clip */
        newClip.SetData(data, 0);
        /* Return the sub clip */
        return newClip;
    }

}