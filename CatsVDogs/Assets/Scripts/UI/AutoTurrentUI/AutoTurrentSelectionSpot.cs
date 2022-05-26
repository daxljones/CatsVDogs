using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurrentSelectionSpot : MonoBehaviour
{

    public GameObject autoturrent_prefab;
    public LevelController lc;
    public bool on_left;

    public static int base_credits_needed = 50;
    static int num_of_turrents = 1; // starts at 1 for calculating cost purposes

    private GameObject current_turrent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        int credits_needed = base_credits_needed * num_of_turrents;
        if(lc.GetCredits() >= credits_needed)
        {
            current_turrent = Instantiate(autoturrent_prefab); // create turrent and set its postion to block
            current_turrent.transform.position = transform.position;
            current_turrent.GetComponentInChildren<AutoTurrent>().SetSide(on_left); // set the side its on
            current_turrent.GetComponentInChildren<AutoTurrent>().SetSlot(this);
            lc.RemoveCredits(credits_needed);
            num_of_turrents += 1;
            this.gameObject.SetActive(false);
        }
    }




    public void TurrentDied()
    {
        current_turrent = null;
        num_of_turrents--;
    }





    public void Show()
    {
        if(current_turrent == null) // if turrent slot does not have active turrent then show to be open
        {
            this.gameObject.SetActive(true);
        }
    }

    public void Hide(){ this.gameObject.SetActive(false); }
    
}
