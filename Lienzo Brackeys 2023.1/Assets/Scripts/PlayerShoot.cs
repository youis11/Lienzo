using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float attackSpeed = 1.0f;
    public float coolDown;
    public float bulletSpeed = 500f;

    private Vector3 mousePos;

    public GameObject muscleEffect;

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

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - transform.position.z));
        
    }

    void Shoot()
    {
        //GameObject effect = Instantiate(muscleEffect, transform.position, Quaternion.identity);
        //Animator an = effect.GetComponent<Animator>();
        //an.Play("musel effect");

        //Destroy(effect, 5f);

        GameObject bPrefab = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Vector3 dir = mousePos - transform.position;

        Rigidbody2D rb = bPrefab.GetComponent<Rigidbody2D>();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.SetRotation(angle);

        rb.AddForce(dir.normalized * bulletSpeed, ForceMode2D.Impulse);

        coolDown = Time.time + attackSpeed;
    }
}
