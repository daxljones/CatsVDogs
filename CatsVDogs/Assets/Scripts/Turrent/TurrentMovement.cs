using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentMovement : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = mousePos.x >= 0 ? -1 : 1;
            
            var rotation = Vector3.forward * speed * Time.deltaTime * dir;
            transform.Rotate(rotation); 
            
        }
    }
}
