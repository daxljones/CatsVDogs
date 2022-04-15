using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    private Health health;
    public LevelController lc;

    void Start()
    {
        health = GetComponent<Health>();
    }



    void Update()
    {
        if(health.should_be_dead)
        {
            lc.EndGame();
            Destroy(this.gameObject);
        }
    }
}
