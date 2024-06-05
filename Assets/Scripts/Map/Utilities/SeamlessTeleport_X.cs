using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessTeleport_X : MonoBehaviour
{
    GameObject player;
    public float teleport_X = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(teleport_X, player.transform.position.y, 0);
        }
    }
}
