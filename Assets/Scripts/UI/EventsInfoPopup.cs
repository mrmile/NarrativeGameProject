using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventsInfoPopup : MonoBehaviour
{
    public GameObject InformationCanvas;
    public TMP_Text text_eventInfo;
    public TMP_Text text_floorInfo;

    // Start is called before the first frame update
    void Start()
    {
        UI_eventsInfoVariables.alreadyChangedState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UI_eventsInfoVariables.anEventIsActive == true && UI_eventsInfoVariables.alreadyChangedState == false)
        {
            text_eventInfo.text = UI_eventsInfoVariables.eventName;
            text_floorInfo.text = UI_eventsInfoVariables.floorName;

            InformationCanvas.SetActive(true);
            UI_eventsInfoVariables.alreadyChangedState = true;

            //Debug.Log("EVENT POPUP INFO - ON");
        }

        if (UI_eventsInfoVariables.anEventIsActive == false && UI_eventsInfoVariables.alreadyChangedState == false)
        {
            InformationCanvas.SetActive(false);
            UI_eventsInfoVariables.alreadyChangedState = true;

            //Debug.Log("EVENT POPUP INFO - OFF");
        }
    }
}
