using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 40;

    private ZombieSpawner spawner;
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        GameObject manager = GameObject.FindWithTag("GameController");

        if (manager != null)
        {
            spawner = manager.GetComponent<ZombieSpawner>();
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        //play death animation
        //INSTANTIATE RANDOM PLANT
        spawner.enemiesAmount = spawner.enemiesAmount - 1;
        Destroy(gameObject);
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.PlayerTakeDamage(damage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);

            //ENEMIGOS KAMIKAZE
            spawner.enemiesAmount = spawner.enemiesAmount - 1;
            Destroy(gameObject);
        }
    }
}
