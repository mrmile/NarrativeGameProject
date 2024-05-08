using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC_Schedule_Manager : MonoBehaviour
{
    [SerializeField] Time_Manager timeManager;
    [SerializeField] NPC_Event_List eventListHandler;
    [SerializeField] List<NPC_Movement> npcList;
   

    List<NPC_Day_Event> dayEventList = new List<NPC_Day_Event>();

    int currentHour;
    int currentMinute;
    void Start()
    {
        dayEventList = eventListHandler.GetEventList();

    }

    // Update is called once per frame
    void Update()
    {        
        if(currentMinute != timeManager.GetTimeGameMinutes())
        {
            currentHour = timeManager.GetTimeGameHours();
            currentMinute = timeManager.GetTimeGameMinutes();
            CheckEventSchedule();
        }
               
    }
    void CheckEventSchedule()
    {
        for (int i = 0; i < dayEventList.Count; i++)
        {
            NPC_Day_Event myEvent = dayEventList[i];

            if (currentHour == myEvent.GetHour() && currentMinute == myEvent.GetMinute())
            {
                if (!myEvent.GetIsTriggered())
                {
                    myEvent.SetIsTriggered(true);
                    StartDayEvent(myEvent.GetEventType());
                }
            }
        }
    }
    void StartDayEvent(NpcDayEventType type)
    {
        for (int i = 0; i < npcList.Count; i++)
        {
            NPC_Movement npc = npcList[i];
            Transform eventLocation = npc.GetEventLocation(type);
            npc.SetDestination(eventLocation);
        }       
        
    }
}
