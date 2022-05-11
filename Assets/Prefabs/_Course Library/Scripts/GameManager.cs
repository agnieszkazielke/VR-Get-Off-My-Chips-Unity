using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;


public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;

    // score (number of chips left)


    private int startScore = 5;
    public int score;


    // location of the chips
    public GameObject chips;

    // crunching noise host - chips. Noise triggered when seagull succefully eats the chips
    public GameObject crunchingNoise;
    public GameObject massAttackSound;
    public GameObject birdHitSound;



    // Spawning seagulls

    public GameObject seagullPrefab;


    // Spawning
    private int difficultyCounter;
    public float spawnRate;

    private float spawnRateEasy = 5.0f;
    
    private int mediumLvlThreshold = 15;
    private float spawnRateMedium = 3.5f;
    
    private int hardLvlThreshold = 25;
    private float spawnRateHard = 2.0f;

    private float xSpawnRange = 15.0f;
    private float ySpawn = 5.0f;
    private float zSpawnRange = 15.0f;


        
    // UI

    public GameObject gameMenu;
    public GameObject mainMenuText;
    public GameObject gameOverText;
    public GameObject startGameButton;
    public GameObject goBackButton;
    public GameObject massAttack;

    public XRBaseController rightMenuController;

    public XRBaseController rightGameController;
    public XRBaseController leftGameController;
    public GameObject righHandRay;


    public GameObject batControllerPrefab;

    // Levels 

    public GameObject levelOneText;
    public GameObject levelTwoText;
    public GameObject levelThreeText;


    // Mass Attack

    private int massAttackThreshold = 7;
    private float massAttackRate = 60.0f;
    private int massAttackTime = 2;

    private bool massAttackOn = false;




    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {
        // Check if controller found

        
        
        if (rightGameController == null)
            Debug.LogWarning("Reference to the Controller is not set in the Inspector window, this behavior will not be able to send haptics. Drag a reference to the controller that you want to send haptics to.", this);

    }


    IEnumerator SpawnRoutine()
    {
        while(isGameActive)
        {
                        
            Instantiate(seagullPrefab,
                        new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, Random.Range(-zSpawnRange, zSpawnRange)), Quaternion.identity);

            difficultyCounter = difficultyCounter + 1;

            yield return new WaitForSeconds(spawnRate);
        }
    }

    IEnumerator MassAttackRoutine()
    {
        while (isGameActive)
        {

            MassAttack();

            Invoke("EndMassAttack", 38.0f);

            yield return new WaitForSeconds(massAttackRate);
        }
    }

    public void SetScore()
    {
        score = score - 1;

    }

    public void StartGame()
    {
        // Actions for if reloading a new game
        StopAllCoroutines();

        // Destroy any seagulls in the scene

        GameObject[] birds = GameObject.FindGameObjectsWithTag("Seagull");
        foreach (var bird in birds)
        {
            Destroy(bird);
        }
       
        // Manage prior mass attack 
        if (massAttackOn)
        {
            EndMassAttack();

        }

        else
        {
            Time.timeScale = 1;
        }

        // General
        
        isGameActive = true;
        score = startScore;
        difficultyCounter = 0;
        spawnRate = spawnRateEasy;
        gameMenu.gameObject.SetActive(false);
        rightMenuController.gameObject.SetActive(false);
        rightGameController.gameObject.SetActive(true);
        righHandRay.gameObject.SetActive(false);


        // Start spawning seagulls again

        StartCoroutine(SpawnRoutine());
        
    }

    private void DisplayLevel(GameObject level)
    {
        level.gameObject.SetActive(true);
    }

    private void WipeLevels()
    {
        levelOneText.SetActive(false);
        levelTwoText.SetActive(false);
        levelThreeText.SetActive(false);
    }

    public void DoubleGameSpeed()
    {

        Time.timeScale = massAttackTime;
        massAttack.gameObject.SetActive(true);

    }

    public void MassAttack()
    {
        massAttackOn = true;
        massAttackSound.GetComponent<AudioSource>().Play();
        
        Invoke("DoubleGameSpeed", 4.0f);

    }

    public void EndMassAttack()
    {
        massAttackOn = false;
        Time.timeScale = 1;
        massAttack.gameObject.SetActive(false);
        massAttackSound.GetComponent<AudioSource>().Stop();
    }

    public void SendHapticsRH()
    {
        rightGameController.SendHapticImpulse(0.6f, 0.7f);


    }

    public void SendHapticsLH()
    {
        leftGameController.SendHapticImpulse(0.8f, 1.0f);


    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameMenu.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(true);
        goBackButton.gameObject.SetActive(true);


        rightMenuController.gameObject.SetActive(true);
        rightGameController.gameObject.SetActive(false);
        righHandRay.gameObject.SetActive(true);

        // Managing mass attack
        if (massAttackOn)
        {
            massAttackSound.GetComponent<AudioSource>().Pause();
        }

    }
    public void ResumeGame()
    {
        
        gameMenu.gameObject.SetActive(false);
        rightMenuController.gameObject.SetActive(false);
        rightGameController.gameObject.SetActive(true);
        righHandRay.gameObject.SetActive(false);

        // Managing mass attack

        if (massAttackOn)
        {
            massAttackSound.GetComponent<AudioSource>().Play();
            Time.timeScale = massAttackTime;
        }

        else
        {
            Time.timeScale = 1;
        }

    }

    // test the gameover
    private void GameOver()
    {
        isGameActive = false;
        gameMenu.gameObject.SetActive(true);
        goBackButton.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(true);
        mainMenuText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);

        rightMenuController.gameObject.SetActive(true);
        rightGameController.gameObject.SetActive(false);
        righHandRay.gameObject.SetActive(true);

        massAttackSound.GetComponent<AudioSource>().Stop();
    }




// Update is called once per frame
void Update()
    {
        // Difficulty level increase rules
        if (isGameActive)
        {
            if (difficultyCounter == 1)
            {
                DisplayLevel(levelOneText);
                Invoke("WipeLevels", 2.5f);
            }


            if (difficultyCounter == mediumLvlThreshold)
            {
                DisplayLevel(levelTwoText);
                Invoke("WipeLevels", 2.5f);
                spawnRate = spawnRateMedium;
            }

            if (difficultyCounter == hardLvlThreshold)
            {
                DisplayLevel(levelThreeText);
                Invoke("WipeLevels", 2.5f);
                spawnRate = spawnRateHard;
            }
        }

        

        // Mass attack rules

        if (difficultyCounter == massAttackThreshold)
        {
            StartCoroutine(MassAttackRoutine());
        }


        // When score goes down to zero, game ends
        if (score < 1)
        {
            GameOver();
        }



    }


}
