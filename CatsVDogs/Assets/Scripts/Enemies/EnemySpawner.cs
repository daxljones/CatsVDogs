using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy_prefabs;
    public float spawn_time = 3;
    private float timer;
    public LevelController lc;

    private List<int[]> list_to_spawn;
    private int total_enemies_left;



    void Start()
    {
        timer = spawn_time;
    }





    void Update()
    {
        if(lc.GetRoundStatus() == RoundStatus.Playing)
        {
            if(list_to_spawn.Count > 0)
            {
                timer -= Time.deltaTime;

                if(timer < 0)
                {
                    SpawnAnEnemy();
                    timer = spawn_time;
                }
            }

            if(total_enemies_left == 0)
            {
                Debug.Log("Round Ending");
                lc.EndRound();
            }
        }
    }

    



    void SpawnAnEnemy()
    {
        int enemy_to_pick = Random.Range(0, list_to_spawn.Count);
        int index_of_enemy_prefab = (list_to_spawn[enemy_to_pick])[0];
        GameObject enemy_to_create = enemy_prefabs[index_of_enemy_prefab];
        
        float x_pos = Random.Range(0f, 1f) < 0.5f ? -13 : 13;
        float y_pos = Random.Range(-6, 7);
        var pos = new Vector3(x_pos, y_pos, -1f);

        GameObject enemy = Instantiate(enemy_to_create);
        enemy.transform.position = pos;
        enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.zero - enemy.transform.position);
        enemy.GetComponent<Enemy>().SetEnemySpawner(this);
        enemy.GetComponent<Enemy>().SetLevelController(lc);

        list_to_spawn[enemy_to_pick][1] -= 1; // decrement count to spawn of specific type

        if(list_to_spawn[enemy_to_pick][1] == 0)
            list_to_spawn.RemoveAt(enemy_to_pick);
    }





    public void PrepareEnemySpawner(List<int[]> lts, int tel)
    { 
        list_to_spawn = lts; 
        total_enemies_left = tel;
        Debug.Log("Total to spawn: " + total_enemies_left);

    }

    public void EnemyKilled() { total_enemies_left--; Debug.Log("Enemies Left: " + total_enemies_left); }
}
