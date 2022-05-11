using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Seagull : MonoBehaviour
{


    private GameManager gameManager;


    public float speed = 700.0f;
    public float bounceSpeed = 100.0f;
    public float rotationSpeed = 5.5f;

    public float boundary = 15.0f;

    private Rigidbody seagullRb;
    private Animator seagullAnim;

    private Vector3 startPos;
    private Vector3 chipsPos;


    // Random Fly Away target
    private float xFlyAwayRange = 25.0f;
    private float yFlyAway = 12.0f;
    private float zFlyAwayRange = 25.0f;
    private Vector3 flyAwayPos;


    // Rotation Vectors
    private Vector3 targetDirection;
    private Vector3 targetDirectionAway;
    private Quaternion LookDirection;
    private Quaternion LookDirectionAway;



    public bool playerContact = false;
    public bool batContact = false;
    public bool outOfBounds;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        flyAwayPos = new Vector3(Random.Range(-xFlyAwayRange, xFlyAwayRange), yFlyAway, Random.Range(-zFlyAwayRange, zFlyAwayRange));



        seagullRb = GetComponent<Rigidbody>();
        seagullAnim = GetComponent<Animator>();


        // Audio - play on awake

        GetComponent<AudioSource>().playOnAwake = true;

    
    }


    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.CompareTag("Fries"))
            
        {

            playerContact = true;
            seagullAnim.SetBool("IsEating", true);
            
            // Delayed dissapearance
            Invoke("ChipEaten", 1.0f);

            // Plays a crunching sound

            gameManager.crunchingNoise.GetComponent<AudioSource>().Play();

            // Engage haptics

            gameManager.SendHapticsLH();

            Debug.Log("He's eaten your chips mate!");

        }




        else if (other.gameObject.CompareTag("Bat"))
        {
            playerContact = true;
            // ACTION - just put fly away function here? TEST
            batContact = true;

            // Play sound

            gameManager.birdHitSound.GetComponent<AudioSource>().Play();

            // Seagull cry stops as it flies away

            GetComponent<AudioSource>().Stop();

            // Engage haptics

            gameManager.SendHapticsRH();

            Debug.Log("Projectile hit");
        }


    }

    private void ChipEaten()
    {
        Destroy(gameObject);
        gameManager.SetScore();
        
        //gameManager.score -= gameManager.score;

        Debug.Log(gameManager.score);
    }
    

    private void FlyAway()
    {
        seagullRb.AddForce(bounceSpeed * Time.deltaTime * targetDirectionAway);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookDirectionAway, Time.deltaTime * rotationSpeed);
    }


    private bool CheckOutofBounds()
    {
        if (transform.position.x > boundary || transform.position.x < -boundary)
        {
            outOfBounds = true;
        }

        else if (transform.position.y > boundary || transform.position.y < -boundary)
        {
            outOfBounds = true;
        }

        else if (transform.position.z > boundary || transform.position.z < -boundary)
        {
            outOfBounds = true;
        }

        else

        {
            outOfBounds = false;
        }

        return outOfBounds;
    }

    


    // Update is called once per frame
    void Update()
    {
        chipsPos = gameManager.chips.transform.position;
        targetDirection = chipsPos - startPos;
        targetDirectionAway = flyAwayPos - chipsPos;

        LookDirection = Quaternion.LookRotation(targetDirection);
        LookDirectionAway = Quaternion.LookRotation(targetDirectionAway);




        // Objects travelling towards the player

        if (!playerContact)
        {
            seagullRb.AddForce(speed * Time.deltaTime * (targetDirection));
            transform.rotation = Quaternion.Slerp(transform.rotation, LookDirection, Time.deltaTime * rotationSpeed);

        }

        // Seagulls fly away if come to contact with the bat
        
        if (batContact)
        {
            FlyAway();
        }


        // Destroy objects which are too far away
       
        CheckOutofBounds();

        if (outOfBounds)
        {
            Destroy(gameObject);
        }

    }
}
