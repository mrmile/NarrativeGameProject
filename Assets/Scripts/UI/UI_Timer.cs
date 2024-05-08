using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] Time_Manager timeManager;
    [SerializeField] TMP_Text textComponent;

    int minutes;
    int hours;
      
    void Update()
    {
        minutes = timeManager.GetTimeGameMinutes();
        hours = timeManager.GetTimeGameHours();

        textComponent.text = hours.ToString("D2") + " : " + minutes.ToString("D2");
    }
}
