using UnityEngine;
using System.Collections;

public class TurrentFire : MonoBehaviour
{
    public GameObject bullet;
    public LevelController lc;
    public int bullet_damage = 50;
    public float fire_rate = 0.5f;
    private float timer;
    public float speed = 5.0f;


    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {   
            bool pointing_left = transform.rotation.eulerAngles.z > 60 && transform.rotation.eulerAngles.z < 116;
            bool pointing_right = transform.rotation.eulerAngles.z > 237 && transform.rotation.eulerAngles.z < 295;

            if(pointing_left || pointing_right && lc.GetRoundStatus() == RoundStatus.Playing)
            {
                GameObject currentBullet = Instantiate(bullet);
                currentBullet.transform.position = Vector3.zero;
                currentBullet.transform.rotation = transform.rotation;
                currentBullet.GetComponent<BulletMovement>().SetDamage(bullet_damage);
                currentBullet.GetComponent<Rigidbody2D>().velocity = currentBullet.transform.up * speed;
                timer = fire_rate;
            }
        }
    }
}
