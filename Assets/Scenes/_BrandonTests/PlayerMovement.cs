using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedRef;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = speedRef;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2 (0,0);

        if (Input.GetKey(KeyCode.W)) movement.y++;
        if (Input.GetKey(KeyCode.S)) movement.y--;
        if (Input.GetKey(KeyCode.A)) movement.x--;
        if (Input.GetKey(KeyCode.D)) movement.x++;

        rb.velocity = movement.normalized * speed;
    }
}
