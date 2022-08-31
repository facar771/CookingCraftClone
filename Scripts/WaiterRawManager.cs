using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterRawManager : MonoBehaviour
{
    public static WaiterRawManager waiterRawManager;

    public List<GameObject> rawWaiterList = new List<GameObject>();

    int rawWaiterPiece = 2;

    private void Awake()
    {
        if (waiterRawManager == null)
        {
            waiterRawManager = this;
        }
    }
    void Start()
    {
        StartCoroutine(WaiterFoodTake());
    }

    IEnumerator WaiterFoodTake()
    {
        while (true)
        {
            if (true)
            {
                if ((RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count > 0 || RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count > 0)
                    && rawWaiterPiece > rawWaiterList.Count)
                {
                    if (RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count > 0 &&
                        WaiterTrigger.waiterTrigger.waiterHamburgerTake)
                    {
                        Transform parent = this.transform.GetChild(20);
                        Transform rawDropPoint2 = this.transform.GetChild(0);
                        Transform rawDropPoint3 = this.transform.GetChild(1);

                        rawDropPoint3.transform.position = new Vector3(
                        rawDropPoint2.position.x,
                        rawDropPoint2.position.y + rawWaiterList.Count / 3f,
                        rawDropPoint2.position.z);

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList[RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count - 1].transform.position = rawDropPoint3.transform.position;

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList[RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count - 1].transform.SetParent(parent);

                        rawWaiterList.Add(RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList[RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count - 1]);

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.RemoveAt(RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count - 1);
                    }

                    if (RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count > 0 &&
                        WaiterTrigger.waiterTrigger.waiterHotDogTake)
                    {
                        Transform parent = this.transform.GetChild(20);
                        Transform rawDropPoint2 = this.transform.GetChild(0);
                        Transform rawDropPoint3 = this.transform.GetChild(1);

                        rawDropPoint3.transform.position = new Vector3(
                        rawDropPoint2.position.x,
                        rawDropPoint2.position.y + rawWaiterList.Count / 3f,
                        rawDropPoint2.position.z);

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList[RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count - 1].transform.position = rawDropPoint3.transform.position;

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList[RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count - 1].transform.SetParent(parent);

                        rawWaiterList.Add(RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList[RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count - 1]);

                        RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.RemoveAt(RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count - 1);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
