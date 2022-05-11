using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public GameObject knife;
    public GameObject butterLayer;
    public GameObject hamOnBread;
    public GameObject cheeseOnBread;
    public GameObject topBread;

    public bool butterSpread = false;
    public bool hamAdded = false;
    public bool cheeseAdded = false;
    public bool sandwichComplete = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            Debug.Log("Knife Detected");

            if (other.gameObject.GetComponent<Knife>().knifeOnButter == true)
            {
                butterLayer.gameObject.SetActive(true);
                butterSpread = true;
            }

        }

        if (other.gameObject.CompareTag("Ham"))
        {
            Debug.Log("Ham Detected");
            hamOnBread.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            hamAdded = true;
        }

        if (other.gameObject.CompareTag("Cheese"))
        {
            Debug.Log("Cheese Detected");
            cheeseOnBread.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            cheeseAdded = true;
        }


        if (other.gameObject.CompareTag("Bread"))
        {
            if (butterSpread && hamAdded && cheeseAdded)
            {
                Debug.Log("Bread Detected");
                topBread.gameObject.SetActive(true);
                other.gameObject.SetActive(false);
                sandwichComplete = true;
                gameObject.tag = "Sandwich";

            }


        }


    }
}
