using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public Vector3 offset;
    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        //Follow only in X Position..
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, 0f),
                    new Vector3(targetCamPos.x, transform.position.y, 5f),
                    smoothing * Time.fixedDeltaTime);
    }
}
