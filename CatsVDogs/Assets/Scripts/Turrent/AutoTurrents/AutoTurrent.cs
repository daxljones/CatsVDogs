using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AutoTurrent : MonoBehaviour
{   

    private GameObject target;
    public GameObject bullet;

    public int bullet_damage = 25;
    
    public bool on_left = true;

    public float look_speed = 100f;
    public float bullet_speed = 5.0f;
    public float fire_rate = 0.5f;
    private float timer;

    void Start()
    {
        timer = fire_rate;
        on_left = transform.position.x < 0; // check if turrent is on left
    }


    void Update()
    {
        if(target == null)
            SetEnemyTarget();
        else    
        {
            var look_to = Quaternion.LookRotation(Vector3.forward, target.transform.position - (transform.position)); // calculates where to look
            transform.rotation = Quaternion.Lerp(transform.rotation, look_to, look_speed * Time.deltaTime); // steps to where to look slowly
            
            timer -= Time.deltaTime; // timer functionality for fire rate
            if(timer < 0)
            {   
                FireBullet();
                timer = fire_rate;
            }
        }
        
    }




    void FireBullet()
    {
        GameObject currentBullet = Instantiate(bullet);
        currentBullet.transform.position = transform.position + new Vector3(0, 0, 1);
        currentBullet.transform.rotation = transform.rotation;
        currentBullet.GetComponent<BulletMovement>().SetDamage(bullet_damage);
        currentBullet.GetComponent<Rigidbody2D>().velocity = currentBullet.transform.up * bullet_speed;
    }






    void SetEnemyTarget()
    {   
        Collider2D[] potential_targets;
        List<Collider2D> pt_list = new List<Collider2D>();
        float r = 1.0f;
        
        do{ // overlap circle grabs all colliders within it and grows in size until max radius or has and colliders in collection
            potential_targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), r, 1 << LayerMask.NameToLayer("Enemies"));
            r += 1.0f;
            
            if(r > 20)
            {
                break;
            }

            pt_list = potential_targets.ToList<Collider2D>(); // turn to list for RemoveAll function
            if(on_left)
                pt_list.RemoveAll(t => t.gameObject.transform.position.x > 0);
            else
                pt_list.RemoveAll(t => t.gameObject.transform.position.x < 0);

        }while(pt_list.Count < 1);  
        
        target = GetClosestEnemy(pt_list);
    }





    GameObject GetClosestEnemy(List<Collider2D> resources)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(Collider2D potentialTarget in resources)
        {
            if(potentialTarget.transform.position.x > 0 && on_left)
                continue;
            else if(potentialTarget.transform.position.x < 0 && !on_left)
                continue;

            Vector3 directionToTarget3 = potentialTarget.gameObject.transform.position - currentPosition;
            Vector2 directionToTarget = new Vector2(directionToTarget3.x, directionToTarget3.y);
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.gameObject;
            }
        }             
        return bestTarget;
    }

    public void SetSide(bool is_on_left){ on_left = is_on_left; }
}
