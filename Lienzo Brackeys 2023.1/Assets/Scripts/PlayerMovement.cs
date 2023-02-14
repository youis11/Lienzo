using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveLimiter = 0.7f;
    public int health = 100;

    private Rigidbody2D rb;
    Vector2 movement;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;

        if (health<=0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        //play die animation
        //play UI gameover
        //restart variables
    }
}
