using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorTrigger : MonoBehaviour
{
    public bool deneme = false;
    void Start()
    {
        
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<Ovens>().Conveyor = this.gameObject;
            deneme = true;
        }
        if (other.tag == "Customer")
        {
            this.GetComponent<Ovens>().Conveyor = this.gameObject;
        }
    }
}
