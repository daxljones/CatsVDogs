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
    public int credits_for_barrel_upgrade = 100;



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
            credits_for_bullet_upgrade = 5 * credits_for_bullet_upgrade;
            return true;
        }
        else
        {
            return false;
        }
    }
}
