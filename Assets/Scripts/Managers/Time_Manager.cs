using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MapEventsManager;

public class Time_Manager : MonoBehaviour
{
    const float secondsPerTimeUnit = 1.0f;
    const int timeUnitsPerGameMinute = 5;

    float secondsSinceLastStep;
    int timeUnitsSinceLastStep;
    
    MapEventsManager mapEventsManager_;

    public bool EventsOnFirstDay = true;
    public bool noEventProbability = false;
    
    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

        if (EventsOnFirstDay == true && TimeManagerVariables.classConstructed == false) 
        {
            StartDay();
        }
    }

    void FixedUpdate()
    {
        if(!TimeManagerVariables.isTimePaused) UpdateTimeValues();
        
        // For testing
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SetGameTime(12, 0); // Set to day (e.g., 12 PM)
            Debug.Log("Set to Day Time");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SetGameTime(0, 0); // Set to night (e.g., 12 AM)
            Debug.Log("Set to Night Time");
        }
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

        if(TimeManagerVariables.gameHour == TimeManagerVariables.randomGameHour && TimeManagerVariables.dayEventHapened == false)
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
            else if (mapEventsManager_.eventID == EventID.COMUNICATIONS_INTERFERENCES)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("COMUNICATIONS FAIL EVENT");

                mapEventsManager_.ComunicationsFailEvent();
            }
            else if (mapEventsManager_.eventID == EventID.REACTOR_FAIL)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("REACTOR FAIL EVENT");

                mapEventsManager_.ReactorFailEvent();
            }
            else if (mapEventsManager_.eventID == EventID.FOUNDATIONS_COMPROMISED)
            {
                TimeManagerVariables.dayEventHapened = true;
                Debug.Log("FOUNDATIONS COMPROMISED EVENT");

                mapEventsManager_.FoundationsCompromised();
            }
        }

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

    public void StartDay()
    {
        TimeManagerVariables.randomGameHour = Random.Range(5, 21);
        TimeManagerVariables.dayEventHapened = false;

        if(noEventProbability == true)
        {
            TimeManagerVariables.randomEvent = Random.Range(0, 7);
        }
        else if(noEventProbability == false)
        {
            TimeManagerVariables.randomEvent = Random.Range(1, 7);
        }

        mapEventsManager_.eventID = (EventID)TimeManagerVariables.randomEvent;

        TimeManagerVariables.classConstructed = true;

        Debug.Log("StartDay - Event SELECTION: " + mapEventsManager_.eventID);
        Debug.Log("StartDay - Event TIME: " + TimeManagerVariables.randomGameHour);
    }

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
