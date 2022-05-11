using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladle : MonoBehaviour
{
    public GameObject soup;
    public bool ladleFull = false;

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saucepan"))
        {
            Debug.Log("Saucepan Detected");

            if (other.gameObject.GetComponent<Saucepan>().soupReadyForServing == true)
            {
                soup.gameObject.SetActive(true);
                ladleFull = true;
            }
        }
    }
}

