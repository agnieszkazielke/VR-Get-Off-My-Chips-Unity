using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saucepan : MonoBehaviour
{

    public GameObject carrot;
    public GameObject carrotInPan;
    public GameObject parsnip;
    public GameObject parsnipInPan;
    public GameObject pumpkin;
    public GameObject pumpkinInPan;
    public GameObject soupUncooked;
    public GameObject soupCooked;
    public ParticleSystem steamEffect;

    public bool carrotsIn = false;
    public bool pumpkinIn = false;
    public bool parsnipIn = false;

    public bool saucepanFull = false;
    public bool soupReadyForServing = false;
    private float timeDelay = 5f;

    // Start is called before the first frame update
    public void SetCarrotsIn()
    {
        if (carrot.GetComponent<VegSlicing>().veg_Sliced == true)
        {
            carrot.gameObject.SetActive(false);
            carrotInPan.gameObject.SetActive(true);
            carrotsIn = true;
        }
    }

    public void SetPumpkinIn()
    {
        if (pumpkin.GetComponent<VegSlicing>().veg_Sliced == true)
        {
            pumpkin.gameObject.SetActive(false);
            pumpkinInPan.gameObject.SetActive(true);
            pumpkinIn = true;
        }
        
    }

    public void SetParsnipIn()
    {
        if (parsnip.GetComponent<VegSlicing>().veg_Sliced == true)
        {
            parsnip.gameObject.SetActive(false);
            parsnipInPan.gameObject.SetActive(true);
            parsnipIn = true;
        }

    }

    public void SetCarrotsOff()
    {
        carrotsIn = false;

    }

    public void SetPumpkinOff()
    {
        pumpkinIn = false;
    }

    public void SetParsnipOff()
    {
        parsnipIn = false;
    }

    // Update is called once per frame

    public void SoupChangeColor()
    {
        soupUncooked.SetActive(false);
        soupCooked.SetActive(true);
    }


    public void BoilSoup()
    {
        if (saucepanFull)
        {
            Invoke("SoupChangeColor", timeDelay);
            steamEffect.Play();
            soupReadyForServing = true;
        }
        
    }


    void Update()
    {
        if (carrotsIn && parsnipIn && pumpkinIn)
        {
            Debug.Log("SAUCEPAN LOADED");
            
            soupUncooked.gameObject.SetActive(true);

            saucepanFull = true;
        }
        else
        {
            saucepanFull = false;
        }
    }
}
