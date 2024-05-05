using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSwitchBehavior : MonoBehaviour
{
    public int airSwitchID = 0; //0 = none, 1 = first, 2+ = not assigned

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

                if (airSwitchID == 1 && mapEventsManager_.airSwitchActive_1 == false)
                {
                    //todo: play switch on sound

                    mapEventsManager_.airSwitchActive_1 = true;
                    Debug.Log("AIR SWITCH 1 ON");
                }
            }

        }

    }
}
