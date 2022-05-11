using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCheck : MonoBehaviour
{

    public bool plateServed;

    // Start is called before the first frame update
    public void SetPlateServed()
    {
        plateServed = true;
        Debug.Log("You served the dish");
    }

    public void UndoPlateServed()
    {
        plateServed = false;
        Debug.Log("You unserved the dish");
    }

    // Update is called once per frame

}
