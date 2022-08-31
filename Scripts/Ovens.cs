using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovens : MonoBehaviour
{
    public static Ovens ovens;

    public List<GameObject> hamburgerOvenList = new List<GameObject>();
    public List<GameObject> hotDogOvenList = new List<GameObject>();

    public List<GameObject> hamburgerOvenInList = new List<GameObject>();
    public List<GameObject> hotDogOvenInList = new List<GameObject>();

    private List<GameObject> conveyorLeaveHamburgerList = new List<GameObject>();
    private List<GameObject> conveyorLeaveHotDogList = new List<GameObject>();

    public GameObject Conveyor;

    public Transform ovenParent;

    public int rawOvenPiece = 8;
    private int rawOvenDropPiece = 1;
    public int rawDropOffPiece = 4;

    public float moveSpeed = 0.5f;

    private bool ovenHamburgerEmpty = true;
    private bool ovenHotDogEmpty = true;

    private void Awake()
    {
        if (ovens == null)
        {
            ovens = this;
        }
    }
    void Start()
    {
        StartCoroutine(RawOvenTransform());
        StartCoroutine(RawOvenInTransform());
        StartCoroutine(RawFoodTransform());
        StartCoroutine(FoodOvenOut());
    }
    IEnumerator RawOvenTransform()
    {
        while (true)
        {
            if (Conveyor)
            {
                if (RawMaterialManager.rawMaterialManager.rawPlayerList.Count > 0 && RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].tag == "Raw")
                {
                    if (Conveyor.tag == "HamburgerOven" && StackTrigger.instanceStackTrigger.hamburgerOven && rawOvenPiece > hamburgerOvenList.Count)
                    {
                        GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                        GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                        ovenParent = conveyor3.transform.GetChild(1).gameObject.transform;

                        GameObject pointOven1 = conveyor1.transform.GetChild(0).gameObject;
                        GameObject pointOven2 = conveyor1.transform.GetChild(1).gameObject;

                        if (RawMaterialManager.rawMaterialManager.hamburgerOvenInList.Count == 0)
                        {
                            yield return new WaitForSeconds(0.1f);
                        }

                        float rawCountMove = hamburgerOvenList.Count;
                        int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                        int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                        pointOven2.transform.position = new Vector3(
                            pointOven1.transform.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f),
                            pointOven1.transform.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                            pointOven1.transform.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                        for (int l = 0; l < 20; l++)
                        {
                            Vector3 rawMove = RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.position;
                            Vector3 exitPointMove = pointOven2.transform.position;

                            RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                            RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.rotation = pointOven2.transform.rotation;

                            yield return new WaitForSeconds(0.00005f);
                        }

                        RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.SetParent(ovenParent);

                        hamburgerOvenList.Add(RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1]);

                        RawMaterialManager.rawMaterialManager.rawPlayerList.RemoveAt(RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1);
                    }

                    if (Conveyor.tag == "HotDogOven" && StackTrigger.instanceStackTrigger.hotDogOven && rawOvenPiece > hotDogOvenList.Count)
                    {
                        GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                        GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                        ovenParent = conveyor3.transform.GetChild(1).gameObject.transform;

                        GameObject pointOven1 = conveyor1.transform.GetChild(0).gameObject;
                        GameObject pointOven2 = conveyor1.transform.GetChild(1).gameObject;

                        if (RawMaterialManager.rawMaterialManager.hotDogOvenInList.Count == 0)
                        {
                            yield return new WaitForSeconds(0.1f);
                        }

                        float rawCountMove = hotDogOvenList.Count;
                        int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                        int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                        pointOven2.transform.position = new Vector3(
                            pointOven1.transform.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f),
                            pointOven1.transform.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                            pointOven1.transform.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                        for (int l = 0; l < 20; l++)
                        {
                            Vector3 rawMove = RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.position;
                            Vector3 exitPointMove = pointOven2.transform.position;

                            RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                            RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.rotation = pointOven2.transform.rotation;

                            yield return new WaitForSeconds(0.00005f);
                        }

                        RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1].transform.SetParent(ovenParent);

                        hotDogOvenList.Add(RawMaterialManager.rawMaterialManager.rawPlayerList[RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1]);

                        RawMaterialManager.rawMaterialManager.rawPlayerList.RemoveAt(RawMaterialManager.rawMaterialManager.rawPlayerList.Count - 1);
                    }
                }
                if (!GAMEmanager.gAMEmanager.game1)
                {
                    if (BotRawManager.botRawManager.botRawTakeList.Count > 0 && BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].tag == "Raw")
                    {
                        if (Conveyor.tag == "HamburgerOven" && BotTriggerManager.botTriggerManager.botHamburgerLeave && rawOvenPiece > hamburgerOvenList.Count)
                        {
                            GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                            GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                            ovenParent = conveyor3.transform.GetChild(1).gameObject.transform;

                            GameObject pointOven1 = conveyor1.transform.GetChild(0).gameObject;
                            GameObject pointOven2 = conveyor1.transform.GetChild(1).gameObject;

                            if (RawMaterialManager.rawMaterialManager.hamburgerOvenInList.Count == 0)
                            {
                                yield return new WaitForSeconds(0.1f);
                            }

                            float rawCountMove = hamburgerOvenList.Count;
                            int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                            int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                            pointOven2.transform.position = new Vector3(
                                pointOven1.transform.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f),
                                pointOven1.transform.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                                pointOven1.transform.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                            for (int l = 0; l < 20; l++)
                            {
                                Vector3 rawMove = BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.position;
                                Vector3 exitPointMove = pointOven2.transform.position;

                                BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                                BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.rotation = pointOven2.transform.rotation;

                                yield return new WaitForSeconds(0.00005f);
                            }

                            BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.SetParent(ovenParent);

                            hamburgerOvenList.Add(BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1]);

                            BotRawManager.botRawManager.botRawTakeList.RemoveAt(BotRawManager.botRawManager.botRawTakeList.Count - 1);
                        }

                        if (Conveyor.tag == "HotDogOven" && BotTriggerManager.botTriggerManager.botHotDogLeave && rawOvenPiece > hotDogOvenList.Count)
                        {
                            GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                            GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                            ovenParent = conveyor3.transform.GetChild(1).gameObject.transform;

                            GameObject pointOven1 = conveyor1.transform.GetChild(0).gameObject;
                            GameObject pointOven2 = conveyor1.transform.GetChild(1).gameObject;

                            if (RawMaterialManager.rawMaterialManager.hotDogOvenInList.Count == 0)
                            {
                                yield return new WaitForSeconds(0.1f);
                            }

                            float rawCountMove = hotDogOvenList.Count;
                            int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                            int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                            pointOven2.transform.position = new Vector3(
                                pointOven1.transform.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f),
                                pointOven1.transform.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                                pointOven1.transform.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                            for (int l = 0; l < 20; l++)
                            {
                                Vector3 rawMove = BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.position;
                                Vector3 exitPointMove = pointOven2.transform.position;

                                BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                                BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.rotation = pointOven2.transform.rotation;

                                yield return new WaitForSeconds(0.00005f);
                            }

                            BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1].transform.SetParent(ovenParent);

                            hotDogOvenList.Add(BotRawManager.botRawManager.botRawTakeList[BotRawManager.botRawManager.botRawTakeList.Count - 1]);

                            BotRawManager.botRawManager.botRawTakeList.RemoveAt(BotRawManager.botRawManager.botRawTakeList.Count - 1);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator RawOvenInTransform()
    {
        while (true)
        {
            if (Conveyor)
            {
                while (hamburgerOvenList.Count > 0 || hotDogOvenList.Count > 0)
                {
                    if (Conveyor.tag == "HamburgerOven" && rawOvenDropPiece > hamburgerOvenInList.Count && ovenHamburgerEmpty == true && hamburgerOvenList.Count > 0 && conveyorLeaveHamburgerList.Count < rawDropOffPiece)
                    {
                        GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                        GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                        Transform parent = conveyor1.transform.GetChild(2).gameObject.transform;
                        GameObject point = conveyor3.transform.GetChild(0).gameObject;

                        for (int l = 0; l < 10; l++)
                        {
                            Vector3 rawMove1 = hamburgerOvenList[hamburgerOvenList.Count - 1].transform.position;
                            Vector3 exitPointMove1 = point.transform.position;

                            hamburgerOvenList[hamburgerOvenList.Count - 1].transform.position = Vector3.Lerp(rawMove1, exitPointMove1, 0.2f);
                            yield return new WaitForSeconds(0.00005f);
                        }

                        hamburgerOvenList[hamburgerOvenList.Count - 1].transform.SetParent(parent);

                        hamburgerOvenInList.Add(hamburgerOvenList[hamburgerOvenList.Count - 1]);

                        hamburgerOvenList.RemoveAt(hamburgerOvenList.Count - 1);
                    }

                    if (Conveyor.tag == "HotDogOven" && rawOvenDropPiece > hotDogOvenInList.Count && ovenHotDogEmpty == true && hotDogOvenList.Count > 0 && conveyorLeaveHotDogList.Count < rawDropOffPiece)
                    {
                        GameObject conveyor1 = Conveyor.transform.GetChild(0).gameObject;
                        GameObject conveyor3 = Conveyor.transform.GetChild(2).gameObject;

                        Transform parent = conveyor1.transform.GetChild(2).gameObject.transform;
                        GameObject point = conveyor3.transform.GetChild(0).gameObject;

                        for (int l = 0; l < 10; l++)
                        {
                            Vector3 rawMove1 = hotDogOvenList[hotDogOvenList.Count - 1].transform.position;
                            Vector3 exitPointMove1 = point.transform.position;

                            hotDogOvenList[hotDogOvenList.Count - 1].transform.position = Vector3.Lerp(rawMove1, exitPointMove1, 0.2f);
                            yield return new WaitForSeconds(0.00005f);
                        }

                        hotDogOvenList[hotDogOvenList.Count - 1].transform.SetParent(parent);

                        hotDogOvenInList.Add(hotDogOvenList[hotDogOvenList.Count - 1]);

                        hotDogOvenList.RemoveAt(hotDogOvenList.Count - 1);
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator RawFoodTransform()
    {
        while (true)
        {
            if (Conveyor)
            {
                while (hamburgerOvenInList.Count > 0 || hotDogOvenInList.Count > 0)
                {
                    if (hamburgerOvenInList.Count > 0 && Conveyor.tag == "HamburgerOven" && hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 3f)
                    {
                        hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.Translate(0, moveSpeed * Time.deltaTime, 0);

                        if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z < 5f)
                        {
                            GameObject parentRaw = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.GetChild(1).gameObject;
                            parentRaw.SetActive(false);

                            GameObject parentHamburger = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.GetChild(0).gameObject;
                            parentHamburger.SetActive(true);

                            hamburgerOvenInList[hamburgerOvenInList.Count - 1].tag = "Hamburger";
                        }
                    }

                    if (hotDogOvenInList.Count > 0 && Conveyor.tag == "HotDogOven" && hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 3f)
                    {
                        hotDogOvenInList[hotDogOvenInList.Count - 1].transform.Translate(0, moveSpeed * Time.deltaTime, 0);

                        if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z < 5f)
                        {
                            GameObject parentRaw = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.GetChild(1).gameObject;
                            parentRaw.SetActive(false);

                            GameObject parentHamburger = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.GetChild(2).gameObject;
                            parentHamburger.SetActive(true);

                            hotDogOvenInList[hotDogOvenInList.Count - 1].tag = "HotDog";
                        }
                    }
                    yield return new WaitForSeconds(0.001f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FoodOvenOut()
    {
        while (true)
        {
            while (Conveyor && (hamburgerOvenInList.Count > 0 || hotDogOvenInList.Count > 0) && (RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count < rawDropOffPiece || RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count < rawDropOffPiece))
            {
                if (hamburgerOvenInList.Count > 0 && Conveyor.tag == "HamburgerOven")
                {
                    if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 3.2f)
                    {
                        ovenHamburgerEmpty = false;
                    }
                    if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z < 3.1f && hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 2.7f)
                    {
                        ovenHamburgerEmpty = true;

                        GameObject ovenLeave = Conveyor.transform.GetChild(5).gameObject;
                        Transform parent = ovenLeave.transform.GetChild(0).gameObject.transform;
                        GameObject OvenExitPoint1 = parent.transform.GetChild(0).gameObject;
                        GameObject OvenExitPoint2 = parent.transform.GetChild(1).gameObject;

                        OvenExitPoint1.transform.position = new Vector3(
                            OvenExitPoint2.transform.position.x,
                            OvenExitPoint2.transform.position.y + RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Count / 3f,
                            OvenExitPoint2.transform.position.z);

                        for (int l = 0; l < 30; l++)  
                        {
                            Vector3 rawMove = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position;
                            Vector3 exitPointMove = OvenExitPoint1.transform.position;

                            hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                            yield return new WaitForSeconds(0.00005f);
                        }

                        hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.SetParent(parent);
                        RawMaterialManager.rawMaterialManager.conveyorLeaveHamburgerList.Add(hamburgerOvenInList[hamburgerOvenInList.Count - 1]);
                        hamburgerOvenInList.RemoveAt(hamburgerOvenInList.Count - 1);
                    }
                }

                if (hotDogOvenInList.Count > 0 && Conveyor.tag == "HotDogOven")
                {
                    if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 3.2f)
                    {
                        ovenHamburgerEmpty = false;
                    }
                    if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z < 3.1f && hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 2.7f)
                    {
                        ovenHamburgerEmpty = true;

                        GameObject ovenLeave = Conveyor.transform.GetChild(5).gameObject;
                        Transform parent = ovenLeave.transform.GetChild(0).gameObject.transform;
                        GameObject OvenExitPoint1 = parent.transform.GetChild(0).gameObject;
                        GameObject OvenExitPoint2 = parent.transform.GetChild(1).gameObject;

                        OvenExitPoint1.transform.position = new Vector3(
                            OvenExitPoint2.transform.position.x,
                            OvenExitPoint2.transform.position.y + RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Count / 3f,
                            OvenExitPoint2.transform.position.z);

                        for (int l = 0; l < 30; l++)
                        {
                            Vector3 rawMove = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position;
                            Vector3 exitPointMove = OvenExitPoint1.transform.position;

                            hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                            yield return new WaitForSeconds(0.00005f);
                        }

                        hotDogOvenInList[hotDogOvenInList.Count - 1].transform.SetParent(parent);
                        RawMaterialManager.rawMaterialManager.conveyorLeaveHotDogList.Add(hotDogOvenInList[hotDogOvenInList.Count - 1]);
                        hotDogOvenInList.RemoveAt(hotDogOvenInList.Count - 1);
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}