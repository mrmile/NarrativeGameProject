using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using static MapEventsManager;

public class Time_Manager : MonoBehaviour
{
    // 1 TU = 1s

    // 5 min in-game = 1 TU
    // 1 hour in-game = 12 TU
    // 1 day in-game = 288TU 

    const float secondsPerTimeUnit = 1.0f;
    const int timeUnitsPerGameMinute = 5;

    float secondsSinceLastStep;
    int timeUnitsSinceLastStep;
    
    int currentTimeUnits;
    int gameMinute;
    int gameHour;

    //---------------Map Events---------------
    int randomGameHour = 25;
    bool dayEventHapened = false;
    int randomEvent = 0;

    MapEventsManager mapEventsManager_;

    public bool EventsOnFirstDay = true;
    public bool noEventProbability = false;
    //----------------------------------------

    bool isTimePaused;
    void Start()
    {
        //---------------Map Events---------------
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

        if (EventsOnFirstDay == true) //Se puede dejar o quitar en función de si se decide que el primer dia pasen eventos.
        {
            StartDay();
        }
        //----------------------------------------
    }


    void FixedUpdate()
    {
        if(!isTimePaused) UpdateTimeValues();
        
    }

    void UpdateTimeValues()
    {
        secondsSinceLastStep += Time.deltaTime;
        if(secondsSinceLastStep >= secondsPerTimeUnit)
        {
            currentTimeUnits++;
            gameMinute += timeUnitsPerGameMinute;

            secondsSinceLastStep = 0;            
        }

        //---------------Map Events---------------
        if(gameHour == randomGameHour && dayEventHapened == false) //Se iba a hacer con un switch pero con el enumerador no para de joder. Asi que lo dejo con los if que son robustos.
        {
            if(mapEventsManager_.eventID == EventID.NONE)
            {
                dayEventHapened = true;
                Debug.Log("NO EVENT SELECTED");
                

            }
            else if(mapEventsManager_.eventID == EventID.LIGHTS_OFF)
            {
                dayEventHapened = true;
                Debug.Log("LIGHTS OFF EVENT");

                mapEventsManager_.LightsOffEvent();
            }
            else if (mapEventsManager_.eventID == EventID.DOORS_CLOSE)
            {
                dayEventHapened = true;
                Debug.Log("DOORS CLOSE EVENT");

                mapEventsManager_.DoorsShutEvent();
            }
            else if (mapEventsManager_.eventID == EventID.AIR_FAIL)
            {
                dayEventHapened = true;
                Debug.Log("AIR FAIL EVENT");

                mapEventsManager_.AirFailEvent();
            }
        }
        //----------------------------------------

        if (gameMinute >= 60)
        {
            gameMinute = 0;
            gameHour++;
        }

        if(gameHour >= 24)
        {
            EndDay();
        }
       
    }

    //---------------Map Events---------------
    public void StartDay()
    {
        randomGameHour = Random.Range(5, 20);
        dayEventHapened = false;

        if(noEventProbability == true)
        {
            randomEvent = Random.Range(0, 3);
        }
        else if(noEventProbability == false)
        {
            randomEvent = Random.Range(1, 3);
        }

        mapEventsManager_.eventID = (EventID)randomEvent;
    }
    //----------------------------------------

    public void EndDay()
    {
        ResetGameTime();
    }

   public int GetCurrentTimeUnits()
   {
        return currentTimeUnits;
   }
    public int GetTimeGameMinutes()
    {
        return gameMinute;
    }
    public int GetTimeGameHours()
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

        StartDay();
    }

    public void PauseGameTime(bool isTimePaused)
    {
        this.isTimePaused = isTimePaused;
    }
}
