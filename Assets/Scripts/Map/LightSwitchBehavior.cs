using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchBehavior : MonoBehaviour
{
    public int lightSwitchID = 0; //0 = none, 1 = first, 2 = second, 3 = third, 4+ = not assigned

    MapEventsManager mapEventsManager_;

    // Start is called before the first frame update
    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("SWITCH colliding press");

                if (lightSwitchID == 1 && mapEventsManager_.lightSwitchActive_1 == false)
                {
                    //todo: play switch on sound

                    mapEventsManager_.lightSwitchActive_1 = true;
                    Debug.Log("SWITCH 1 ON");
                }
                if (lightSwitchID == 2 && mapEventsManager_.lightSwitchActive_2 == false)
                {
                    //todo: play switch on sound

                    mapEventsManager_.lightSwitchActive_2 = true;
                    Debug.Log("SWITCH 2 ON");
                }
                if (lightSwitchID == 3 && mapEventsManager_.lightSwitchActive_3 == false)
                {
                    //todo: play switch on sound

                    mapEventsManager_.lightSwitchActive_3 = true;
                    Debug.Log("SWITCH 3 ON");
                }
            }

        }

    }
}
