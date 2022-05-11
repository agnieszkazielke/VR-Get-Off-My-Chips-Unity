using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjects : MonoBehaviour
{

    //public GameObject player;
    public int projectileType;
    public float speed = 500.0f;
    public float velocityBoost = 1.5f;
    public float boundary = 15.0f;
    private GameManager gameManager;
    private Rigidbody projectileRb;
    private Vector3 startPos;
    private Vector3 playerPos;
    


    public bool playerContact;
    public bool outOfBounds;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        playerPos = gameManager.chips.transform.position;
        //playerPos = player.transform.position;
        //playerPos = new Vector3(0, 0, 0);
        projectileRb = GetComponent<Rigidbody>();

        // Objects travelling towards the player
        projectileRb.AddForce(speed * Time.deltaTime * (playerPos - startPos));



    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("PlayerBody"))

        {
            // In this scenario, it bounces back (disabled)
            //playerContact = true;
            //projectileRb.AddForce(speed * Time.deltaTime * (startPos - playerPos));


            // Object will dissappear
            Destroy(gameObject);

        }


        else if (other.gameObject.CompareTag("Projectile"))
        {
            // same projectiles colliding
            // ADD CODE TO GAME MANAGER

            if (other.gameObject.GetComponent<FlyingObjects>().projectileType == projectileType)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                Debug.Log("Score!");
            }

            // different projectiles colliding 

            else
            {
                projectileRb.velocity = projectileRb.velocity * velocityBoost;
                Debug.Log("Bounce");
            }
        }

        else if (other.gameObject.CompareTag("Bat"))
        {
            projectileRb.velocity = projectileRb.velocity * velocityBoost;
            Debug.Log("Projectile hit");
        }


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

        // Destroy objects which are too far away
        CheckOutofBounds();

        if (outOfBounds)
        {
            Destroy(gameObject);
        }

    }
}
