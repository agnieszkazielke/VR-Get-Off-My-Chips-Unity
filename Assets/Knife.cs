using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public GameObject butter;
    public bool knifeOnButter = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Butter"))
        {
            Debug.Log("Butter Detected");
            butter.gameObject.SetActive(true);
            knifeOnButter = true;

        }
    }

}
