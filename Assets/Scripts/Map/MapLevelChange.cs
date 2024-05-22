using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelChange : MonoBehaviour
{
    public int mapLevelToEnter = 0;
    public int mapLevelEntranceID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            if(mapLevelToEnter == 0)
            {
                if (mapLevelEntranceID == 0) //Entrance #0 is the game's start position
                {

                }
                else if (mapLevelEntranceID == 1)
                {

                }
                else if (mapLevelEntranceID == 2)
                {

                }
            }
            else if (mapLevelToEnter == -1)
            {
                if (mapLevelEntranceID == 1)
                {

                }
                else if (mapLevelEntranceID == 2)
                {

                }
            }
        }
    }
}
