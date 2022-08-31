using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public GameObject conveyorHamburger;
    public GameObject conveyorHotDog;

    public GameObject truck;

    public Material truckLevel1;
    public Material truckLevel2;
    public Material truckLevel3;

    public Material conveyorLevel1;
    public Material conveyorLevel2;
    public Material conveyorLevel3;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;

    private void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
    }

    private void Start()
    {
        StartCoroutine(conveyorLevelManager());
    }

    IEnumerator conveyorLevelManager()
    {
        while (true)
        {
            if (truck)
            {
                GameObject kamyon = truck.transform.GetChild(0).gameObject;
                GameObject kamyon2 = kamyon.transform.GetChild(1).gameObject;
                GameObject rightDoor = kamyon.transform.GetChild(4).gameObject;
                GameObject leftDoor = kamyon.transform.GetChild(5).gameObject;

                if (kamyon.tag == "TruckLvl1")
                {
                    Material[] currentlyAssignedMaterials = kamyon2.GetComponent<MeshRenderer>().materials;
                    currentlyAssignedMaterials[3] = truckLevel1;
                    kamyon2.GetComponent<Renderer>().materials = currentlyAssignedMaterials;

                    rightDoor.GetComponent<MeshRenderer>().material = truckLevel1;
                    leftDoor.GetComponent<MeshRenderer>().material = truckLevel1;
                }
                if (kamyon.tag == "TruckLvl2")
                {
                    Material[] currentlyAssignedMaterials = kamyon2.GetComponent<MeshRenderer>().materials;
                    currentlyAssignedMaterials[3] = truckLevel2;
                    kamyon2.GetComponent<Renderer>().materials = currentlyAssignedMaterials;

                    rightDoor.GetComponent<MeshRenderer>().material = truckLevel2;
                    leftDoor.GetComponent<MeshRenderer>().material = truckLevel2;
                }
                if (kamyon.tag == "TruckLvl3")
                {
                    Material[] currentlyAssignedMaterials = kamyon2.GetComponent<MeshRenderer>().materials;
                    currentlyAssignedMaterials[3] = truckLevel3;
                    kamyon2.GetComponent<Renderer>().materials = currentlyAssignedMaterials;

                    rightDoor.GetComponent<MeshRenderer>().material = truckLevel3;
                    leftDoor.GetComponent<MeshRenderer>().material = truckLevel3;
                }
            }

            if (CoinManager.coinManager.conveyor)
            {
                GameObject Conveyor = CoinManager.coinManager.conveyor.transform.parent.gameObject;
                GameObject konveyor1 = Conveyor.transform.GetChild(0).gameObject;
                GameObject konveyor2 = Conveyor.transform.GetChild(1).gameObject;
                GameObject konveyor4 = Conveyor.transform.GetChild(3).gameObject;
                GameObject konveyor5 = Conveyor.transform.GetChild(4).gameObject;

                if (konveyor5.tag == "ConveyorLvl1")
                {
                    konveyor1.GetComponent<MeshRenderer>().material = truckLevel1;
                    konveyor2.GetComponent<MeshRenderer>().material = truckLevel1;
                    konveyor4.GetComponent<MeshRenderer>().material = truckLevel1;
                    konveyor5.GetComponent<MeshRenderer>().material = truckLevel1;
                }
                if (konveyor5.tag == "ConveyorLvl2")
                {
                    konveyor1.GetComponent<MeshRenderer>().material = truckLevel2;
                    konveyor2.GetComponent<MeshRenderer>().material = truckLevel2;
                    konveyor4.GetComponent<MeshRenderer>().material = truckLevel2;
                    konveyor5.GetComponent<MeshRenderer>().material = truckLevel2;
                }
                if (konveyor5.tag == "ConveyorLvl3")
                {
                    konveyor1.GetComponent<MeshRenderer>().material = truckLevel3;
                    konveyor2.GetComponent<MeshRenderer>().material = truckLevel3;
                    konveyor4.GetComponent<MeshRenderer>().material = truckLevel3;
                    konveyor5.GetComponent<MeshRenderer>().material = truckLevel3;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
