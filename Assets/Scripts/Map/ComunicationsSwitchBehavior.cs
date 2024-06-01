using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComunicationsSwitchBehavior : MonoBehaviour
{
    public int comunicationsSwitchID = 0; //0 = none, 1 = first, 2 = second, 3+ = not assigned

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject actionIndicationCanvas;

    public AudioClip switchPressSound;
    AudioSource audioSource;

    //MapEventsManager mapEventsManager_;

    private bool needsReset = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (comunicationsSwitchID == 1)
        {
            if (EventManagerVariables.comunicationsSwitchActive_1 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
            }
        }
        if (comunicationsSwitchID == 2)
        {
            if (EventManagerVariables.comunicationsSwitchActive_2 == false && needsReset == false)
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

                if (comunicationsSwitchID == 1 && EventManagerVariables.comunicationsSwitchActive_1 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.comunicationsSwitchActive_1 = true;
                    Debug.Log("COMUNICATIONS SWITCH 1 ON");
                }
                if (comunicationsSwitchID == 2 && EventManagerVariables.comunicationsSwitchActive_2 == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    EventManagerVariables.comunicationsSwitchActive_2 = true;
                    Debug.Log("COMUNICATIONS SWITCH 2 ON");
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (comunicationsSwitchID == 1 && EventManagerVariables.comunicationsSwitchActive_1 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (comunicationsSwitchID == 2 && EventManagerVariables.comunicationsSwitchActive_2 == false)
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
