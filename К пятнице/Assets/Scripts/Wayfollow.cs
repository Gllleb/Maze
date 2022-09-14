using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayfollow : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    [SerializeField] float speed = 1f;
    int currentpoint = 0;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoint[currentpoint].transform.position) < .1f)
        {
            currentpoint++;
            if(currentpoint >= waypoint.Length)
            {
                currentpoint = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoint[currentpoint].transform.position, speed * Time.deltaTime);
    }
}
