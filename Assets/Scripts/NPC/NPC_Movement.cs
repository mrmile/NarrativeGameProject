using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minDistanceToNode;
     
    [SerializeField] PathFinder_Manager manager;
    [SerializeField] Transform workLocation;
    [SerializeField] Transform lunchLocation;
    [SerializeField] Transform sleepLocation;

    bool isMoving;
    int index;

    Transform targetDestination;

    List<Vector3> path;
   
    void Start()
    {

        
    }

    
    void Update()
    {
        if(isMoving)
        {
            CheckNextStep();

            Vector3 direction;
            
            direction = (path[index] - transform.position).normalized;
            Walk(direction);
            
        }
    }

    void Walk(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    void CheckNextStep()
    {
        if (index <= 0)
        {           
            isMoving = false;
        }
        else if (index >= 0 && Vector2.Distance(path[index], transform.position) < minDistanceToNode)
        {            
            index--;
        }
       
    }

    public void SetDestination(Transform destination)
    {
        path = new List<Vector3>();
        
        targetDestination = destination;
        
        path = manager.CreatePath(transform.position, targetDestination.position);
        index = path.Count - 1;

        isMoving = true;
    }

    public Transform GetEventLocation(NpcDayEventType eventType)
    {
        switch(eventType)
        {
            case NpcDayEventType.LUNCH: return lunchLocation;
            case NpcDayEventType.BACK_TO_WORK: return workLocation;
            case NpcDayEventType.SLEEP: return sleepLocation;
            default: return workLocation;
                
        }
    }
}
