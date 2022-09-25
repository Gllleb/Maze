using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontrol : MonoBehaviour
{
    [SerializeField] float sensivity = 3500f;
    [SerializeField] Transform Player;
    float rotation = 0f;
    float mouseX = 0;
    float mouseY = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            mouseX = Input.GetTouch(0).deltaPosition.x;
            mouseY = Input.GetTouch(0).deltaPosition.y;
        }

        rotation-=mouseY * Time.deltaTime;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);

    }
}
