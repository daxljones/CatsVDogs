using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public UIMaster uim;

    void OnMouseDown()
    {
        uim.ResetMenu();
    }
}
