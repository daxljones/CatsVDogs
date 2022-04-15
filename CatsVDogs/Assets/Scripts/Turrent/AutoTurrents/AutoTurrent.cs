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
        Collider2D[] potentialTargets;
        float r = 1.0f;
        
        do{ // overlap circle grabs all colliders within it and grows in size until max radius or has and colliders in collection
            potentialTargets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), r, 1 << LayerMask.NameToLayer("Enemies"));
            r += 1.0f;
            
            if(r > 20)
            {
                break;
            }

        }while(potentialTargets.Length < 1);  

        target = GetClosestEnemy(potentialTargets);

    }





    GameObject GetClosestEnemy(Collider2D[] resources)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(Collider2D potentialTarget in resources)
        {
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
}
