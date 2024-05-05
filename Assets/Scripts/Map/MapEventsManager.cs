using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventID
{
    NONE = 0,
    LIGHTS_OFF,
    DOORS_CLOSE,
    AIR_FAIL
}

public class MapEventsManager : MonoBehaviour
{
    bool lightsOffEventActive = false;

    public bool lightSwitchActive_1 = true;
    public bool lightSwitchActive_2 = true;
    public bool lightSwitchActive_3 = true;

    LightOnOffBehaviour lightOnOffBehaviour_;
    LightSwitchBehavior lightSwitchBehavior_;

    // Start is called before the first frame update
    void Start()
    {
        lightOnOffBehaviour_ = FindObjectOfType<LightOnOffBehaviour>();
        lightSwitchBehavior_ = FindObjectOfType<LightSwitchBehavior>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //for testing events only
        {
            LightsOffEvent();
            Debug.Log("LIGHTS OFF EVENT");
        }



        if (lightSwitchActive_1 == true &&
        lightSwitchActive_2 == true &&
        lightSwitchActive_3 == true &&
        lightsOffEventActive == true)
        {
            LightsBackOn();
            Debug.Log("LIGHTS BACK ON");
        }
    }

    void LightsOffEvent()
    {
        //todo: play sound of lights turning off

        lightSwitchActive_1 = false;
        lightSwitchActive_2 = false;
        lightSwitchActive_3 = false;
        lightOnOffBehaviour_.lightsOff = true;

        lightsOffEventActive = true;
    }

    void LightsBackOn()
    {
        //todo: play sound of lights turning on

        lightOnOffBehaviour_.lightsOff = false;

        lightsOffEventActive = false;
    }
}
