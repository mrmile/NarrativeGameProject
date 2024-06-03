using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessTeleport_Y : MonoBehaviour
{
    public GameObject player;
    public float teleport_Y = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(player.transform.position.x, teleport_Y, 0);
        }
    }
}
