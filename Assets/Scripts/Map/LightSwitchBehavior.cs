using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchBehavior : MonoBehaviour
{
    public int lightSwitchID = 0; //0 = none, 1 = first, 2 = second, 3 = third, 4+ = not assigned

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
        if(lightSwitchID == 1)
        {
            if (EventManagerVariables.lightSwitchActive_1 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
            }
        }
        if (lightSwitchID == 2)
        {
            if (EventManagerVariables.lightSwitchActive_2 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
            }
        }
        if (lightSwitchID == 3)
        {
            if (EventManagerVariables.lightSwitchActive_3 == false && needsReset == false)
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

                if (lightSwitchID == 1 && EventManagerVariables.lightSwitchActive_1 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.lightSwitchActive_1 = true;
                    Debug.Log("SWITCH 1 ON");
                }
                if (lightSwitchID == 2 && EventManagerVariables.lightSwitchActive_2 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);


                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.lightSwitchActive_2 = true;
                    Debug.Log("SWITCH 2 ON");
                }
                if (lightSwitchID == 3 && EventManagerVariables.lightSwitchActive_3 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.lightSwitchActive_3 = true;
                    Debug.Log("SWITCH 3 ON");
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (lightSwitchID == 1 && EventManagerVariables.lightSwitchActive_1 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (lightSwitchID == 2 && EventManagerVariables.lightSwitchActive_2 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (lightSwitchID == 3 && EventManagerVariables.lightSwitchActive_3 == false)
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