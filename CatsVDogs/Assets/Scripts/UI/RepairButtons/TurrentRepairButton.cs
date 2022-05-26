using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentRepairButton : MonoBehaviour
{
    public UIMaster uim;

    void OnMouseDown()
    {
        uim.RepairTurrent();
    }
}
