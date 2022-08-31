using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterTrigger : MonoBehaviour
{
    public static WaiterTrigger waiterTrigger;

    public bool waiterHamburgerTake;
    public bool waiterHotDogTake;
    public bool waiterTablePut;
    public bool waiterZone;
    

    private void Awake()
    {
        if (waiterTrigger == null)
        {
            waiterTrigger = this;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WaiterHamburger")
        {
            waiterHamburgerTake = true;
        }
        if (other.tag == "WaiterHotDog")
        {
            waiterHotDogTake = true;
        }
        if (other.tag == "WaiterTable")
        {
            waiterTablePut = true;
        }
        if (other.tag == "WaiterZone")
        {
            waiterZone = true;
        }
        if (other.tag == "TableCreate")
        {
            RawMaterialManager.rawMaterialManager.waiterTable = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "WaiterHamburger")
        {
            waiterHamburgerTake = false;
        }
        if (other.tag == "WaiterHotDog")
        {
            waiterHotDogTake = false;
        }
        if (other.tag == "WaiterTable")
        {
            waiterTablePut = false;
        }
        if (other.tag == "WaiterZone")
        {
            waiterZone = false;
        }
    }
}
