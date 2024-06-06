using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] bool canMove;
    [SerializeField] float speed;

    Rigidbody2D rb;
    Player_Animations player_animations;
    WalkDirection walkDirection;

    [SerializeField] GameObject conversation;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && player != gameObject) 
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }



    void Start()
    {
        player_animations = GetComponent<Player_Animations>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (conversation != null)
            if (conversation.activeSelf) canMove = false;
            else canMove = true;



        walkDirection = WalkDirection.DEFAULT;

        if (!canMove)
        {
            player_animations.IdleAnimation();
            return;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            walkDirection = WalkDirection.UP;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            walkDirection = WalkDirection.LEFT;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            walkDirection = WalkDirection.DOWN;
            player_animations.WalkAnimation(walkDirection);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            walkDirection = WalkDirection.RIGHT;
            player_animations.WalkAnimation(walkDirection);
        }
        else
        {
            player_animations.IdleAnimation();
        }
    }
    void FixedUpdate()
    {
        Move(Vector2.zero);
        if (!canMove) return;
        if(Input.GetKey(KeyCode.W))
        {
            Move(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-Vector2.right);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(-Vector2.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }
        else
        {
            Move(Vector2.zero);
        }
    }

    void Move(Vector2 direction)
    {
        
        //transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
        rb.velocity = direction.normalized * speed;
    }

    public void CanMove(bool can)
    {
        canMove = can;
    }
}
