using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchBehavior : MonoBehaviour
{
    public int lightSwitchID = 0; //0 = none, 1 = first, 2 = second, 3 = third, 4+ = not assigned

    public bool lightSwitchActive_1 = true;
    public bool lightSwitchActive_2 = true;
    public bool lightSwitchActive_3 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("SWITCH colliding");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(lightSwitchID == 1 && lightSwitchActive_1 == false)
                {
                    //todo: play switch on sound

                    lightSwitchActive_1 = true;
                    Debug.Log("SWITCH 1 ON");
                }
                else if (lightSwitchID == 2 && lightSwitchActive_2 == false)
                {
                    //todo: play switch on sound

                    lightSwitchActive_2 = true;
                    Debug.Log("SWITCH 1 ON");
                }
                else if (lightSwitchID == 3 && lightSwitchActive_3 == false)
                {
                    //todo: play switch on sound

                    lightSwitchActive_3 = true;
                    Debug.Log("SWITCH 1 ON");
                }
            }

        }

    }
}
