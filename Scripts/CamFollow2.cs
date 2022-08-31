using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow2 : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;

    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    
    void Update()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}
