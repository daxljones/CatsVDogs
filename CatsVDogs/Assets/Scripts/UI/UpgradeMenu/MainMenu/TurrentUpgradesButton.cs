using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentUpgradesButton : MonoBehaviour
{
    public UIMaster uim;

    void OnMouseDown()
    {
        uim.DisplayTurrentUpgrades();
    }
}
