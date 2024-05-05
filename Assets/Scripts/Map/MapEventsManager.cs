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



        if (lightSwitchBehavior_.lightSwitchActive_1 == true &&
        lightSwitchBehavior_.lightSwitchActive_2 == true &&
        lightSwitchBehavior_.lightSwitchActive_3 == true &&
        lightsOffEventActive == true)
        {
            LightsBackOn();
        }
    }

    void LightsOffEvent()
    {
        //todo: play sound of lights turning off

        lightSwitchBehavior_.lightSwitchActive_1 = false;
        lightSwitchBehavior_.lightSwitchActive_2 = false;
        lightSwitchBehavior_.lightSwitchActive_3 = false;
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
