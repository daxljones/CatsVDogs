using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner es;
    private GameObject currently_touching;

    private int max_health;
    private float damage_timer;
    private bool attacking = false;

    public LevelController lc;
    public Health health_info;
    public int health = 100;
    public int damage = 50;
    public int credit_reward = 0;
    public float max_damage_timer = 0.5f;
    public float speed = 5f;

    static int died = 0;

    void Start()
    {
        max_health = health;
        damage_timer = max_damage_timer;
        health_info.healthbar.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // fixes rotation of healthbar
        health_info.healthbar.gameObject.transform.position = transform.position + new Vector3(0, -0.5f, 0); // puts healthbar below this object
    }


    void Update()
    {
        if(!attacking)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            Attack();
        }
    }


    public void Attack()
    {
        if(currently_touching != null) // check if null just incase target is destroyed by this point
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
        else // if null then reset attacking
        {
            attacking = false; // go back to moving 
            damage_timer = max_damage_timer;
        }
    }


    public void takeDamage(int damage)
    {
        bool is_dead = health_info.TakeDamage(damage);

        if (is_dead)
        {
            es.EnemyKilled();
            died++;
            Debug.Log("Died: " + died);
            lc.AddCredits(credit_reward);
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
    public void SetLevelController(LevelController level_controller){ lc = level_controller; }
}
