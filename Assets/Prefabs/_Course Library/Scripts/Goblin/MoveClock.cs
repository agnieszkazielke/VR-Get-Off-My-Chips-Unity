using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClock : MonoBehaviour
{
    public int currentHour;
    public int currentMinute;
    public int currentSecond;


    private GameObject hourShow;
    private GameObject minuteShow;
    private GameObject secondShow;


    // Start is called before the first frame update
    void Start()
    {

        currentHour = DateTime.Now.Hour;
        currentMinute = DateTime.Now.Minute;
        currentSecond = DateTime.Now.Second;


        hourShow = GameObject.Find("Clock_Analog_A_Hour");
        minuteShow = GameObject.Find("Clock_Analog_A_Minute");
        secondShow = GameObject.Find("Clock_Analog_A_Second");


        hourShow.transform.Rotate(0, 30.0f*currentMinute/60 + 30.0f*currentHour, 0 * Time.deltaTime);
        minuteShow.transform.Rotate(0, 6.0f * currentMinute, 0 * Time.deltaTime);
        secondShow.transform.Rotate(0, 6.0f * currentSecond, 0 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        // 1 hour ---> 60 minutes ---> 3600 seconds
        secondShow.transform.Rotate(0, 6.0f * Time.deltaTime, 0);
        minuteShow.transform.Rotate(0, 0.1f * Time.deltaTime, 0);
        hourShow.transform.Rotate(0, 0.008333f * Time.deltaTime, 0);
    }
}
