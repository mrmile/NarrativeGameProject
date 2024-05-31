using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSwitchBehavior : MonoBehaviour
{
    public int airSwitchID = 0; //0 = none, 1 = first, 2+ = not assigned

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject actionIndicationCanvas;

    public AudioClip switchPressSound;
    AudioSource audioSource;

    MapEventsManager mapEventsManager_;

    private bool needsReset = false;

    // Start is called before the first frame update
    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(airSwitchID == 1)
        {
            if (EventManagerVariables.airSwitchActive_1 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
            }
        }
        
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("SWITCH colliding press");

                if (airSwitchID == 1 && EventManagerVariables.airSwitchActive_1 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.airSwitchActive_1 = true;
                    Debug.Log("AIR SWITCH 1 ON");
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (airSwitchID == 1 && EventManagerVariables.airSwitchActive_1 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            //Debug.Log("SWITCH colliding press");

            actionIndicationCanvas.SetActive(false);

        }
    }
}
