using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public HingeJoint hinge;
    JointMotor motor;
    public float velocity;
    public float angle;

    void Start()
    {
        motor = hinge.motor;
    }

    void Update()
    {
        angle = hinge.angle*3;
        motor.targetVelocity = -angle;
        hinge.motor = motor;
    }
}
