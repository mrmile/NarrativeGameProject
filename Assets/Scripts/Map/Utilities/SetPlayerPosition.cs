using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        player.transform.position = PlayerPosition.newPosition;
    }
}

