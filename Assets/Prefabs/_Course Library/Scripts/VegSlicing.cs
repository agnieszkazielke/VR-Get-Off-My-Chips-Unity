using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegSlicing : MonoBehaviour
{
    private int counter = 0;
    public bool veg_Sliced = false;
    public GameObject unslicedVeg;
    public GameObject slicedVeg;

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))

            {
            counter = counter + 1;
            Debug.Log("Veg Slicing" + counter);

                    }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 10)
        {
            unslicedVeg.gameObject.SetActive(false);
            slicedVeg.gameObject.SetActive(true);
            Debug.Log("Veg Sliced!");
            veg_Sliced = true;
        }
    }
}
