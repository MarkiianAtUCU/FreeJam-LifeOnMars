using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryFirst : MonoBehaviour {
    public int Oxygen;
    public int Hydrogen;
    public int Water;
    public int MetalFragment;
    public int Slime;
    public int UnstableOrganic;
    public int Ammo;

    public Text gOxygen;
    public Text gHydrogen;
    public Text gWater;
    public Text gMetalFragment;
    public Text gSlime;
    public Text gUnstableOrganic;
    public Text gAmmo;

    public Button Decomp;
    public Button Slime_dec;
    public Button AmmoGen;

    public Image O2stat;
    public Image H2stat;
    public Text Ammo_Text;

    public int dmg;
    public float CurrentO2=500;
    public float CurrentH2=500;

    private float lastDamage;

    private void Start()
    {
        lastDamage = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad - lastDamage >= 1)
        {
            lastDamage = Time.timeSinceLevelLoad;
            Oxygen -= dmg;
        }

        O2stat.fillAmount = (float) Oxygen / 500;
        H2stat.fillAmount = (float) Hydrogen / 500;
        Ammo_Text.text = Ammo.ToString();
    }

    private void FixedUpdate()
    {

        if (Water >= 2)
        {
            Decomp.interactable = true;
        }
        else
            Decomp.interactable = false;

        if (Slime >= 1)
        {
            Slime_dec.interactable = true;
        }
        else
            Slime_dec.interactable = false;

        if (UnstableOrganic>=1 && MetalFragment >= 1)
        {
            AmmoGen.interactable = true;
        }
        else
            AmmoGen.interactable = false;


        gOxygen.text = Oxygen.ToString();
        gHydrogen.text = Hydrogen.ToString();
        gWater.text = Water.ToString();
        gMetalFragment.text = MetalFragment.ToString();
        gSlime.text = Slime.ToString();
        gUnstableOrganic.text = UnstableOrganic.ToString();
        gAmmo.text = Ammo.ToString();


    }

    public void WaterToChem()
    {
        Oxygen += 1;
        Hydrogen += 2;
        Water -= 2;
    }

    public void SlimetoSMth()
    {
        Slime -= 1;
        UnstableOrganic += 1;
        Water += 1;
    }

    public void GimmeAmmo()
    {
        MetalFragment -= 1;
        UnstableOrganic -= 1;
        Ammo += 5;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Resource") {
            Resource res = other.GetComponent<Resource>();

            if (res.type =="Oxygen")
            {
                Oxygen +=res.ammount;
            }

            if (res.type == "Hydrogen")
            {
                Hydrogen += res.ammount;
            }

            if (res.type == "Metal")
            {
                MetalFragment += res.ammount;
            }

            if (res.type == "Ice")
            {
                Water += res.ammount;
            }

            if (res.type == "Slime")
            {
                Slime += res.ammount;
            }
            Destroy(other.gameObject);
        }
        
    }
}
