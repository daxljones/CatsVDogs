using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageUpgradeButton : MonoBehaviour
{
    public UIMaster uim;

    void OnMouseDown()
    {
        uim.UpgradeTurrentBulletDamage();
    }
}
