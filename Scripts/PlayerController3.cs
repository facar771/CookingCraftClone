using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public Joystick joy;

    void Update()
    {
        Vector3 movement = new Vector3(joy.Vertical, 0, joy.Horizontal) * Time.deltaTime * 5f;
    }
}
