using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Event_List : MonoBehaviour
{
     List<NPC_Day_Event> dayEventsList = new List<NPC_Day_Event>();

    private void Awake()
    {
        NPC_Day_Event[] eventArray = GetComponents<NPC_Day_Event>();
        for (int i = 0; i < eventArray.Length; i++)
        {
            dayEventsList.Add(eventArray[i]);
        }
    }

    public List<NPC_Day_Event> GetEventList()
    {
        return dayEventsList;
    }
}
