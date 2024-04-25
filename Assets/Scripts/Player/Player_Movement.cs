using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] float speed;


    Player_Animations player_animations;
    WalkDirection walkDirection;
    void Start()
    {
        player_animations = GetComponent<Player_Animations>();
    }

    
    void Update()
    {
         walkDirection = WalkDirection.DEFAULT;
        if(Input.GetKey(KeyCode.W))
        {
            Move(Vector2.up);
            walkDirection = WalkDirection.UP;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-Vector2.right);
            walkDirection = WalkDirection.LEFT;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(-Vector2.up);
            walkDirection = WalkDirection.DOWN;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
            walkDirection = WalkDirection.RIGHT;
            player_animations.WalkAnimation(walkDirection);
        }
        else
        {
            player_animations.IdleAnimation();
        }
    }

    void Move(Vector2 direction)
    {
        
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
    }
}
