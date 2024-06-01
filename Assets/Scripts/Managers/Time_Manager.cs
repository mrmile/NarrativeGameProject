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
    
    

    //---------------Map Events---------------
    //int randomGameHour = 25;
    //bool dayEventHapened = false;
    //int randomEvent = 0;

    MapEventsManager mapEventsManager_;

    public bool EventsOnFirstDay = true;
    public bool noEventProbability = false;
    //----------------------------------------

    
    void Start()
    {
        //---------------Map Events---------------
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

        if (EventsOnFirstDay == true && TimeManagerVariables.classConstructed == false) //Se puede dejar o quitar en función de si se decide que el primer dia pasen eventos.
        {
            StartDay();
        }
        //----------------------------------------
    }


    void FixedUpdate()
    {
        if(!TimeManagerVariables.isTimePaused) UpdateTimeValues();
        
    }

    void UpdateTimeValues()
    {
        secondsSinceLastStep += Time.deltaTime;
        if(secondsSinceLastStep >= secondsPerTimeUnit)
        {
            TimeManagerVariables.currentTimeUnits++;
            TimeManagerVariables.gameMinute += timeUnitsPerGameMinute;

            secondsSinceLastStep = 0;            
        }

        //---------------Map Events---------------
        if(TimeManagerVariables.gameHour == TimeManagerVariables.randomGameHour && TimeManagerVariables.dayEventHapened == false) //Se iba a hacer con un switch pero con el enumerador no para de joder. Asi que lo dejo con los if que son robustos.
        {
            if(mapEventsManager_.eventID == EventID.NONE)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("NO EVENT SELECTED");
                

            }
            else if(mapEventsManager_.eventID == EventID.LIGHTS_OFF)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("LIGHTS OFF EVENT");

                mapEventsManager_.LightsOffEvent();
            }
            else if (mapEventsManager_.eventID == EventID.DOORS_CLOSE)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("DOORS CLOSE EVENT");

                mapEventsManager_.DoorsShutEvent();
            }
            else if (mapEventsManager_.eventID == EventID.AIR_FAIL)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("AIR FAIL EVENT");

                mapEventsManager_.AirFailEvent();

            }
        }
        //----------------------------------------

        if (TimeManagerVariables.gameMinute >= 60)
        {
            TimeManagerVariables.gameMinute = 0;
            TimeManagerVariables.gameHour++;
        }

        if(TimeManagerVariables.gameHour >= 24)
        {
            EndDay();
        }
       
    }

    //---------------Map Events---------------
    public void StartDay()
    {
        TimeManagerVariables.randomGameHour = Random.Range(5, 20);
        TimeManagerVariables.dayEventHapened = false;

        if(noEventProbability == true)
        {
            TimeManagerVariables.randomEvent = Random.Range(0, 3);
        }
        else if(noEventProbability == false)
        {
            TimeManagerVariables.randomEvent = Random.Range(1, 3);
        }

        mapEventsManager_.eventID = (EventID)TimeManagerVariables.randomEvent;

        TimeManagerVariables.classConstructed = true;

        Debug.Log("StartDay - Event SELECTION: " + mapEventsManager_.eventID);
        Debug.Log("StartDay - Event TIME: " + TimeManagerVariables.randomGameHour);

    }
    //----------------------------------------

    public void EndDay()
    {
        ResetGameTime();
    }

   public int GetCurrentTimeUnits()
   {
        return TimeManagerVariables.currentTimeUnits;
   }
    public int GetTimeGameMinutes()
    {
        return TimeManagerVariables.gameMinute;
    }
    public int GetTimeGameHours()
    {
        return TimeManagerVariables.gameHour;
    }

    public void SetCurrentTimeUnits(int timeUnits)
    {
        TimeManagerVariables.currentTimeUnits = timeUnits;
    }
    public void SetGameTime(int gameHour, int gameMinute)
    {
        TimeManagerVariables.gameHour = gameHour;
        TimeManagerVariables.gameMinute = gameMinute;
    }

    public void ResetGameTime()
    {
        secondsSinceLastStep = 0;
        TimeManagerVariables.currentTimeUnits = 0;
        TimeManagerVariables.gameMinute = 0;
        TimeManagerVariables.gameHour = 0;

        StartDay();
    }

    public void PauseGameTime(bool isTimePaused)
    {
        TimeManagerVariables.isTimePaused = isTimePaused;
    }
}
