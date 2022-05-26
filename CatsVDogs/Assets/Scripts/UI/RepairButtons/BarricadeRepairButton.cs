using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeRepairButton : MonoBehaviour
{
    public UIMaster uim;

    void OnMouseDown()
    {
        uim.RepairBarricade();
    }
}
