using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MapEventsManager;
using DialogueEditor;

public class Time_Manager : MonoBehaviour
{
    const float secondsPerTimeUnit = 1.0f;
    const int timeUnitsPerGameMinute = 5;

    float secondsSinceLastStep;
    int timeUnitsSinceLastStep;
    
    MapEventsManager mapEventsManager_;

    public bool EventsOnFirstDay = true;
    public int multipleEvents = 2; //only accepts 1 or 2
    public bool noEventProbability = false;

    [SerializeField] GameObject dialogPanel;
    
    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();
        dialogPanel = ConversationManager.Instance.DialoguePanel.gameObject;


        TimeManagerVariables.eventAmount = multipleEvents;

        if (EventsOnFirstDay == true && TimeManagerVariables.classConstructed == false) 
        {
            StartDay();
        }
    }

    private void Update()
    {
        if (dialogPanel.activeSelf)
            TimeManagerVariables.isTimePaused = true;
        else
            TimeManagerVariables.isTimePaused = false;
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
        if (Input.GetKeyDown(KeyCode.F3))
        {
            TimeManagerVariables.gameHour++;
            Debug.Log("Advance 1 hour");
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

        RunDayEvent(1);
        if (TimeManagerVariables.eventAmount == 2) RunDayEvent(2);

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
        TimeManagerVariables.dayEventHapened = false;
        TimeManagerVariables.dayEventHapened2 = false;

        if (TimeManagerVariables.eventAmount == 1)
        {
            TimeManagerVariables.randomGameHour = Random.Range(5, 21);
        }
        else if (TimeManagerVariables.eventAmount == 2)
        {
            TimeManagerVariables.randomGameHour = Random.Range(5, 12);
            TimeManagerVariables.randomGameHour2 = Random.Range(15, 21);
        }


        if (TimeManagerVariables.eventAmount == 1)
        {
            if (noEventProbability == true)
            {
                TimeManagerVariables.randomEvent = Random.Range(0, 7);
            }
            else if (noEventProbability == false)
            {
                TimeManagerVariables.randomEvent = Random.Range(1, 7);
            }
            EventsEnum.eventID = (EventsEnum.EventID)TimeManagerVariables.randomEvent;
        }
        else if (TimeManagerVariables.eventAmount == 2)
        {
            if (noEventProbability == true)
            {
                TimeManagerVariables.randomEvent = Random.Range(0, 7);
                TimeManagerVariables.randomEvent2 = Random.Range(0, 7);
            }
            else if (noEventProbability == false)
            {
                TimeManagerVariables.randomEvent = Random.Range(1, 7);
                TimeManagerVariables.randomEvent2 = Random.Range(1, 7);
            }
            EventsEnum.eventID = (EventsEnum.EventID)TimeManagerVariables.randomEvent;
            EventsEnum.eventID2 = (EventsEnum.EventID)TimeManagerVariables.randomEvent2;
        }
        

        TimeManagerVariables.classConstructed = true;

        //Debug.Log("StartDay - Event SELECTION: " + EventsEnum.eventID);
        //Debug.Log("StartDay - Event TIME: " + TimeManagerVariables.randomGameHour);
        if(TimeManagerVariables.eventAmount == 2)
        {
            //Debug.Log("StartDay - Event SELECTION 2: " + EventsEnum.eventID2);
            //Debug.Log("StartDay - Event TIME 2: " + TimeManagerVariables.randomGameHour2);
        }
    }

    public void RunDayEvent(int dayEvent)
    {
        if(dayEvent == 1)
        {
            if ((TimeManagerVariables.gameHour == TimeManagerVariables.randomGameHour && TimeManagerVariables.dayEventHapened == false))
            {
                if ((EventsEnum.eventID == EventsEnum.EventID.NONE && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    //Debug.Log("NO EVENT SELECTED");
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.LIGHTS_OFF && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    //Debug.Log("LIGHTS OFF EVENT");

                    mapEventsManager_.LightsOffEvent();
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.DOORS_CLOSE && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    Debug.Log("DOORS CLOSE EVENT");

                    mapEventsManager_.DoorsShutEvent();
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.AIR_FAIL && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    Debug.Log("AIR FAIL EVENT");

                    mapEventsManager_.AirFailEvent();
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.COMUNICATIONS_INTERFERENCES && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    Debug.Log("COMUNICATIONS FAIL EVENT");

                    mapEventsManager_.ComunicationsFailEvent();
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.REACTOR_FAIL && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    Debug.Log("REACTOR FAIL EVENT");

                    mapEventsManager_.ReactorFailEvent();
                }
                else if ((EventsEnum.eventID == EventsEnum.EventID.FOUNDATIONS_COMPROMISED && TimeManagerVariables.dayEventHapened == false))
                {
                    TimeManagerVariables.dayEventHapened = true;
                    Debug.Log("FOUNDATIONS COMPROMISED EVENT");

                    mapEventsManager_.FoundationsCompromised();
                }
                //Debug.Log("EVENT DAY HAPPENED = " + TimeManagerVariables.dayEventHapened);
            }
        }

        if(dayEvent == 2)
        {
            if ((TimeManagerVariables.gameHour == TimeManagerVariables.randomGameHour2 && TimeManagerVariables.dayEventHapened2 == false))
            {
                if ((EventsEnum.eventID2 == EventsEnum.EventID.NONE && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("NO EVENT SELECTED");
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.LIGHTS_OFF && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("LIGHTS OFF EVENT");

                    mapEventsManager_.LightsOffEvent();
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.DOORS_CLOSE && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("DOORS CLOSE EVENT");

                    mapEventsManager_.DoorsShutEvent();
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.AIR_FAIL && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("AIR FAIL EVENT");

                    mapEventsManager_.AirFailEvent();
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.COMUNICATIONS_INTERFERENCES && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("COMUNICATIONS FAIL EVENT");

                    mapEventsManager_.ComunicationsFailEvent();
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.REACTOR_FAIL && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("REACTOR FAIL EVENT");

                    mapEventsManager_.ReactorFailEvent();
                }
                else if ((EventsEnum.eventID2 == EventsEnum.EventID.FOUNDATIONS_COMPROMISED && TimeManagerVariables.dayEventHapened2 == false))
                {
                    TimeManagerVariables.dayEventHapened2 = true;
                    Debug.Log("FOUNDATIONS COMPROMISED EVENT");

                    mapEventsManager_.FoundationsCompromised();
                }
                //Debug.Log("EVENT DAY HAPPENED = " + TimeManagerVariables.dayEventHapened);
            }
        }
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
