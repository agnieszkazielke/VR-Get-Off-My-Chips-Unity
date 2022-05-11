using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartersCheck : MonoBehaviour
{
    public bool olivesIn;
    public bool breadsticksIn;
    public bool hummusIn;
    public bool plateLoaded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOlivesOn()
    {
        olivesIn = true;
    }

    public void SetHummusOn()
    {
        hummusIn = true;
    }

    public void SetBreadSticksOn()
    {
        breadsticksIn = true;
    }

    public void SetOlivesOff()
    {
        olivesIn = false;
    }

    public void SetHummusOff()
    {
        hummusIn = false;
    }

    public void SetBreadSticksOff()
    {
        breadsticksIn = false;
    }


    private void Update()
    {
        if (olivesIn && breadsticksIn && hummusIn)
        {
            Debug.Log("PLATE LOADED");
            plateLoaded = true;
        }
        else
        {
            plateLoaded = false;
        }
    }

    // Update is called once per frame

}
