using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapEventsManager : MonoBehaviour
{
    public enum EventID
    {
        NONE = 0,
        LIGHTS_OFF,
        DOORS_CLOSE,
        AIR_FAIL,
        COMUNICATIONS_INTERFERENCES,
        REACTOR_FAIL,
        FOUNDATIONS_COMPROMISED
    }
    public EventID eventID;

    public int currentMapLevel = 0;

    //bool lightsOffEventActive = false;
    //public bool lightSwitchActive_1 = true;
    //public bool lightSwitchActive_2 = true;
    //public bool lightSwitchActive_3 = true;

    //public int doorsShutEventPhase = 0;
    //public bool shutDoorGroup = false;
    //public float doorsShutEventDuration = 5;

    //bool airFailEventActive = false;
    //public bool airSwitchActive_1 = true;

    public AudioClip powerOffSound;
    public AudioClip powerOnSound;
    public AudioClip bigPowerOnSound;
    public AudioClip doorsCloseSound;
    public AudioClip alarmSound;
    public AudioClip reactorAlarmSound;
    public AudioClip comunicationsStatic;
    public AudioClip okDone;
    AudioSource audioSource;

    LightOnOffBehaviour lightOnOffBehaviour_;

    AirFailBehaviour airFailBehaviour_;

    Time_Manager time_Manager_;

    AmbienceAudioPlayer ambienceAudioPlayer_;

    // Start is called before the first frame update
    void Start()
    {
        lightOnOffBehaviour_ = FindObjectOfType<LightOnOffBehaviour>();
        airFailBehaviour_ = FindObjectOfType<AirFailBehaviour>();
        time_Manager_ = FindObjectOfType<Time_Manager>();
        ambienceAudioPlayer_ = FindObjectOfType<AmbienceAudioPlayer>();

        audioSource = GetComponent<AudioSource>();

        if (EventManagerVariables.lightSwitchActive_1 == false ||
        EventManagerVariables.lightSwitchActive_2 == false ||
        EventManagerVariables.lightSwitchActive_3 == false ||
        EventManagerVariables.lightsOffEventActive == true)
        {
            //LightsOffEvent();
            LightOnOffBehaviourVariables.lightsOff = true;
            EventManagerVariables.lightsOffEventActive = true;

            Debug.Log("LIGHTS ARE STILL OFF");
        }

        if (EventManagerVariables.airSwitchActive_1 == false ||
        EventManagerVariables.airFailEventActive == true)
        {
            //AirFailEvent();
            AirFailBehaviourVariables.airOff = true;
            EventManagerVariables.airFailEventActive = true;
            audioSource.clip = alarmSound;
            audioSource.loop = true;
            audioSource.Play();

            Debug.Log("AIR STILLS FAILED");
        }

        if (EventManagerVariables.reactorRepaired == false ||
        EventManagerVariables.reactorFailEventActive == true)
        {
            //AirFailEvent();
            ReactorFailBehaviorVariables.reactorOff = true;
            EventManagerVariables.reactorFailEventActive = true;
            audioSource.clip = alarmSound;
            audioSource.loop = true;
            audioSource.Play();

            Debug.Log("REACTOR STILLS FAILED");
        }

        if (EventManagerVariables.comunicationsSwitchActive_1 == false ||
        EventManagerVariables.comunicationsSwitchActive_1 == false ||
        EventManagerVariables.comunicationsFailEventActive == true)
        {
            //LightsOffEvent();
            ComunicationsFailBehaviorVariables.comunicationsOff = true;
            EventManagerVariables.comunicationsFailEventActive = true;
            audioSource.clip = comunicationsStatic;
            audioSource.loop = true;
            audioSource.Play();

            Debug.Log("COMUNICATIONS STILLS JANKED");
        }

        if (EventManagerVariables.foundationsRepaired_1 == false ||
        EventManagerVariables.foundationsRepaired_2 == false ||
        EventManagerVariables.foundationsRepaired_3 == false ||
        EventManagerVariables.foundationsRepaired_4 == false ||
        EventManagerVariables.foundationsCompromisedEventActive == true)
        {
            //LightsOffEvent();
            FoundationsCompBehaviorVariables.foundationsCompromised = true;
            EventManagerVariables.foundationsCompromisedEventActive = true;

            Debug.Log("FOUNDATIONS STILLS COMPROMMISED");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) //for testing events only
        {
            LightsOffEvent();
            Debug.Log("LIGHTS OFF EVENT");
        }

        if (Input.GetKeyDown(KeyCode.F6)) //for testing events only
        {
            DoorsShutEvent();
        }

        if (Input.GetKeyDown(KeyCode.F7)) //for testing events only
        {
            AirFailEvent();
            Debug.Log("AIR FAIL EVENT");
        }

        if (Input.GetKeyDown(KeyCode.F8)) //for testing events only
        {
            ComunicationsFailEvent();
            Debug.Log("COMUNICATION FAIL EVENT");
        }

        if (Input.GetKeyDown(KeyCode.F9)) //for testing events only
        {
            ReactorFailEvent();
            Debug.Log("REACTOR FAIL EVENT");
        }

        if (Input.GetKeyDown(KeyCode.F10)) //for testing events only
        {
            FoundationsCompromised();
            Debug.Log("FOUNDATIONS COMPROMISED EVENT");
        }


        if (EventManagerVariables.lightSwitchActive_1 == true &&
        EventManagerVariables.lightSwitchActive_2 == true &&
        EventManagerVariables.lightSwitchActive_3 == true &&
        EventManagerVariables.lightsOffEventActive == true)
        {
            LightsBackOn();
            Debug.Log("LIGHTS BACK ON");
        }

        if (EventManagerVariables.airSwitchActive_1 == true &&
        EventManagerVariables.airFailEventActive == true)
        {
            AirBackOn();
            Debug.Log("AIR BACK ON");
            audioSource.Stop();
        }

        if (EventManagerVariables.reactorRepaired == true &&
        EventManagerVariables.reactorFailEventActive == true)
        {
            ReactorFixed();
            Debug.Log("AIR BACK ON");
            audioSource.Stop();
        }

        if (EventManagerVariables.comunicationsSwitchActive_1 == true &&
        EventManagerVariables.comunicationsSwitchActive_2 == true &&
        EventManagerVariables.comunicationsFailEventActive == true)
        {
            ComunicationsFixed();
            Debug.Log("LIGHTS BACK ON");
        }

        if (EventManagerVariables.foundationsRepaired_1 == true &&
        EventManagerVariables.foundationsRepaired_2 == true &&
        EventManagerVariables.foundationsRepaired_3 == true &&
        EventManagerVariables.foundationsRepaired_4 == true &&
        EventManagerVariables.foundationsCompromisedEventActive == true)
        {
            FoundationsFixed();
            Debug.Log("FOUNDATIONS REPAIRED");
        }
    }

    public void LightsOffEvent()
    {
        audioSource.PlayOneShot(powerOffSound);

        EventManagerVariables.lightSwitchActive_1 = false;
        EventManagerVariables.lightSwitchActive_2 = false;
        EventManagerVariables.lightSwitchActive_3 = false;
        LightOnOffBehaviourVariables.lightsOff = true;

        EventManagerVariables.lightsOffEventActive = true;

        ambienceAudioPlayer_.SwitchToLightsOffAmbience();
        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Electric Blackout", "F0 or F-1", true);
    }

    public void LightsBackOn()
    {
        audioSource.PlayOneShot(powerOnSound);

        LightOnOffBehaviourVariables.lightsOff = false;

        EventManagerVariables.lightsOffEventActive = false;

        ambienceAudioPlayer_.SwitchBackToDefaultAmbience();
        time_Manager_.PauseGameTime(false);

        SetupEventInfoUI("nothing", "nothing", false);
    }

    public void DoorsShutEvent()
    {
        audioSource.PlayOneShot(doorsCloseSound);

        EventManagerVariables.shutDoorGroup = true;
        EventManagerVariables.doorsShutEventPhase = 1;
        Debug.Log("DOORS SHUT EVENT");

        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Doors Lockdown", "-", true);
    }

    public void AirFailEvent()
    {
        audioSource.PlayOneShot(powerOffSound);

        audioSource.clip = alarmSound;
        audioSource.loop = true;
        audioSource.Play();


        EventManagerVariables.airSwitchActive_1 = false;
        AirFailBehaviourVariables.airOff = true;

        EventManagerVariables.airFailEventActive = true;

        //ambienceAudioPlayer_.StopAudioAmbience();
        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Ventilation Failed", "F0", true);
    }

    public void AirBackOn()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(powerOnSound);

        AirFailBehaviourVariables.airOff = false;

        EventManagerVariables.airFailEventActive = false;

        //ambienceAudioPlayer_.ResumeAudioAmbience();
        time_Manager_.PauseGameTime(false);

        SetupEventInfoUI("nothing", "nothing", false);
    }

    public void ReactorFailEvent()
    {
        audioSource.PlayOneShot(reactorAlarmSound);

        audioSource.clip = alarmSound;
        audioSource.loop = true;
        audioSource.Play();


        EventManagerVariables.reactorRepaired = false;
        ReactorFailBehaviorVariables.reactorOff = true;

        EventManagerVariables.reactorFailEventActive = true;

        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Reactor Malfunction", "F-1", true);
    }

    public void ReactorFixed()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(bigPowerOnSound);

        ReactorFailBehaviorVariables.reactorOff = false;

        EventManagerVariables.reactorFailEventActive = false;

        time_Manager_.PauseGameTime(false);

        SetupEventInfoUI("nothing", "nothing", false);
    }

    public void ComunicationsFailEvent()
    {
        audioSource.clip = comunicationsStatic;
        audioSource.loop = true;
        audioSource.Play();

        EventManagerVariables.comunicationsSwitchActive_1 = false;
        EventManagerVariables.comunicationsSwitchActive_2 = false;
        ComunicationsFailBehaviorVariables.comunicationsOff = true;

        EventManagerVariables.comunicationsFailEventActive = true;

        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Online Interferences", "F0", true);
    }

    public void ComunicationsFixed()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(powerOnSound);

        ComunicationsFailBehaviorVariables.comunicationsOff = false;
        EventManagerVariables.comunicationsFailEventActive = false;

        time_Manager_.PauseGameTime(false);

        SetupEventInfoUI("nothing", "nothing", false);
    }

    public void FoundationsCompromised()
    {
        audioSource.PlayOneShot(reactorAlarmSound);

        EventManagerVariables.foundationsRepaired_1 = false;
        EventManagerVariables.foundationsRepaired_2 = false;
        EventManagerVariables.foundationsRepaired_3 = false;
        EventManagerVariables.foundationsRepaired_4 = false;
        FoundationsCompBehaviorVariables.foundationsCompromised = true;

        EventManagerVariables.foundationsCompromisedEventActive = true;

        time_Manager_.PauseGameTime(true);

        SetupEventInfoUI("Foundations Compromised", "F-2", true);
    }

    public void FoundationsFixed()
    {
        audioSource.PlayOneShot(okDone);

        FoundationsCompBehaviorVariables.foundationsCompromised = false;
        EventManagerVariables.foundationsCompromisedEventActive = false;

        time_Manager_.PauseGameTime(false);

        SetupEventInfoUI("nothing", "nothing", false);
    }

    public void SetupEventInfoUI(string nameOfEvent, string nameOfFloor, bool itsEventOn)
    {
        UI_eventsInfoVariables.eventName = nameOfEvent;
        UI_eventsInfoVariables.floorName = nameOfFloor;
        UI_eventsInfoVariables.anEventIsActive = itsEventOn;

        UI_eventsInfoVariables.alreadyChangedState = false;
    }
}
