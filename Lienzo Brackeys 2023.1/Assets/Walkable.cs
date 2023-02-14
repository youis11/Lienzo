using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    public float speed = 2f;
    public float force = 2f;

    private const float ForcePower = 10f;
    private new Rigidbody2D rigidbody;
    private Vector2 direction;
    private Transform target;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            target = player.GetComponent<Transform>();
        }
    }

    public void MoveTo(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Stop()
    {
        MoveTo(Vector2.zero);
    }

    private void Update()
    {
        var directionTowardsTarget = (target.position - this.transform.position).normalized;
        MoveTo(directionTowardsTarget);
    }

    private void FixedUpdate()
    {
        var desiredVelocity = direction * speed;
        var deltaVelocity = desiredVelocity - rigidbody.velocity;
        Vector3 moveForce = deltaVelocity * (force * ForcePower * Time.fixedDeltaTime);
        rigidbody.AddForce(moveForce);
    }
}
