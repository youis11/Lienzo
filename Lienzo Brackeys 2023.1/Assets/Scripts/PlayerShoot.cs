using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 20f;

    //public Transform shootPoint;

    //TO DO: get it from player movement
    private float moveLimiter = 0.7f;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= coolDown)
        {
            if (Input.GetKeyDown("space"))
            {
                Shoot();
            }
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Shoot()
    {
        if (movement.x != 0 && movement.y != 0)
        {
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        GameObject bPrefab = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Rigidbody2D rb = bPrefab.GetComponent<Rigidbody2D>();

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        rb.SetRotation(angle);

        rb.AddForce(movement * bulletSpeed, ForceMode2D.Impulse);
        
        coolDown = Time.time + attackSpeed;
    }
}
