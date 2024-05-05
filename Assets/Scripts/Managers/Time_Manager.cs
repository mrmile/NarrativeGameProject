using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour
{
    // 1 TU = 1s

    // 5 min in-game = 1 TU
    // 1 hour in-game = 12 TU
    // 1 day in-game = 288TU 

    const float secondsPerTimeUnit = 1.0f;

    float secondsSinceLastStep;
    
    
    int currentTimeUnits;
    int gameMinute;
    int gameHour;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        UpdateTimeValues();
        
    }

    void UpdateTimeValues()
    {
        secondsSinceLastStep += Time.deltaTime;
        if(secondsSinceLastStep >= secondsPerTimeUnit)
        {
            currentTimeUnits++;
            secondsSinceLastStep = 0;
        }

        gameMinute = currentTimeUnits * 5;

        if(gameMinute >= 60)
        {
            gameMinute = 0;
            gameHour++;
        }

        if(gameHour >= 24)
        {
            EndDay();
        }
       
    }

    void EndDay()
    {

    }

   public int GetCurrentTimeUnits()
   {
        return currentTimeUnits;
   }
    public int GetGameMinutes()
    {
        return gameMinute;
    }
    public int GetGameHours()
    {
        return gameHour;
    }

    public void SetCurrentTimeUnits(int timeUnits)
    {
        currentTimeUnits = timeUnits;
    }
    public void SetGameTime(int gameHour, int gameMinute)
    {
        this.gameHour = gameHour;
        this.gameMinute = gameMinute;
    }

    public void ResetGameTime()
    {
        secondsSinceLastStep = 0;
        currentTimeUnits = 0;
        gameMinute = 0;
        gameHour = 0;
    }
}
