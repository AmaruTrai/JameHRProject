using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public const int hourinaday = 24;
    public const int minutesinHour = 60;

    public float dayduration = 4800f;

    [SerializeField] float totaltime = 0;

    float currentTime = 0;

    public Text timertext;

    //public GameObject stoptext;
    public GameObject loosepanel;

    //public bool StopedClock;

    //public bool stoponlyonce;

    private void Start()
    {
        timertext = GetComponent<Text>();
        totaltime = 1800f;
        Time.timeScale = 1f;
        //StopedClock = false;
        //stoponlyonce = true;
    }
    private void Update()
    {
        totaltime += Time.deltaTime;
        currentTime = totaltime % dayduration;

        timertext.text = Clock24hour();

    if(totaltime >= 3400f)
    {
        loosepanel.SetActive(true);
        Time.timeScale = 0f;
    }

    /*if(StopedClock == true && stoponlyonce == true) 
    {
        stoptext.SetActive(false);
        stoponlyonce = false;
    }
    if(StopedClock == true && stoponlyonce == false) 
    {
        stoptext.SetActive(true);
        stoponlyonce = true;
        StopedClock = false;
    }
    */
    }

    public float GetHour() 
    {
        return currentTime * hourinaday / dayduration;

    }

    public float GetMinutes() 
    {
        return (currentTime * hourinaday * minutesinHour / dayduration) % minutesinHour;
    }

    public string Clock24hour() 
    {
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    /*public void StopClock() 
    {
        StopedClock = true;
    }

    public void ContinueClock() 
    {
        StopedClock = false;
    }
    */

    public void MinusTime() 
    {
        totaltime += 1000f;
    }

    //You can create other functions that will change the amount of time
}