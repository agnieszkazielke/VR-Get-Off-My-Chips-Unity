using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{

    private GameManager gameManager;

    public GameObject scoreNumber;


    public GameObject fry1;
    public GameObject fry2;
    public GameObject fry3;
    public GameObject fry4;
    public GameObject fry5;
    public GameObject fry6;
    public GameObject fry7;
    public GameObject fry8;
    public GameObject fry9;
    public GameObject fry10;


    // Start is called before the first frame update

    public void ResetChips()
    {
        fry1.SetActive(true);
        fry2.SetActive(true);
        fry3.SetActive(true);
        fry4.SetActive(true);
        fry5.SetActive(true);
        fry6.SetActive(true);
        fry7.SetActive(true);
        fry8.SetActive(true);
        fry9.SetActive(true);
        fry10.SetActive(true);
    }
    
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score == 5)
        {
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }


        // very basic - test in VR

        if (gameManager.score == 4)
        {
            fry1.SetActive(false);
            fry2.SetActive(false);
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }

        if (gameManager.score == 3)
        {
            fry3.SetActive(false);
            fry4.SetActive(false);
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }

        if (gameManager.score == 2)
        {
            fry5.SetActive(false);
            fry6.SetActive(false);
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }

        if (gameManager.score == 1)
        {
            fry7.SetActive(false);
            fry8.SetActive(false);
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }

        if (gameManager.score == 0)
        {
            fry9.SetActive(false);
            fry10.SetActive(false);
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.score.ToString();
        }

        if (gameManager.isGameActive == false)
        {
            ResetChips();
        }
    }
}
