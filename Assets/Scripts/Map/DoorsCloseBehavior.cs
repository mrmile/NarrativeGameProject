using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsCloseBehavior : MonoBehaviour
{
    public GameObject[] doorGroups;
    int randomDoorGroup = 0;

    MapEventsManager mapEventsManager_;

    private float elapsedTime = 0;
    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;

        if(mapEventsManager_.shutDoorGroup == false && mapEventsManager_.doorsShutEventPhase == 0)
        {
            startTime = Time.time;
        }

        if (mapEventsManager_.shutDoorGroup == true && mapEventsManager_.doorsShutEventPhase == 1)
        {
            mapEventsManager_.doorsShutEventPhase = 2;

            randomDoorGroup = Random.Range(0, doorGroups.Length);

            doorGroups[randomDoorGroup].SetActive(true);
            startTime = Time.time;

            Debug.Log("SHUT DOOR GROUP:" + randomDoorGroup);
        }

        if(mapEventsManager_.doorsShutEventPhase == 2 && elapsedTime >= mapEventsManager_.doorsShutEventDuration)
        {
            mapEventsManager_.shutDoorGroup = false;
            mapEventsManager_.doorsShutEventPhase = 3;
        }

        if (mapEventsManager_.shutDoorGroup == false && mapEventsManager_.doorsShutEventPhase == 3)
        {
            mapEventsManager_.doorsShutEventPhase = 0;

            doorGroups[randomDoorGroup].SetActive(false);
            mapEventsManager_.shutDoorGroup = false;

            //todo: play sound of doors opening

            Debug.Log("DOORS OPENING BACK");
        }
    }
}
