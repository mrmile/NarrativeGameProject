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

    LightOnOffBehaviour lightOnOffBehaviour_;

    AirFailBehaviour airFailBehaviour_;

    Time_Manager time_Manager_;

    // Start is called before the first frame update
    void Start()
    {
        lightOnOffBehaviour_ = FindObjectOfType<LightOnOffBehaviour>();
        airFailBehaviour_ = FindObjectOfType<AirFailBehaviour>();
        time_Manager_ = FindObjectOfType<Time_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T)) //for testing events only
        //{
        //    LightsOffEvent();
        //    Debug.Log("LIGHTS OFF EVENT");
        //}

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
        }
    }

    public void LightsOffEvent()
    {
        //todo: play sound of lights turning off

        lightSwitchActive_1 = false;
        lightSwitchActive_2 = false;
        lightSwitchActive_3 = false;
        lightOnOffBehaviour_.lightsOff = true;

        lightsOffEventActive = true;

        time_Manager_.PauseGameTime(true);
    }

    public void LightsBackOn()
    {
        //todo: play sound of lights turning on

        lightOnOffBehaviour_.lightsOff = false;

        lightsOffEventActive = false;

        time_Manager_.PauseGameTime(false);
    }

    public void DoorsShutEvent()
    {
        shutDoorGroup = true;
        doorsShutEventPhase = 1;
        Debug.Log("DOORS SHUT EVENT");

        time_Manager_.PauseGameTime(true);

        //todo: play sound of doors shutting down
    }

    public void AirFailEvent()
    {
        airSwitchActive_1 = false;
        airFailBehaviour_.airOff = true;

        airFailEventActive = true;

        time_Manager_.PauseGameTime(true);
    }

    public void AirBackOn()
    {
        //todo: play sound of lights turning on

        airFailBehaviour_.airOff = false;

        airFailEventActive = false;

        time_Manager_.PauseGameTime(false);
    }
}
