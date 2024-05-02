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
    [SerializeField] Animator playerAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void WalkAnimation(WalkDirection direction)
    {
        
        switch(direction)
        {            
            case WalkDirection.UP:
                {
                    if (!playerAnimator.GetBool("Walk_Up"))
                    {
                        ClearAnimatorVariables();
                        playerAnimator.SetBool("Walk_Up", true);
                    }

                    break;
                }                
            case WalkDirection.LEFT:
                {
                    if (!playerAnimator.GetBool("Walk_Left"))
                    {
                        ClearAnimatorVariables();
                        playerAnimator.SetBool("Walk_Left", true);
                    }

                    break;
                }
               
            case WalkDirection.DOWN:
                {
                    if (!playerAnimator.GetBool("Walk_Down"))
                    {
                        ClearAnimatorVariables();
                        playerAnimator.SetBool("Walk_Down", true);
                    }

                  break;
                }
                
            case WalkDirection.RIGHT:
                {
                    if (!playerAnimator.GetBool("Walk_Right"))
                    {
                        ClearAnimatorVariables();
                        playerAnimator.SetBool("Walk_Right", true);
                    }
                                      
                    break;
                }

            default:
                {
                    break;
                }                           
        }              
    }
    public void IdleAnimation()
    {
        ClearAnimatorVariables();
        playerAnimator.SetBool("Idle", true);      
    }

    void ClearAnimatorVariables()
    {
        playerAnimator.SetBool("Idle", false);

        playerAnimator.SetBool("Walk_Up", false);
        playerAnimator.SetBool("Walk_Left", false);
        playerAnimator.SetBool("Walk_Down", false);
        playerAnimator.SetBool("Walk_Right", false);
    }
}
