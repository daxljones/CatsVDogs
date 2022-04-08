using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if(Vector3.Distance(Vector3.zero, transform.position) < 2f)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(this.gameObject);
    }
}
