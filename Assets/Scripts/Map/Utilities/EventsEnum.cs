using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsEnum
{
    public enum EventID
    {
        NONE = 0,
        LIGHTS_OFF,
        DOORS_CLOSE,
        AIR_FAIL,
        COMUNICATIONS_INTERFERENCES,
        REACTOR_FAIL,
        FOUNDATIONS_COMPROMISED
    }

    public static EventID eventID;
    public static EventID eventID2;
}
