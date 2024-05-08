using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcDayEventType
{
    DEFAULT,
    LUNCH,
    BACK_TO_WORK,
    SLEEP
}
public class NPC_Day_Event : MonoBehaviour
{
    [SerializeField] NpcDayEventType eventType;
    [SerializeField] int hour;
    [SerializeField] int minute;
    bool isTriggered;

    public NpcDayEventType GetEventType()
    {
        return eventType;
    }
    public int GetMinute()
    {
        return minute;
    }
    public int GetHour()
    {
        return hour;
    }
    public bool GetIsTriggered()
    {
        return isTriggered;
    }
    public void SetIsTriggered(bool isTriggered)
    {
        this.isTriggered = isTriggered;
    }
    
}
