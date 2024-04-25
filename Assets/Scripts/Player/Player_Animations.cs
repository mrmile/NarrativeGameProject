using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WalkDirection
{
    UP,
    LEFT,
    DOWN,
    RIGHT,
    DEFAULT
}
public class Player_Animations : MonoBehaviour
{
    [SerializeField] Animation playerAnimation;
    [SerializeField] Animator playerAnimator;


    [Header("Idle Animation")]
    [SerializeField] AnimationClip idleAnimation;

    [Header("Walking Animations")]
    [SerializeField] AnimationClip walkUpAnimation;
    [SerializeField] AnimationClip walkLeftAnimation;
    [SerializeField] AnimationClip walkDownAnimation;
    [SerializeField] AnimationClip walkRightAnimation;

    WalkDirection lastWalkDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkAnimation(WalkDirection direction)
    {
        switch(direction)
        {
            case WalkDirection.UP: playerAnimation.clip = walkUpAnimation;
                break;
            case WalkDirection.LEFT:
                playerAnimation.clip = walkLeftAnimation;
                break;
            case WalkDirection.DOWN:
                playerAnimator.SetTrigger("Walk_Down");
                playerAnimator.SetBool("Idle", false);
                lastWalkDirection = WalkDirection.DOWN;
                //playerAnimation.clip = walkDownAnimation;
                break;
            case WalkDirection.RIGHT:
                {
                    
                    lastWalkDirection = WalkDirection.RIGHT;
                    break;
                }


            default:
                {

                    break;
                }
                 
                
        }
       
        playerAnimation.Play();
    }
    public void IdleAnimation()
    {
        playerAnimator.SetTrigger("Idle_Trigger");
        switch(lastWalkDirection)
        {
            case WalkDirection.UP:
            {
                break;
            }
            case WalkDirection.LEFT:
                {
                    break;
                }
            case WalkDirection.DOWN:
                {
                    
                    
                    playerAnimator.SetBool("Idle", true);
                    
                    break;
                }
            case WalkDirection.RIGHT:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
