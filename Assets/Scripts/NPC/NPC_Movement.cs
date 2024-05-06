using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minDistanceToNode;
    [SerializeField] bool isMoving;

    [SerializeField] GridManager manager;

    [SerializeField] Transform sourceDestination;
    [SerializeField] Transform targetDestination;

    List<Vector3> path = new List<Vector3>();
    bool destinationReached;
    Vector3 nextStep;
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            path = manager.CreatePath(transform.position, targetDestination.position);
            Vector3 direction;
            int index = path.Count - 1;
            while (CheckDistanceToNextNode(index))
            {
                index--;
            }
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
        Debug.Log(dir);
    }
    bool CheckDistanceToNextNode(int k)
    {
        if (k <= 0)
        {
            destinationReached = true;
            return false;
        }
        if (Vector2.Distance(path[k], transform.position) < minDistanceToNode) return true;
        else return false;
        
    }
}
