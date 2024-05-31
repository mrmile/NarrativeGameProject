using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapEventsManager : MonoBehaviour
{
    public enum SpecialEventID
    {
        NONE,
        AIR_FAIL,
        REACTOR_FAIL
    }

    public enum EventID
    {
        NONE = 0,
        LIGHTS_OFF,
        DOORS_CLOSE,
        SPECIAL_EVENT
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
    public AudioClip doorsCloseSound;
    public AudioClip alarmSound;
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
    }

    public void LightsBackOn()
    {
        audioSource.PlayOneShot(powerOnSound);

        LightOnOffBehaviourVariables.lightsOff = false;

        EventManagerVariables.lightsOffEventActive = false;

        ambienceAudioPlayer_.SwitchBackToDefaultAmbience();
        time_Manager_.PauseGameTime(false);
    }

    public void DoorsShutEvent()
    {
        audioSource.PlayOneShot(doorsCloseSound);

        EventManagerVariables.shutDoorGroup = true;
        EventManagerVariables.doorsShutEventPhase = 1;
        Debug.Log("DOORS SHUT EVENT");

        time_Manager_.PauseGameTime(true);
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
    }

    public void ReactorFailEvent()
    {

    }

    public void ReactorFixed()
    {

    }
}
