using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] CharacterController control;
    [SerializeField] float speed = 2f,height = 3f, grav = -10f;


    Vector3 velocity;

    [SerializeField] Transform groundcheck;
    [SerializeField] float groundDistance = 0.1f;
    [SerializeField] LayerMask groundMask;

    bool ground;

    void Update()
    {
        ground=Physics.CheckSphere(groundcheck.position,groundDistance,groundMask);

        if(ground && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticallInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * HorizontalInput + transform.forward * VerticallInput;

        control.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && ground)
        {
            velocity.y = Mathf.Sqrt(height * grav * -2f);
        }

        velocity.y += grav * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);
    }
}
