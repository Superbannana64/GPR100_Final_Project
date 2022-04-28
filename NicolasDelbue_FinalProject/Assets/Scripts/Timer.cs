using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public static event Action<double> timerChange;
    public static event Action<int> dayChange;
    static private double timerNum = 0.0f;
    static private int dayNum = 1;
    static public bool timerOff = true;
    static private double time;
    static private double min;
    static private double hour;
    static public void ResetTimer()
    {
        timerNum = 0.0f;
        time = 0;
        min = 0;
        hour = 0;
        dayNum = 1;
    }
    static public int GetDay()
    {
        return dayNum;
    }
    static public void TimerSwitch()
    {
        timerOff = !timerOff;
    }
    static public void SetTimer(bool timer)
    {
        timerOff = timer;
    }
    void Start()
    {
        dayChange?.Invoke(dayNum);
    }
    void Update()
    {
        if(timerOff)
        {
            time += 1;
            if(time/30 == 1)
            {
                time = 0;
                min += .01;
                
            }
            double check = min/.59;
            //Debug.Log(check);
            if(check >= 1)
            {
                min = 0;
                hour += 1;
                //Debug.Log("Workin");
            }

            if(hour/24 >= 1)
            {
                hour = 0;
                dayNum++;
                dayChange?.Invoke(dayNum);
                //play some cool shiz
            }

            timerNum = hour+min;
            timerChange?.Invoke(timerNum);
        }
    }
}
