using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorSwitchBehavior : MonoBehaviour
{
    public int reactorSwitchID = 0; //0 = none, 1 = first, 2+ = not assigned

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject actionIndicationCanvas;
    public GameObject reactorFixed;
    public GameObject reactorBroken;

    public AudioClip switchPressSound;
    AudioSource audioSource;

    private bool needsReset = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reactorSwitchID == 1)
        {
            if (EventManagerVariables.reactorRepaired == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);

                reactorFixed.SetActive(false);
                reactorBroken.SetActive(true);
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

                if (reactorSwitchID == 1 && EventManagerVariables.reactorRepaired == false)
                {
                    audioSource.PlayOneShot(switchPressSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);

                    reactorFixed.SetActive(true);
                    reactorBroken.SetActive(false);

                    EventManagerVariables.reactorRepaired = true;
                    Debug.Log("REACTOR SWITCH 1 ON");
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (reactorSwitchID == 1 && EventManagerVariables.reactorRepaired == false)
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
