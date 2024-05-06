using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minDistanceToNode;
    [SerializeField] bool isMoving;

    [SerializeField] PathFinder_Manager manager;
   
    [SerializeField] Vector3 targetDestination;

    List<Vector3> path = new List<Vector3>();
    bool destinationReached;
    
    int index;
    void Start()
    {

        SetDestination(targetDestination);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            CheckNextStep();

            Vector3 direction;

            if (!destinationReached)
            {
                direction = (path[index] - transform.position).normalized;
                Walk(direction);
            }

        }
    }

    void Walk(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    void CheckNextStep()
    {
        
        if (index >= 0 && Vector2.Distance(path[index], transform.position) < minDistanceToNode)
        {
            destinationReached = false;
            index--;
        }
        if (index <= 0)
        {
            destinationReached = true;
            isMoving = false;
        }
    }

    public void SetDestination(Vector3 destination)
    {        
        targetDestination = destination;
        
        path = manager.CreatePath(transform.position, targetDestination);
        index = path.Count - 1;

        isMoving = true;
    }
}
