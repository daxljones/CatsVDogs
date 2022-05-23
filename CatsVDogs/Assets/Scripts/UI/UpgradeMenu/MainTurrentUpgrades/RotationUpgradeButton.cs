using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUpgradeButton : MonoBehaviour
{
   public UIMaster uim;

   void OnMouseDown()
   {
       uim.UpgradeTurrentRotation();
   }
}
