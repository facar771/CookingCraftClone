using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    public static StackTrigger instanceStackTrigger;

    public bool inTrigger = false;
    public bool inTrigger1 = false;
    public bool rubbish = false;
    public bool table = false;
    public bool table2 = false;
    public bool tableCreate = false;
    public bool tableCreate2 = false;
    public bool tableMain = false;
    public bool tableMain2 = false;
    public bool inTriggerContainer = false;
    public bool ovenOut = false;
    public bool ovenHamburgerOut = false;
    public bool ovenHotDogOut = false;
    public bool botCreate = false;
    public bool botCreate2 = false;
    public bool truckUpdate = false;
    public bool truckUpdate2 = false;
    public bool conveyorUpdate = false;
    public bool conveyorUpdate2 = false;
    public bool levelUpdate1 = false;
    public bool levelUpdate2 = false;
    public bool levelUpdate11 = false;
    public bool levelUpdate22 = false;
    public bool waiterUpdate1 = false;
    public bool waiterUpdate2 = false;

    public bool hamburgerOven = false;
    public bool hotDogOven = false;

    public void Awake()
    {
        if (instanceStackTrigger == null)
        {
            instanceStackTrigger = this;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick")
        {
            inTrigger1 = true;
        }
        if (other.tag == "Container")
        {
            inTriggerContainer = true;
        }
        if (other.tag == "Rubbish")
        {
            rubbish = true;
        }
        if (other.tag == "TableCreate")
        {
            RawMaterialManager.rawMaterialManager.tableMain = other.gameObject;
            tableCreate = true;
        }
        if (other.tag == "TableCreate2")
        {
            tableCreate2 = true;
        }
        if (other.tag == "TableMain")
        {
            CoinManager.coinManager.table = other.gameObject;
            tableMain = true;
        }
        if (other.tag == "TableMain2")
        {
            tableMain2 = true;
        }
        if (other.tag == "HamburgerOven")
        {
            hamburgerOven = true;
        }
        if (other.tag == "HotDogOven")
        {
            hotDogOven = true;
        }
        if (other.tag == "Table")
        {
            RawMaterialManager.rawMaterialManager.table = other.gameObject;
            table = true;
        }
        if (other.tag == "Table2")
        {
            table2 = true;
        }
        if (other.tag == "OvenOut")
        {
            ovenOut = true;
        }
        if (other.tag == "OvenHamburgerOut")
        {
            ovenHamburgerOut = true;
        }
        if (other.tag == "OvenHotDogOut")
        {
            ovenHotDogOut = true;
        }
        if (other.tag == "BotCreate")
        {
            CoinManager.coinManager.botCreate = other.gameObject;
            botCreate = true;
        }
        if (other.tag == "BotCreate2")
        {
            botCreate2 = true;
        }
        if (other.tag == "TruckUpdate")
        {
            truckUpdate = true;
        }
        if (other.tag == "TruckUpdate2")
        {
            truckUpdate2 = true;
        }
        if (other.tag == "ConveyorUpdate")
        {
            CoinManager.coinManager.conveyor = other.gameObject;
            conveyorUpdate = true;
        }
        if (other.tag == "ConveyorUpdate2")
        {
            conveyorUpdate2 = true;
        }
        if (other.tag == "LevelUpdate1")
        {
            levelUpdate1 = true;
        }
        if (other.tag == "LevelUpdate11")
        {
            levelUpdate11 = true;
        }
        if (other.tag == "LevelUpdate2")
        {
            levelUpdate2 = true;
        }
        if (other.tag == "LevelUpdate22")
        {
            levelUpdate22 = true;
        }
        if (other.tag == "WaiterUpdate1")
        {
            waiterUpdate1 = true;
        }
        if (other.tag == "WaiterUpdate2")
        {
            waiterUpdate2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pick")
        {
            inTrigger1 = false;
        }
        if (other.tag == "Container")
        {
            inTriggerContainer = false;
        }
        if (other.tag == "Rubbish")
        {
            rubbish = false;
        }
        if (other.tag == "TableCreate")
        {
            tableCreate = false;
        }
        if (other.tag == "TableCreate2")
        {
            tableCreate2 = false;
        }
        if (other.tag == "TableMain")
        {
            tableMain = false;
        }
        if (other.tag == "TableMain2")
        {
            tableMain2 = false;
        }
        if (other.tag == "HamburgerOven")
        {
            hamburgerOven = false;
        }
        if (other.tag == "HotDogOven")
        {
            hotDogOven = false;
        }
        if (other.tag == "Table")
        {
            table = false;
        }
        if (other.tag == "Table2")
        {
            table2 = false;
        }
        if (other.tag == "OvenOut")
        {
            ovenOut = false;
        }
        if (other.tag == "OvenHamburgerOut")
        {
            ovenHamburgerOut = false;
        }
        if (other.tag == "OvenHotDogOut")
        {
            ovenHotDogOut = false;
        }
        if (other.tag == "BotCreate")
        {
            botCreate = false;
        }
        if (other.tag == "BotCreate2")
        {
            botCreate2 = false;
        }
        if (other.tag == "TruckUpdate")
        {
            truckUpdate = false;
        }
        if (other.tag == "TruckUpdate2")
        {
            truckUpdate2 = false;
        }
        if (other.tag == "ConveyorUpdate")
        {
            conveyorUpdate = false;
        }
        if (other.tag == "ConveyorUpdate2")
        {
            conveyorUpdate2 = false;
        }
        if (other.tag == "LevelUpdate1")
        {
            levelUpdate1 = false;
        }
        if (other.tag == "LevelUpdate2")
        {
            levelUpdate2 = false;
        }
        if (other.tag == "LevelUpdate11")
        {
            levelUpdate11 = false;
        }
        if (other.tag == "LevelUpdate22")
        {
            levelUpdate22 = false;
        }
        if (other.tag == "WaiterUpdate1")
        {
            waiterUpdate1 = false;
        }
        if (other.tag == "WaiterUpdate2")
        {
            waiterUpdate2 = false;
        }
    }
}
