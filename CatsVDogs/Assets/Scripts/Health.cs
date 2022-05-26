using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthbar;
    public int max_health;
    public bool should_be_dead = false;

    private int health;

    void Start()
    {
        health = max_health;
        healthbar.original_scale = healthbar.gameObject.transform.localScale;
        healthbar.gameObject.SetActive(false);
    }

    public bool TakeDamage(int dmg)
    {
        healthbar.gameObject.SetActive(true);
        health -= dmg;
        healthbar.ResizeHealthBar(max_health, health);

        if(health <= 0)
        {
            should_be_dead = true;
        }

        return should_be_dead;
    }

    public int GetHealth(){ return health; }
    public void AddHealth(int to_add)
    { 
        health += to_add; 
        healthbar.ResizeHealthBar(max_health, health);
    }
}
