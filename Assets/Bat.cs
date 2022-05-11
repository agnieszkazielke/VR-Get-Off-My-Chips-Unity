using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject handModel;
    public GameObject batModel;

public void SwitchToHandController()
    {
        handModel.gameObject.SetActive(true);
        batModel.gameObject.SetActive(false);
    }


    public void SwitchToBatController()
    {
        handModel.gameObject.SetActive(false);
        batModel.gameObject.SetActive(true);
    }

}
