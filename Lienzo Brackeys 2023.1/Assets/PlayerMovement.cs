using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveLimiter = 0.7f;

    private Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        //Movement
        if(movement.x != 0 && movement.y !=0)
        {
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
