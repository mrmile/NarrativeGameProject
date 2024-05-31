using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player.transform.position = PlayerPosition.newPosition;
    }
}

