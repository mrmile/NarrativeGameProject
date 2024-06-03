using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationColumnBheavrior : MonoBehaviour
{
    public int foundationColumnID = 0; //0 = none, 1 = first, 2 = second, 3 = third, 4+ = not assigned

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject actionIndicationCanvas;
    public GameObject columnObject;

    public AudioClip foundationFixSound;
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
        if (foundationColumnID == 1)
        {
            if (EventManagerVariables.foundationsRepaired_1 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
                columnObject.SetActive(true);
            }
        }
        if (foundationColumnID == 2)
        {
            if (EventManagerVariables.foundationsRepaired_2 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
                columnObject.SetActive(true);
            }
        }
        if (foundationColumnID == 3)
        {
            if (EventManagerVariables.foundationsRepaired_3 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
                columnObject.SetActive(true);
            }
        }
        if (foundationColumnID == 4)
        {
            if (EventManagerVariables.foundationsRepaired_4 == false && needsReset == false)
            {
                needsReset = true;
                greenLight.SetActive(false);
                redLight.SetActive(true);
                columnObject.SetActive(true);
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

                if (foundationColumnID == 1 && EventManagerVariables.foundationsRepaired_1 == false)
                {
                    audioSource.PlayOneShot(foundationFixSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);
                    columnObject.SetActive(false);

                    EventManagerVariables.foundationsRepaired_1 = true;
                    Debug.Log("COLUMN 1 OK");
                }
                if (foundationColumnID == 2 && EventManagerVariables.foundationsRepaired_2 == false)
                {
                    audioSource.PlayOneShot(foundationFixSound);


                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);
                    columnObject.SetActive(false);

                    EventManagerVariables.foundationsRepaired_2 = true;
                    Debug.Log("COLUMN 2 OK");
                }
                if (foundationColumnID == 3 && EventManagerVariables.foundationsRepaired_3 == false)
                {
                    audioSource.PlayOneShot(foundationFixSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);
                    columnObject.SetActive(false);

                    EventManagerVariables.foundationsRepaired_3 = true;
                    Debug.Log("COLUMN 3 OK");
                }
                if (foundationColumnID == 4 && EventManagerVariables.foundationsRepaired_4 == false)
                {
                    audioSource.PlayOneShot(foundationFixSound);

                    actionIndicationCanvas.SetActive(false);

                    needsReset = false;
                    greenLight.SetActive(true);
                    redLight.SetActive(false);
                    columnObject.SetActive(false);

                    EventManagerVariables.foundationsRepaired_4 = true;
                    Debug.Log("COLUMN 4 OK");
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (foundationColumnID == 1 && EventManagerVariables.foundationsRepaired_1 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (foundationColumnID == 2 && EventManagerVariables.foundationsRepaired_2 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (foundationColumnID == 3 && EventManagerVariables.foundationsRepaired_3 == false)
        {
            actionIndicationCanvas.SetActive(true);
        }
        if (foundationColumnID == 4 && EventManagerVariables.foundationsRepaired_4 == false)
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
