using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Movment : MonoBehaviour
{
    [SerializeField] CharacterController control;
    [SerializeField] float speed = 2f,height = 3f, grav = -10f;
    public Vector2 Run;
    public bool jump;
    public FixedJoystick joy;
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

        float HorizontalInput = joy.Horizontal;
        float VerticallInput = joy.Vertical;   

        Vector3 move = transform.right * HorizontalInput + transform.forward * VerticallInput;

        control.Move(move * speed * Time.deltaTime);

        if (ground)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(height * grav * -2f);
            }
        }
        else
        {
            velocity.y += grav * Time.deltaTime;
        }
        control.Move(velocity * Time.deltaTime);
    }
}
