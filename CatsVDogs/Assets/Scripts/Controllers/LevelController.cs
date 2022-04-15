using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public enum RoundStatus{Playing, Break}


public class LevelController : MonoBehaviour
{
    private int round;
    RoundStatus round_status;
    public float break_timer = 10f;
    private float timer;
    public EnemySpawner enemy_spawner;

    private Dictionary<String, int> enemies;



    void Start()
    {
        round = 0;
        timer = break_timer / 2;
        round_status = RoundStatus.Break;

        enemies = new Dictionary<string, int>();
        enemies.Add("Blue", 0);
        enemies.Add("Red", 0);
        enemies.Add("Green", 0);
        enemies.Add("Orange", 0);
        enemies.Add("Black", 0);

    }




    void Update()
    {
        if(round_status == RoundStatus.Break)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                StartRound();
            }
        }
        
    }




    void StartRound()
    {
        round++;

        if(round % 15 == 0)
        {
            enemies["Black"] += (round / 15 + 1) * 2; // increase number of enemies to spawn
        }
        else if(round % 10 == 0)
        {
            enemies["Orange"] += (round / 10 + 1) * 2; // increase number of enemies to spawn
        }
        else if(round % 7 == 0)
        {
            enemies["Green"] += (round / 7 + 1) * 2; // increase number of enemies to spawn
        }
        else if(round % 3 == 0)
        {
            enemies["Red"] += (round / 3 + 1) * 2; // increase number of enemies to spawn
        }
        else
        {
            enemies["Blue"] += round * 2; // increase number of enemies to spawn
        }

        SendEnemyCountToEnemySpawner();
        round_status = RoundStatus.Playing;
        Debug.Log("Starting Round " + round + "!");
    }




    void SendEnemyCountToEnemySpawner()
    {
        int i = 0; 
        int total_to_spawn = 0;
        List<int[]> list_to_spawn = new List<int[]>();
        foreach(int v in enemies.Values)
        {
            if(v == 0)
                continue;
            list_to_spawn.Add(new int[]{i, v}); // i => level of enemy where blue = 0 ... black = 4 for array, v = count
            
            i++;
            total_to_spawn += v;
        }

        enemy_spawner.PrepareEnemySpawner(list_to_spawn, total_to_spawn);
    }



    public void EndRound()
    { 
        round_status = RoundStatus.Break; 
        timer = break_timer;
    }

    public void EndGame()
    {
        round_status = RoundStatus.Break; 
        timer = 999999;
        Debug.Log("You Lost!");
    }




    public RoundStatus GetRoundStatus(){ return round_status; }

}
