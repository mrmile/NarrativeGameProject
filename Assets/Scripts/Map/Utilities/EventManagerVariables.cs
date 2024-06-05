using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManagerVariables
{
    public static bool lightsOffEventActive = false;
    public static bool lightSwitchActive_1 = true;
    public static bool lightSwitchActive_2 = true;
    public static bool lightSwitchActive_3 = true;

    public static int doorsShutEventPhase = 0;
    public static bool shutDoorGroup = false;
    public static float doorsShutEventDuration = 60;

    public static bool airFailEventActive = false;
    public static bool airSwitchActive_1 = true;

    public static bool comunicationsFailEventActive = false;
    public static bool comunicationsSwitchActive_1 = true;
    public static bool comunicationsSwitchActive_2 = true;

    public static bool reactorFailEventActive = false;
    public static bool reactorRepaired = true;

    public static bool foundationsCompromisedEventActive = false;
    public static bool foundationsRepaired_1 = true;
    public static bool foundationsRepaired_2 = true;
    public static bool foundationsRepaired_3 = true;
    public static bool foundationsRepaired_4 = true;

}