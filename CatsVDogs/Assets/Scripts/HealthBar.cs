using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Vector3 original_scale;

    void Start()
    {
    }
    
    public void ResizeHealthBar(int max_health, int current_health)
    {
        float percent_of_health = ((float)current_health)/((float)max_health);
        transform.localScale = new Vector3(percent_of_health * original_scale.x, original_scale.y, original_scale.z); // numbers are the same of original scale except for new x
        if(max_health == current_health)
        {
            gameObject.SetActive(false);
        }
    }
}
