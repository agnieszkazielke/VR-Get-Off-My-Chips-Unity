using UnityEngine;
using System.Collections;

public class SeagullUserController : MonoBehaviour {

    public SeagullCharacter seagullCharacter;
    public float upDownInputSpeed = 3f;


    void Start()
    {
        seagullCharacter = GetComponent<SeagullCharacter>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            seagullCharacter.Soar();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            seagullCharacter.Attack();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            seagullCharacter.Hit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            seagullCharacter.EatStart();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            seagullCharacter.EatEnd();
        }


        if (Input.GetKey(KeyCode.N))
        {
            seagullCharacter.upDown = Mathf.Clamp(seagullCharacter.upDown - Time.deltaTime * upDownInputSpeed, -1f, 1f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            seagullCharacter.upDown = Mathf.Clamp(seagullCharacter.upDown + Time.deltaTime * upDownInputSpeed, -1f, 1f);
        }
    }

    void FixedUpdate()
    {
        seagullCharacter.forwardAcceleration = Input.GetAxis("Vertical");
        seagullCharacter.yawVelocity = Input.GetAxis("Horizontal");

    }
}