﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowCam : MonoBehaviour
{
    // public GameObject[] waypoints;
    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    int currentWP = 0;

    float speed = 6.0f;
    float accuracy = 1.0f;
    float rotationSpeed = 1.0f;

    void MovetoPath()
    {
        if (circuit.Waypoints.Length == 0) return;
        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].position.x, this.transform.position.y, circuit.Waypoints[currentWP].position.z);

        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= circuit.Waypoints.Length)
            {
                currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }


    void LateUpdate()
    {
        MovetoPath();
    }
}
