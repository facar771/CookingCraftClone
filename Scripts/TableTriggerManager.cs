using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerManager : MonoBehaviour
{
    public static TableTriggerManager tableTriggerManager;
    public bool orderOn = false;
    public bool exit = false;
    public bool foodOn = false;
    GameObject table;

    public void Awake()
    {
        if (tableTriggerManager == null)
        {
            tableTriggerManager = this;
        }
    }
    public void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Table1")
        {
            foodOn = true;
        }
        if (other.tag == "Customer" && this.tag == "Table1")
        {
            orderOn = true;
        }
        if (other.tag == "CustomerFull" && this.tag == "Exit")
        {
            exit = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Table1")
        {
            foodOn = false;
        }
        if (other.tag == "CustomerFull" && this.tag == "Table1")
        {
            orderOn = false;
        }
        if (other.tag == "CustomerFull" && this.tag == "Exit")
        {
            exit = false;
        }
    }
}
