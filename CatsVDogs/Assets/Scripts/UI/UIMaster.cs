using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaster : MonoBehaviour
{

    public AutoTurrentSlotMaster atsm;
    public UpgradeMaster um;
    public GameObject menu_display_arrow, exit_button,
                      auto_turrents_button, turrent_upgrade_button, 
                      turrent_upgrade_menu, barrel_upgrade_button, rotation_upgrade_button, bullet_upgrade_button,
                      repair_turrent_button, repair_barricade_button; 
    public Health turrent_health, barricade_health;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }









    public void BeginMenu()
    {
        menu_display_arrow.SetActive(true);
        ShowRepairs();
    }


    // hides all possible menu items with option of including exit button
    public void HideMenu(bool hide_exit_button)
    {
        menu_display_arrow.SetActive(false);
        turrent_upgrade_button.SetActive(false);
        turrent_upgrade_menu.SetActive(false);
        auto_turrents_button.SetActive(false);
        repair_barricade_button.SetActive(false);
        repair_turrent_button.SetActive(false);
        HideAutoTurrentSlots();

        if(hide_exit_button)
            exit_button.SetActive(false);

    }


    public void ResetMenu()
    {
        HideMenu(true);
        BeginMenu();
    }


    public void DisplayMainMenu()
    {
        turrent_upgrade_button.SetActive(true);
        auto_turrents_button.SetActive(true);
        exit_button.SetActive(true);
        menu_display_arrow.SetActive(false);
        repair_barricade_button.SetActive(false);
        repair_turrent_button.SetActive(false);
    }


    void ShowRepairs()
    {
        if(turrent_health.GetHealth() < turrent_health.max_health)
        {
            repair_turrent_button.SetActive(true);
        }
        if(barricade_health.GetHealth() < barricade_health.max_health)
        {
            repair_barricade_button.SetActive(true);
        }
    }









    public void RepairBarricade()
    {
        um.RepairBarricade(barricade_health);
        if(barricade_health.GetHealth() < barricade_health.max_health)
            repair_turrent_button.SetActive(false);

        
    }

    public void RepairTurrent()
    {
        um.RepairTurrent(turrent_health);
        if(turrent_health.GetHealth() < turrent_health.max_health)
            repair_barricade_button.SetActive(false);

    }









    public void DisplayTurrentUpgrades()
    {
        HideMenu(false);
        turrent_upgrade_menu.SetActive(true);
    }

    public void UpgradeTurrentRotation()
    {
        bool upgrade_worked = um.UpgradeRotationSpeed();
        if(upgrade_worked)
        {
            ResetMenu();
        }
        else
        {
            // todo: turn button red
        }
    }

    public void UpgradeTurrentBulletDamage()
    {
        bool upgrade_worked = um.UpgradeBulletDamage();
        if(upgrade_worked)
        {
            ResetMenu();
        }
        else
        {
            // todo: turn button red
        }
    }

    public void UpgradeTurrentBarrels()
    {
        
    }





 

 

    public void ShowAutoTurrentSlots()
    {
        HideMenu(false); // hide menu but save exit button
        atsm.ShowSlots(); // show the slots
    }

    public void HideAutoTurrentSlots()
    {
        atsm.HideSlots(); // used to hide slots during hiding menu
    }
}
