using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 200;
    public bool should_be_dead = false;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            should_be_dead = true;
            Debug.Log("DEAD");
        }
    }
}
