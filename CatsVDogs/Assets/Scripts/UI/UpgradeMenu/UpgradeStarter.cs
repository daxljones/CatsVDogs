using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStarter : MonoBehaviour
{

    public UIMaster uim;

    void OnMouseDown()
    {
        uim.DisplayMainMenu();
    }
}
