using UnityEngine;
using System.Collections;

public class SeagullCharacter : MonoBehaviour {
    public Animator seagullAnimator;
    public float seagullSpeed = 1f;
    Rigidbody seagullRigid;
    public bool isFlying = false;
    public float upDown = 0f;
    public float forwardAcceleration = 0f;
    public float yawVelocity = 0f;
    public float groundCheckDistance = 5f;
    public bool isGrounded = true;
    public float forwardSpeed = 0f;
    public float maxForwardSpeed = 3f;
    public float meanForwardSpeed = 1.5f;
    public float speedDumpingTime = .1f;
    public float groundCheckOffset = 0.1f;
    float soaringTime = 0f;
    public bool isLived = true;

    void Start()
    {
        seagullAnimator = GetComponent<Animator>();
        seagullAnimator.speed = seagullSpeed;
        seagullRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        soaringTime = soaringTime + Time.deltaTime;
        GroundedCheck();
    }

    void GroundedCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * groundCheckOffset, Vector3.down, out hit, groundCheckDistance))
        {
            if (!isFlying || (isFlying && soaringTime > 2f))
            {
                Landing();
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
            seagullAnimator.SetBool("IsGrounded", false);
        }
    }

    public void SpeedSet(float animSpeed)
    {
        seagullAnimator.speed = animSpeed;
    }

    public void Landing()
    {
        seagullAnimator.SetBool("IsGrounded", true);
        seagullAnimator.SetBool("IsFlying", false);

        seagullAnimator.applyRootMotion = true;
        seagullRigid.useGravity = true;
        isFlying = false;
    }

    public void Soar()
    {
        if (isGrounded && isLived)
        {
            soaringTime = 0f;
            seagullAnimator.SetBool("IsGrounded", false);
            seagullAnimator.SetBool("IsFlying", true);
            seagullAnimator.SetTrigger("Soar");
            seagullRigid.useGravity = false;
            isGrounded = false;
            forwardAcceleration = 0f;
            forwardSpeed = 0f;
            upDown = 0f;
            seagullAnimator.applyRootMotion = false;
            isFlying = true;
        }
    }

    public void Attack()
    {
        seagullAnimator.SetTrigger("Attack");
    }

    public void Hit()
    {
        seagullAnimator.SetTrigger("Hit");
    }


    public void EatEnd()
    {
        seagullAnimator.SetBool("IsEating", false);
        isLived = false;
    }

    public void EatStart()
    {
        seagullAnimator.SetBool("IsEating", true);
        isLived = true;
    }


    public void Move()
    {
        seagullAnimator.SetFloat("Turn", yawVelocity);
        seagullAnimator.SetFloat("UpDown", upDown);
    
        if (isFlying)
        {
            seagullAnimator.SetFloat("Forward", forwardAcceleration);
            if (soaringTime < 2f)
            {
                forwardSpeed = soaringTime * meanForwardSpeed;
                upDown = soaringTime*0.3f;

            }

            if (forwardAcceleration < 0f)
            {
                seagullRigid.velocity = transform.up * upDown + transform.forward * forwardSpeed;
            }
            else
            {
                seagullRigid.velocity = transform.up * (upDown + (forwardSpeed - meanForwardSpeed)) + transform.forward * forwardSpeed;
            }
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * yawVelocity * 100f);

            forwardSpeed = Mathf.Lerp(forwardSpeed, 0f, Time.deltaTime * speedDumpingTime);
            forwardSpeed = Mathf.Clamp(forwardSpeed + forwardAcceleration * Time.deltaTime, 0f, maxForwardSpeed);
            upDown = Mathf.Lerp(upDown, 0, Time.deltaTime * 3f);

        }
        else
        {
            seagullAnimator.SetFloat("Forward", forwardAcceleration);
        }
    }
}