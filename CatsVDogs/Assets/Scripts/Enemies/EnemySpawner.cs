using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawn_time = 5;
    private float timer;

    void Start()
    {
        timer = spawn_time;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            float x_pos = Random.Range(0f, 1f) < 0.5f ? -13 : 13;
            float y_pos = Random.Range(-6, 7);
            var pos = new Vector3(x_pos, y_pos, -1f);

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = pos;
            // enemy.transform.LookAt(new Vector3(0f, 0f, -1f) * -1);
            enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.zero - enemy.transform.position);
            timer = spawn_time;
        }
    }
}
