using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBassPlay : MonoBehaviour
{
    private int timer;
    public int timeLimit;
    public float speed;
    private bool forwards;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        forwards = true;
    }

    private void MoveForwards()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.Self);
    }

    private void MoveBackwards()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed, Space.Self);
    }

    private void RestartTimer()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1;

        if (forwards)
        {
            MoveForwards();
        }

        if (!forwards)

        {
            MoveBackwards();
        }

                
        if (timer == timeLimit)
        {

            RestartTimer();
            forwards = !forwards;

        }


        


        
        
    }
}
