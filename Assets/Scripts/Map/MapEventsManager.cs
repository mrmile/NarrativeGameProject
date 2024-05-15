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
        AIR_FAIL
    }
    public EventID eventID;

    bool lightsOffEventActive = false;
    public bool lightSwitchActive_1 = true;
    public bool lightSwitchActive_2 = true;
    public bool lightSwitchActive_3 = true;

    public int doorsShutEventPhase = 0;
    public bool shutDoorGroup = false;
    public float doorsShutEventDuration = 5;

    bool airFailEventActive = false;
    public bool airSwitchActive_1 = true;

    public AudioClip powerOffSound;
    public AudioClip powerOnSound;
    public AudioClip doorsCloseSound;
    public AudioClip alarmSound;
    AudioSource audioSource;

    LightOnOffBehaviour lightOnOffBehaviour_;

    AirFailBehaviour airFailBehaviour_;

    Time_Manager time_Manager_;

    // Start is called before the first frame update
    void Start()
    {
        lightOnOffBehaviour_ = FindObjectOfType<LightOnOffBehaviour>();
        airFailBehaviour_ = FindObjectOfType<AirFailBehaviour>();
        time_Manager_ = FindObjectOfType<Time_Manager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //for testing events only
        {
            LightsOffEvent();
            Debug.Log("LIGHTS OFF EVENT");
        }

        //if (Input.GetKeyDown(KeyCode.T)) //for testing events only
        //{
        //    DoorsShutEvent();
        //}

        //if (Input.GetKeyDown(KeyCode.T)) //for testing events only
        //{
        //    AirFailEvent();
        //    Debug.Log("AIR FAIL EVENT");
        //}



        if (lightSwitchActive_1 == true &&
        lightSwitchActive_2 == true &&
        lightSwitchActive_3 == true &&
        lightsOffEventActive == true)
        {
            LightsBackOn();
            Debug.Log("LIGHTS BACK ON");
        }

        if (airSwitchActive_1 == true &&
        airFailEventActive == true)
        {
            AirBackOn();
            Debug.Log("AIR BACK ON");
            audioSource.Stop();
        }
        if (airFailEventActive == true)
        {
            
            
        }
    }

    public void LightsOffEvent()
    {
        audioSource.PlayOneShot(powerOffSound);

        lightSwitchActive_1 = false;
        lightSwitchActive_2 = false;
        lightSwitchActive_3 = false;
        lightOnOffBehaviour_.lightsOff = true;

        lightsOffEventActive = true;

        time_Manager_.PauseGameTime(true);
    }

    public void LightsBackOn()
    {
        audioSource.PlayOneShot(powerOnSound);

        lightOnOffBehaviour_.lightsOff = false;

        lightsOffEventActive = false;

        time_Manager_.PauseGameTime(false);
    }

    public void DoorsShutEvent()
    {
        audioSource.PlayOneShot(doorsCloseSound);

        shutDoorGroup = true;
        doorsShutEventPhase = 1;
        Debug.Log("DOORS SHUT EVENT");

        time_Manager_.PauseGameTime(true);
    }

    public void AirFailEvent()
    {
        audioSource.PlayOneShot(powerOffSound);

        audioSource.clip = alarmSound;
        audioSource.loop = true;
        audioSource.Play();
        

        airSwitchActive_1 = false;
        airFailBehaviour_.airOff = true;

        airFailEventActive = true;

        time_Manager_.PauseGameTime(true);
    }

    public void AirBackOn()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(powerOnSound);

        airFailBehaviour_.airOff = false;

        airFailEventActive = false;

        time_Manager_.PauseGameTime(false);
    }
}
