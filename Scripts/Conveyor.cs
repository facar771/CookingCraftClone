using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public static Conveyor conveyorTrigger;

    public GameObject conveyor;
    private GameObject g;

    private Rigidbody rgb;

    float yOffset = 0;
    public float speed = 5;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        if (conveyorTrigger == null)
        {
            conveyorTrigger = this;
        }
    }
    void Start()
    {
        g = conveyor.transform.GetChild(2).gameObject;
        rgb = g.GetComponent<Rigidbody>();
        meshRenderer = g.GetComponent<MeshRenderer>();

    }
    void FixedUpdate()
    {
        yOffset += Time.fixedDeltaTime * speed;

        Vector3 pos = rgb.position;
        rgb.position -= transform.forward * Time.fixedDeltaTime * speed;
        rgb.MovePosition(pos);

        meshRenderer.sharedMaterial.mainTextureOffset = new Vector2(0, yOffset); 
    }
}
