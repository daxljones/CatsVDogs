using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner es;
    private GameObject currently_touching;

    public int health = 100;
    public int damage = 50;
    public float max_damage_timer = 0.5f;
    private float damage_timer;

    public float speed = 5f;

    private bool attacking = false;


    void Start()
    {
        damage_timer = max_damage_timer;
    }


    void Update()
    {
        if(!attacking)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            Health touching_health_info = currently_touching.GetComponent<Health>(); // get health of object
            if(touching_health_info.should_be_dead)
            {
                attacking = false; // go back to moving 
                damage_timer = max_damage_timer;
            }
            else
            {
                damage_timer -= Time.deltaTime;
                if(damage_timer < 0)
                {
                    touching_health_info.TakeDamage(damage); // give damage
                    damage_timer = max_damage_timer;
                }
            }
        }
    }





    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            es.EnemyKilled();
            Destroy(this.gameObject);
        }
    }






    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag == "Barrier" || hit.gameObject.tag == "Turrent")
        {
            attacking = true;
            currently_touching = hit.gameObject;
        }
    }



    public void SetEnemySpawner(EnemySpawner enemySpawner){ es = enemySpawner; }
}
