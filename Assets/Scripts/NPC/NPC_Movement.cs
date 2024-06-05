using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class NPC_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minDistanceToNode;
     
    [SerializeField] PathFinder_Manager manager;
    [SerializeField] Transform workLocation;
    [SerializeField] Transform lunchLocation;
    [SerializeField] Transform sleepLocation;

    [SerializeField] Animator animator;

    public bool isMoving;
    bool wasMoving = false;
    int index;

    Transform targetDestination;

    List<Vector3> path;

    GameObject dialogPanel;

    void Start()
    {
        animator.SetBool("isIdle", true);
        animator.SetFloat("X", 0.0f);
        animator.SetFloat("Y", 0.0f);
        dialogPanel = ConversationManager.Instance.DialoguePanel.gameObject;



    }


    void Update()
    {

        if (dialogPanel.activeSelf)
        {
            if (isMoving)
            {
                wasMoving = true;
                isMoving = false;
            }

        }
        else if (wasMoving)
        {
            isMoving = true;
            wasMoving = false;
        }
            


        if (isMoving)
        {
            CheckNextStep();

            Vector3 direction;

            direction = (path[index] - transform.position).normalized;

            animator.SetBool("isIdle", false);

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                animator.SetFloat("Y", 0.0f);

                if (direction.x > 0) animator.SetFloat("X", 1.0f);
                else animator.SetFloat("X", -1.0f);
            }
            else
            {
                animator.SetFloat("X", 0.0f);

                if (direction.y > 0) animator.SetFloat("Y", 1.0f);
                else animator.SetFloat("Y", -1.0f);
            }

            Walk(direction);

        }
        else Idle();
        
    }

    void Walk(Vector3 dir)
    {
    
        transform.position += dir * speed * Time.deltaTime;
    }
    void Idle()
    {
        isMoving = false;

        animator.SetFloat("X", 0.0f);
        animator.SetFloat("Y", 0.0f);
        animator.SetBool("isIdle", true);
    }
    void CheckNextStep()
    {
        if (index <= 0)
        {
            Idle();
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
