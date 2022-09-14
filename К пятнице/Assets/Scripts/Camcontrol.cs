using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontrol : MonoBehaviour
{
    [SerializeField] float sensivity = 3500f;
    [SerializeField] Transform Player;
    float rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* sensivity * Time.deltaTime;

        rotation-=mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);

    }
}
