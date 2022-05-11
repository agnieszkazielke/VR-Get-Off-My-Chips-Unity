using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMan : MonoBehaviour
{
    private int timer;
    public int timeLimit;
    public float speed;
    private bool upwards;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        upwards = true;

    }

    private void MoveUpwards()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.Self);
    }

    private void MoveDownwards()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.Self);
    }

    private void RestartTimer()
    {
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        timer = timer + 1;

        if (upwards)
        {
            MoveUpwards();
        }

        if (!upwards)

        {
            MoveDownwards();
        }


        if (timer == timeLimit)
        {

            RestartTimer();
            upwards = !upwards;
        }
    }

}
