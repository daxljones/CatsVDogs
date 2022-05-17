using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurrentSlotMaster : MonoBehaviour
{
    private AutoTurrentSelectionSpot[] children;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<AutoTurrentSelectionSpot>();
        HideSlots();
    }

    public void ShowSlots()
    {
        foreach(AutoTurrentSelectionSpot child in children)
        {
            child.Show();
        }
    }

    public void HideSlots()
    {
        foreach(AutoTurrentSelectionSpot child in children)
        {
            child.Hide();
        }
    }
}
