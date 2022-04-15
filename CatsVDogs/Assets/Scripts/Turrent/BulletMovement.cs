using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private int damage;

    void Update()
    {

        if(Vector3.Distance(Vector3.zero, transform.position) > 30)
            Destroy(this.gameObject);
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       var e =  col.gameObject.GetComponent<Enemy>();
       if(e != null)
       {
            e.takeDamage(damage);
            Destroy(this.gameObject);
            Debug.Log("Hit");
       }
    }
}
