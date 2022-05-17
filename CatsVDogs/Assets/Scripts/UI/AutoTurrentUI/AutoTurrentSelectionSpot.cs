using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurrentSelectionSpot : MonoBehaviour
{

    public GameObject autoturrent_prefab;
    public LevelController lc;
    public bool on_left;

    public static int creditsNeeded = 10;

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
        if(lc.GetCredits() > creditsNeeded)
        {
            current_turrent = Instantiate(autoturrent_prefab); // create turrent and set its postion to block
            current_turrent.transform.position = transform.position;
            current_turrent.GetComponentInChildren<AutoTurrent>().SetSide(on_left); // set the side its on
            lc.RemoveCredits(creditsNeeded);
            creditsNeeded += creditsNeeded; // increase credits needed
            this.gameObject.SetActive(false);
        }
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
