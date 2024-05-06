using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isMoving;


    Pathfinding2D pathfinding;
    [SerializeField] Transform sourceDestination;
    [SerializeField]  Transform targetDestination;
    Vector3 nextStep;
    void Start()
    {
        pathfinding = GetComponent<Pathfinding2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            GetComponent<Pathfinding2D>().FindPath(sourceDestination.position, targetDestination.position);
            //Debug.Log(GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition);
            //nextStep = GetComponent<Pathfinding2D>().GridOwner.GetComponent<Grid2D>().path[0].worldPosition;
            //transform.position += nextStep * speed * Time.deltaTime;
        }
    }
}
