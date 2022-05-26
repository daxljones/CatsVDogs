using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMaster : MonoBehaviour
{
    public TurrentMovement turrent_movement;
    public TurrentFire turrent_fire;
    public LevelController lc;
    public int credits_for_rotation_upgrade = 50;
    public int credits_for_bullet_upgrade = 50;
    public int credits_for_barrel_upgrade = 500;
    public int cost_per_repair_multiplier = 2;
    public int max_health_to_repair = 50;
    



    public bool UpgradeRotationSpeed()
    {
        if(lc.GetCredits() >= credits_for_rotation_upgrade)
        {
            turrent_movement.UpgradeRotationSpeed();
            lc.RemoveCredits(credits_for_rotation_upgrade);
            credits_for_rotation_upgrade = 3 * credits_for_rotation_upgrade;
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool UpgradeBulletDamage()
    {
        if(lc.GetCredits() >= credits_for_bullet_upgrade)
        {
            turrent_fire.UpgradeBulletDamage();
            lc.RemoveCredits(credits_for_bullet_upgrade);
            credits_for_bullet_upgrade = 3 * credits_for_bullet_upgrade;
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool RepairTurrent(Health turrent_health)
    {
        int health_to_repair = turrent_health.max_health - turrent_health.GetHealth();
        health_to_repair = health_to_repair > max_health_to_repair ? max_health_to_repair : health_to_repair;

        if(lc.GetCredits() >= (cost_per_repair_multiplier * health_to_repair))
        {
            turrent_health.AddHealth(health_to_repair);
            lc.RemoveCredits(cost_per_repair_multiplier * health_to_repair);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RepairBarricade(Health barricade_health)
    {
        Debug.Log("Max: " + barricade_health.max_health);
        Debug.Log("Current: " + barricade_health.GetHealth());


        int health_to_repair = barricade_health.max_health - barricade_health.GetHealth();
        health_to_repair = health_to_repair > max_health_to_repair ? max_health_to_repair : health_to_repair;
        Debug.Log("HTR: " + health_to_repair);

        if(lc.GetCredits() >= (cost_per_repair_multiplier * health_to_repair))
        {
            Debug.Log("Boobs");
            barricade_health.AddHealth(health_to_repair);
            lc.RemoveCredits(cost_per_repair_multiplier * health_to_repair);
            return true;
        }
        else
        {
            Debug.Log("Tits");
            return false;
        }
    }
}
