using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentMovement : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var dir = touchPos.x >= 0 ? -1 : 1;
            
            var rotation = Vector3.forward * speed * Time.deltaTime * dir;
            transform.Rotate(rotation); 
            
        }

        if(Input.GetMouseButton(0))
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = touchPos.x >= 0 ? -1 : 1;
            
            var rotation = Vector3.forward * speed * Time.deltaTime * dir;
            transform.Rotate(rotation); 
            
        }
    }


    public void UpgradeRotationSpeed()
    {
        speed += 25;
    }
}
