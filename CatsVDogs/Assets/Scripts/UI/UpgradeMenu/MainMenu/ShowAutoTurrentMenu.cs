using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAutoTurrentMenu : MonoBehaviour
{

    public UIMaster uim;

    void OnMouseDown()
    {
        uim.ShowAutoTurrentSlots();
    }
}
