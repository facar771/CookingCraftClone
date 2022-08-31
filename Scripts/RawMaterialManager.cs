using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialManager : MonoBehaviour
{
    public static RawMaterialManager rawMaterialManager;

    private List<GameObject> rawTruckList = new List<GameObject>();
    public List<GameObject> rawDropOffList = new List<GameObject>();
    public List<GameObject> rawPlayerList = new List<GameObject>();

    private List<GameObject> rawOvenList = new List<GameObject>();
    public List<GameObject> hamburgerOvenList = new List<GameObject>();
    public List<GameObject> hotDogOvenList = new List<GameObject>();

    public List<GameObject> hamburgerOvenInList = new List<GameObject>();
    public List<GameObject> hotDogOvenInList = new List<GameObject>();

    private List<GameObject> rawOvenInList = new List<GameObject>();
    private List<GameObject> rawOvenDropList = new List<GameObject>();
    private List<GameObject> conveyorLeaveList = new List<GameObject>();

    public List<GameObject> conveyorLeaveHamburgerList = new List<GameObject>();
    public List<GameObject> conveyorLeaveHotDogList = new List<GameObject>();

    public GameObject raw;
    public GameObject truck;
    public GameObject player;
    public GameObject conveyor;
    public GameObject conveyor2;
    public GameObject table1;

    public GameObject table;
    public GameObject tableMain;
    public GameObject waiterTableMain;
    public GameObject waiterTable;


    public GameObject ConveyorPoint;

    private GameObject parentRaw;
    private GameObject parentHotDog;
    private GameObject parentHamburger;

    public Transform hamburgerOvenParent;
    public Transform hotDogOvenParent;


    public Transform truckParent;
    public Transform rawDropParent;
    public Transform rawPlayerParent;

    public Transform rawOvenParent;     //***********   
    public Transform rawOvenInParent;

    public Transform hamburgerOvenInParent;
    public Transform hotDogOvenInParent;


    public Transform tableParent;
    public Transform foodTableParent;
    public Transform foodTableParent2;

    public Transform truckPoint;
    public Transform rawDropPoint;
    public Transform rawDropPoint1;

    public Transform rawDropPoint2;
    public Transform rawDropPoint3;

    public Transform rawDropPoint4;     //**********
    public Transform rawDropPoint5;
    public Transform rawDropPoint6;

    public Transform rawDropPoint7;     //**********
    public Transform rawDropPoint8;
    public Transform rawDropPoint9;

    public Transform ConveyorLeave;
    public Transform OvenExitPoint;
    public Transform OvenExitPoint2;

    public Transform OvenExitPoint3;
    public Transform OvenExitPoint4;

    public Transform TableExitPoint;
    public Transform TableExitPoint2;
    public Transform TableExitPoint3;
    public Transform TableExitPoint4;
    public Transform TableExitPoint5;

    public Transform TableExitPoint6;
    public Transform TableExitPoint7;
    public Transform TableExitPoint8;
    public Transform TableExitPoint9;
    public Transform TableExitPoint10;

    public Transform rabbish1;
    public Transform rabbish2;


    private int stackCount1 = 4;
    private int stackCount2 = 16;
    public int stackCount3 = 2;
    public int stackCount4 = 4;

    public int rawPiece = 5;
    public int rawLeavePiece = 6;
    public int rawTakePiece = 8;
    public int rawOvenPiece = 8;
    private int rawOvenDropPiece = 1;
    private int rawDropOffPiece = 4;

    private float maximumCome = 22f;
    private float moveSpeed = 0.5f;

    private bool isFull = false;

    private bool ovenHamburgerEmpty = true;
    private bool ovenHotDogEmpty = true;

    private void Awake()
    {
        if (rawMaterialManager == null)
        {
            rawMaterialManager = this;
        }
    }

    void Start()
    {

        rawPiece = 5;
        rawLeavePiece = 6;
        rawOvenPiece = 8;
        stackCount3 = 2;
        stackCount4 = 4;

        rawDropPoint3.transform.rotation = player.transform.rotation;

        StartCoroutine(Rabbish());
        StartCoroutine(FoodTakePlayer());

        StartCoroutine(RawCreate());
        StartCoroutine(RawDropOf());
        StartCoroutine(RawTakePlayer());

        //StartCoroutine(RawOvenTransform());
        //StartCoroutine(RawOvenInTransform());
        //StartCoroutine(RawFoodTransform());
        //StartCoroutine(FoodOvenOut());

        StartCoroutine(FoodTable());
    }

    IEnumerator RawCreate()
    {
        while (true)
        {
            while (truck.transform.position.z > 29)
            {
                float rawCount = rawTruckList.Count;
                int rawCount1 = (int)rawCount / stackCount1;
                int rawCount2 = (int)rawCount / stackCount2;

                if (isFull == false)
                {
                    GameObject rawClone = Instantiate(raw);

                    rawClone.transform.position = new Vector3(
                        truckPoint.position.x - (rawCount % (stackCount1) / 1.8f) - 0.25f,
                        truckPoint.position.y + (((float)rawCount2 % 4) / 2.5f),
                        truckPoint.position.z + (((float)rawCount1 % 4) / 2.25f));


                    rawClone.transform.SetParent(truckParent);       // Kamyonun içine yüklemek için

                    rawTruckList.Add(rawClone);      // Listeye ekleniyor

                    if (rawTruckList.Count >= rawPiece)
                    {
                        isFull = true;
                        TruckMoveManager.truckManagerinstanse.truckIsHere = true;
                    }
                }
                else if (rawTruckList.Count < rawPiece)
                {
                    isFull = false;
                }
                yield return new WaitForSeconds(0.001f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    int i = 0;
    int k = 0;

    IEnumerator RawDropOf()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            while (rawLeavePiece > rawDropOffList.Count && truck.transform.position.z < maximumCome + 0.1)
            {
                float rawCountMove = rawDropOffList.Count;
                int rowCountMove1 = (int)rawCountMove / stackCount1;
                int rowCountMove2 = (int)rawCountMove / stackCount2;

                rawDropPoint1.transform.position = new Vector3(
                    rawDropPoint.position.x - (rawCountMove % (stackCount1) / 1.8f), // - 0.25f
                    rawDropPoint.position.y + (((float)rowCountMove2 % 4) / 2.5f),
                    rawDropPoint.position.z + (((float)rowCountMove1 % 4) / 2.25f));

                for (int l = 0; l < 20; l++)
                {
                    Vector3 rawMove = rawTruckList[rawTruckList.Count - 1].transform.position;
                    Vector3 exitPointMove = rawDropPoint1.transform.position;

                    rawTruckList[rawTruckList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                    yield return new WaitForSeconds(0.00005f);
                }

                rawTruckList[rawTruckList.Count - 1].transform.SetParent(rawDropParent);

                rawDropOffList.Add(rawTruckList[rawTruckList.Count - 1]);

                rawTruckList.RemoveAt(rawTruckList.Count - 1);

                yield return new WaitForSeconds(0.2f);

                if (rawTruckList.Count == 0)
                {
                    TruckMoveManager.truckManagerinstanse.truckIsHere = false;
                    yield return new WaitForSeconds(1f);
                }
                if (rawDropOffList.Count == rawLeavePiece)
                {
                    TruckMoveManager.truckManagerinstanse.truckIsHere = false;
                    yield return new WaitForSeconds(1f);
                }
            }
            if (rawDropOffList.Count == rawLeavePiece && truck.transform.position.z < maximumCome + 0.1)
            {
                yield return new WaitForSeconds(1f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = false;
            }
            if (rawDropOffList.Count == rawLeavePiece && rawTruckList.Count == rawPiece && truck.transform.position.z > 29)
            {
                yield return new WaitForSeconds(1f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = true;
            }
        }
    }

    IEnumerator RawTakePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            while (rawTakePiece > rawPlayerList.Count && StackTrigger.instanceStackTrigger.inTrigger1 == true && rawDropOffList.Count > 0)
            {
                rawDropPoint3.transform.position = new Vector3(
                    rawDropPoint2.position.x,
                    rawDropPoint2.position.y + rawPlayerList.Count / 3f,
                    rawDropPoint2.position.z);

                rawDropOffList[rawDropOffList.Count - 1].transform.position = rawDropPoint3.transform.position;

                rawDropOffList[rawDropOffList.Count - 1].transform.SetParent(rawPlayerParent);

                rawPlayerList.Add(rawDropOffList[rawDropOffList.Count - 1]);

                rawDropOffList.RemoveAt(rawDropOffList.Count - 1);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    //IEnumerator RawOvenTransform()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        while (rawPlayerList.Count > 0)
    //        {
    //            if (rawOvenPiece > hotDogOvenList.Count && StackTrigger.instanceStackTrigger.hotDogOven == true && rawPlayerList[rawPlayerList.Count - 1].tag == "Raw")
    //            {
    //                if (hamburgerOvenInList.Count == 0)
    //                {
    //                    yield return new WaitForSeconds(0.1f);
    //                }
    //                float rawCountMove = hotDogOvenList.Count;
    //                int rowCountMove1 = (int)rawCountMove / stackCount3;
    //                int rowCountMove2 = (int)rawCountMove / stackCount4;

    //                rawDropPoint8.transform.position = new Vector3(
    //                    rawDropPoint7.position.x + (rawCountMove % (stackCount3) / 1.8f),
    //                    rawDropPoint7.position.y + (((float)rowCountMove2 % 2) / 2.5f),
    //                    rawDropPoint7.position.z - (((float)rowCountMove1 % 2) / 2.25f));

    //                for (int l = 0; l < 20; l++)
    //                {
    //                    Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
    //                    Vector3 exitPointMove = rawDropPoint8.transform.position;

    //                    rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
    //                    rawPlayerList[rawPlayerList.Count - 1].transform.rotation = rawDropPoint8.transform.rotation;

    //                    yield return new WaitForSeconds(0.00005f);
    //                }

    //                rawPlayerList[rawPlayerList.Count - 1].transform.SetParent(hotDogOvenParent);

    //                hotDogOvenList.Add(rawPlayerList[rawPlayerList.Count - 1]);   //rawDropOffList rawTruckList

    //                rawPlayerList.RemoveAt(rawPlayerList.Count - 1);

    //                yield return new WaitForSeconds(0.1f);
    //            }
    //            if (rawOvenPiece > hamburgerOvenList.Count && StackTrigger.instanceStackTrigger.hamburgerOven == true && rawPlayerList.Count > 0 && rawPlayerList[rawPlayerList.Count - 1].tag == "Raw")
    //            {
    //                if (hamburgerOvenInList.Count == 0)
    //                {
    //                    yield return new WaitForSeconds(0.1f);
    //                }

    //                float rawCountMove = hamburgerOvenList.Count;
    //                int rowCountMove1 = (int)rawCountMove / stackCount3;
    //                int rowCountMove2 = (int)rawCountMove / stackCount4;

    //                rawDropPoint5.transform.position = new Vector3(
    //                    rawDropPoint4.position.x + (rawCountMove % (stackCount3) / 1.8f), // - 0.25f
    //                    rawDropPoint4.position.y + (((float)rowCountMove2 % 2) / 2.5f),
    //                    rawDropPoint4.position.z - (((float)rowCountMove1 % 2) / 2.25f));

    //                for (int l = 0; l < 20; l++)
    //                {
    //                    Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
    //                    Vector3 exitPointMove = rawDropPoint5.transform.position;

    //                    rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
    //                    rawPlayerList[rawPlayerList.Count - 1].transform.rotation = rawDropPoint5.transform.rotation;

    //                    yield return new WaitForSeconds(0.00005f);
    //                }

    //                rawPlayerList[rawPlayerList.Count - 1].transform.SetParent(hamburgerOvenParent);

    //                hamburgerOvenList.Add(rawPlayerList[rawPlayerList.Count - 1]);   //rawDropOffList rawTruckList

    //                rawPlayerList.RemoveAt(rawPlayerList.Count - 1);

    //                yield return new WaitForSeconds(0.1f);
    //            }


    //            yield return new WaitForSeconds(0.1f);
    //        }
    //    }
    //}

    //IEnumerator RawOvenInTransform()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.1f);     //rawOvenList rawOvenInList

    //        while (hamburgerOvenList.Count > 0 || hotDogOvenList.Count > 0)
    //        {
    //            if (conveyor.tag == "HamburgerOven" && rawOvenDropPiece > hamburgerOvenInList.Count && ovenHamburgerEmpty == true && hamburgerOvenList.Count > 0 && conveyorLeaveHamburgerList.Count < rawDropOffPiece)
    //            {
    //                for (int l = 0; l < 10; l++)
    //                {
    //                    Vector3 rawMove1 = hamburgerOvenList[hamburgerOvenList.Count - 1].transform.position;
    //                    Vector3 exitPointMove1 = rawDropPoint6.transform.position;

    //                    hamburgerOvenList[hamburgerOvenList.Count - 1].transform.position = Vector3.Lerp(rawMove1, exitPointMove1, 0.2f);
    //                    yield return new WaitForSeconds(0.00005f);
    //                }

    //                hamburgerOvenList[hamburgerOvenList.Count - 1].transform.SetParent(hamburgerOvenInParent);

    //                hamburgerOvenInList.Add(hamburgerOvenList[hamburgerOvenList.Count - 1]);

    //                hamburgerOvenList.RemoveAt(hamburgerOvenList.Count - 1);


    //            }


    //            if (conveyor2.tag == "HotDogOven" && rawOvenDropPiece > hotDogOvenInList.Count && ovenHotDogEmpty == true && hotDogOvenList.Count > 0 && conveyorLeaveHotDogList.Count < rawDropOffPiece)
    //            {
    //                for (int l = 0; l < 10; l++)
    //                {
    //                    Vector3 rawMove1 = hotDogOvenList[hotDogOvenList.Count - 1].transform.position;
    //                    Vector3 exitPointMove1 = rawDropPoint9.transform.position;

    //                    hotDogOvenList[hotDogOvenList.Count - 1].transform.position = Vector3.Lerp(rawMove1, exitPointMove1, 0.2f);
    //                    yield return new WaitForSeconds(0.00005f);
    //                }

    //                hotDogOvenList[hotDogOvenList.Count - 1].transform.SetParent(hotDogOvenInParent);

    //                hotDogOvenInList.Add(hotDogOvenList[hotDogOvenList.Count - 1]);

    //                hotDogOvenList.RemoveAt(hotDogOvenList.Count - 1);


    //            }
    //            yield return new WaitForSeconds(1f);
    //        }
    //    }
    //}

    //IEnumerator RawFoodTransform()
    //{
    //    while (true)
    //    {
    //        while (hamburgerOvenInList.Count > 0 || hotDogOvenInList.Count > 0)
    //        {
    //            print(hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z);
    //            if (hamburgerOvenInList.Count > 0 && conveyor.tag == "HamburgerOven" && hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 3f)
    //            {
    //                hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.Translate(0, moveSpeed * Time.deltaTime, 0);

    //                if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z < 5f)
    //                {
    //                    parentRaw = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.GetChild(1).gameObject;
    //                    parentRaw.SetActive(false);

    //                    parentHamburger = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.GetChild(0).gameObject;
    //                    parentHamburger.SetActive(true);

    //                    hamburgerOvenInList[hamburgerOvenInList.Count - 1].tag = "Hamburger";
    //                }
    //            }
    //            if (hotDogOvenInList.Count > 0 && conveyor2.tag == "HotDogOven" && hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 9f)
    //            {
    //                hotDogOvenInList[hotDogOvenInList.Count - 1].transform.Translate(0, moveSpeed * Time.deltaTime, 0);

    //                if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z < 10f)
    //                {
    //                    parentRaw = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.GetChild(1).gameObject;
    //                    parentRaw.SetActive(false);

    //                    parentHotDog = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.GetChild(2).gameObject;
    //                    parentHotDog.SetActive(true);

    //                    hotDogOvenInList[hotDogOvenInList.Count - 1].tag = "HotDog";
    //                }
    //            }
    //            yield return new WaitForSeconds(0.001f);
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    //IEnumerator FoodOvenOut()
    //{
    //    while (true)
    //    {
    //        while ((hamburgerOvenInList.Count > 0 || hotDogOvenInList.Count > 0) && (conveyorLeaveHamburgerList.Count < rawDropOffPiece || conveyorLeaveHotDogList.Count < rawDropOffPiece))
    //        {
    //            if (hamburgerOvenInList.Count > 0 && conveyor.tag == "HamburgerOven")
    //            {
    //                if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 3.2f)
    //                {
    //                    ovenHamburgerEmpty = false;
    //                }
    //                if (hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z < 3.1f && hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position.z > 2.7f)   //&& rawOvenInList[rawOvenInList.Count - 1].transform.position.z > 8.7f
    //                {
    //                    ovenHamburgerEmpty = true;

    //                    OvenExitPoint.transform.position = new Vector3(
    //                        OvenExitPoint2.position.x,
    //                        OvenExitPoint2.position.y + conveyorLeaveHamburgerList.Count / 3f,
    //                        OvenExitPoint2.position.z);

    //                    for (int l = 0; l < 30; l++)     //SORUN BURADA
    //                    {
    //                        Vector3 rawMove = hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position;
    //                        Vector3 exitPointMove = OvenExitPoint.transform.position;

    //                        hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
    //                        yield return new WaitForSeconds(0.00005f);
    //                    }

    //                    hamburgerOvenInList[hamburgerOvenInList.Count - 1].transform.SetParent(ConveyorLeave);
    //                    conveyorLeaveHamburgerList.Add(hamburgerOvenInList[hamburgerOvenInList.Count - 1]);
    //                    hamburgerOvenInList.RemoveAt(hamburgerOvenInList.Count - 1);
    //                }
    //            }
    //            if (hotDogOvenInList.Count > 0 && conveyor2.tag == "HotDogOven")
    //            {
    //                if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 9.2f)
    //                {
    //                    ovenHotDogEmpty = false;
    //                }
    //                if (hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z < 9.1f && hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position.z > 8.7f)   //&& rawOvenInList[rawOvenInList.Count - 1].transform.position.z > 8.7f
    //                {
    //                    ovenHotDogEmpty = true;

    //                    OvenExitPoint3.transform.position = new Vector3(
    //                        OvenExitPoint4.position.x,
    //                        OvenExitPoint4.position.y + conveyorLeaveHotDogList.Count / 3f,
    //                        OvenExitPoint4.position.z);

    //                    for (int l = 0; l < 30; l++)     //SORUN BURADA
    //                    {
    //                        Vector3 rawMove = hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position;
    //                        Vector3 exitPointMove = OvenExitPoint3.transform.position;

    //                        hotDogOvenInList[hotDogOvenInList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
    //                        yield return new WaitForSeconds(0.00005f);
    //                    }

    //                    hotDogOvenInList[hotDogOvenInList.Count - 1].transform.SetParent(ConveyorLeave);
    //                    conveyorLeaveHotDogList.Add(hotDogOvenInList[hotDogOvenInList.Count - 1]);
    //                    hotDogOvenInList.RemoveAt(hotDogOvenInList.Count - 1);
    //                }
    //            }

    //            yield return new WaitForSeconds(0.1f);
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    IEnumerator FoodTakePlayer()
    {
        while (true)
        {
            while (conveyorLeaveHamburgerList.Count > 0 || conveyorLeaveHotDogList.Count > 0 && rawTakePiece > rawPlayerList.Count)
            {
                if (conveyorLeaveHamburgerList.Count > 0 && StackTrigger.instanceStackTrigger.ovenHamburgerOut)
                {
                    rawDropPoint3.transform.position = new Vector3(
                        rawDropPoint2.position.x,
                        rawDropPoint2.position.y + rawPlayerList.Count / 3f,
                        rawDropPoint2.position.z);

                    conveyorLeaveHamburgerList[conveyorLeaveHamburgerList.Count - 1].transform.position = rawDropPoint3.transform.position;


                    conveyorLeaveHamburgerList[conveyorLeaveHamburgerList.Count - 1].transform.SetParent(rawPlayerParent);

                    rawPlayerList.Add(conveyorLeaveHamburgerList[conveyorLeaveHamburgerList.Count - 1]);

                    conveyorLeaveHamburgerList.RemoveAt(conveyorLeaveHamburgerList.Count - 1);

                    yield return new WaitForSeconds(0.1f);
                }
                if (conveyorLeaveHotDogList.Count > 0 && StackTrigger.instanceStackTrigger.ovenHotDogOut)
                {
                    rawDropPoint3.transform.position = new Vector3(
                        rawDropPoint2.position.x,
                        rawDropPoint2.position.y + rawPlayerList.Count / 3f,
                        rawDropPoint2.position.z);

                    conveyorLeaveHotDogList[conveyorLeaveHotDogList.Count - 1].transform.position = rawDropPoint3.transform.position;


                    conveyorLeaveHotDogList[conveyorLeaveHotDogList.Count - 1].transform.SetParent(rawPlayerParent);

                    rawPlayerList.Add(conveyorLeaveHotDogList[conveyorLeaveHotDogList.Count - 1]);

                    conveyorLeaveHotDogList.RemoveAt(conveyorLeaveHotDogList.Count - 1);

                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FoodTable()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            while (StackTrigger.instanceStackTrigger.table == true && rawPlayerList.Count > 0 && tableMain.GetComponent<Tables>().tableOn && tableMain.GetComponent<Tables>().customerHere)
            {
                if (rawPlayerList.Count > 0 && rawPlayerList[rawPlayerList.Count - 1].tag == "Hamburger" && tableMain.GetComponent<Tables>().hamburgerPrice > 0 && tableMain.GetComponent<Tables>().putFood)
                {
                    foodTableParent = table.transform.GetChild(1);
                    TableExitPoint = table.transform.GetChild(2);
                    TableExitPoint2 = table.transform.GetChild(3);
                    
                    TableExitPoint.transform.position = new Vector3(
                        TableExitPoint2.position.x,
                        TableExitPoint2.position.y + tableMain.GetComponent<Tables>().tableHamburgerList.Count / 3f,
                        TableExitPoint2.position.z);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint.transform.position;

                        rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        rawPlayerList[rawPlayerList.Count - 1].transform.rotation = TableExitPoint.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    rawPlayerList[rawPlayerList.Count - 1].transform.SetParent(foodTableParent);

                    tableMain.GetComponent<Tables>().tableHamburgerList.Add(rawPlayerList[rawPlayerList.Count - 1]);   //rawDropOffList rawTruckList

                    rawPlayerList.RemoveAt(rawPlayerList.Count - 1);

                    tableMain.GetComponent<Tables>().hamburgerPrice -= 1;
                }

                if (rawPlayerList.Count > 0 && rawPlayerList[rawPlayerList.Count - 1].tag == "HotDog" && tableMain.GetComponent<Tables>().hotDogPrice > 0 && tableMain.GetComponent<Tables>().putFood)
                {
                    foodTableParent = table.transform.GetChild(1);
                    TableExitPoint3 = table.transform.GetChild(4);
                    TableExitPoint4 = table.transform.GetChild(5);

                    TableExitPoint3.transform.position = new Vector3(
                        TableExitPoint4.position.x,
                        TableExitPoint4.position.y + tableMain.GetComponent<Tables>().tableHotDogList.Count / 3f,
                        TableExitPoint4.position.z);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint3.transform.position;

                        rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        rawPlayerList[rawPlayerList.Count - 1].transform.rotation = TableExitPoint3.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    rawPlayerList[rawPlayerList.Count - 1].transform.SetParent(foodTableParent);

                    tableMain.GetComponent<Tables>().tableHotDogList.Add(rawPlayerList[rawPlayerList.Count - 1]);   //rawDropOffList rawTruckList

                    rawPlayerList.RemoveAt(rawPlayerList.Count - 1);

                    tableMain.GetComponent<Tables>().hotDogPrice -= 1;
                }

                if (rawPlayerList.Count > 1 && tableMain.GetComponent<Tables>().hamburgerPrice == 0 && tableMain.GetComponent<Tables>().hotDogPrice > 0 && rawPlayerList[rawPlayerList.Count - 1].tag == "Hamburger")
                {
                    int sayi = 1;
                    for (int i = 0; i < sayi; i++)
                    {
                        if (sayi < rawPlayerList.Count)
                        {
                            if (rawPlayerList[i].tag == "HotDog")
                            {
                                rawPlayerList[rawPlayerList.Count - 1].transform.position = rawPlayerList[i].transform.position;
                                GameObject g1= rawPlayerList[rawPlayerList.Count - 1];
                                rawPlayerList[rawPlayerList.Count - 1] = rawPlayerList[i];
                                rawPlayerList[i] = g1;
                            }
                            if (!(rawPlayerList[i].tag == "HotDog"))
                            {
                                sayi += 1;
                            }
                        }
                    }
                }

                if (rawPlayerList.Count > 1 && tableMain.GetComponent<Tables>().hotDogPrice == 0 && tableMain.GetComponent<Tables>().hamburgerPrice > 0 && rawPlayerList[rawPlayerList.Count - 1].tag == "HotDog")
                {
                    int sayi = 1;
                    for (int i = 0; i < sayi; i++)
                    {
                        if (sayi < rawPlayerList.Count)
                        {
                            if (rawPlayerList[i].tag == "Hamburger")
                            {
                                rawPlayerList[rawPlayerList.Count - 1].transform.position = rawPlayerList[i].transform.position;
                                GameObject g1 = rawPlayerList[rawPlayerList.Count - 1];
                                rawPlayerList[rawPlayerList.Count - 1] = rawPlayerList[i];
                                rawPlayerList[i] = g1;
                            }
                            if (!(rawPlayerList[i].tag == "Hamburger"))
                            {
                                sayi += 1;
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(0.01f);
            }

            //***************************************************************************************************************

            while (waiterTable && WaiterTrigger.waiterTrigger.waiterTablePut && WaiterRawManager.waiterRawManager.rawWaiterList.Count > 0 && waiterTable.GetComponent<Tables>().tableOn && waiterTable.GetComponent<Tables>().customerHere)
            {
                if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 0 && WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "Hamburger" && waiterTable.GetComponent<Tables>().hamburgerPrice > 0 && waiterTable.GetComponent<Tables>().putFood)
                {
                    waiterTableMain = waiterTable.transform.GetChild(0).gameObject;
                    foodTableParent = waiterTableMain.transform.GetChild(1);
                    TableExitPoint = waiterTableMain.transform.GetChild(2);
                    TableExitPoint2 = waiterTableMain.transform.GetChild(3);

                    TableExitPoint.transform.position = new Vector3(
                        TableExitPoint2.position.x,
                        TableExitPoint2.position.y + waiterTable.GetComponent<Tables>().tableHamburgerList.Count / 3f,
                        TableExitPoint2.position.z);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint.transform.position;

                        WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.rotation = TableExitPoint.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.SetParent(foodTableParent);

                    waiterTable.GetComponent<Tables>().tableHamburgerList.Add(WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1]);   

                    WaiterRawManager.waiterRawManager.rawWaiterList.RemoveAt(WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1);

                    waiterTable.GetComponent<Tables>().hamburgerPrice -= 1;
                }

                if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 0 && WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "HotDog" && waiterTable.GetComponent<Tables>().hotDogPrice > 0 && waiterTable.GetComponent<Tables>().putFood)
                {
                    waiterTableMain = waiterTable.transform.GetChild(0).gameObject;
                    foodTableParent = waiterTableMain.transform.GetChild(1);
                    TableExitPoint3 = waiterTableMain.transform.GetChild(4);
                    TableExitPoint4 = waiterTableMain.transform.GetChild(5);

                    TableExitPoint3.transform.position = new Vector3(
                        TableExitPoint4.position.x,
                        TableExitPoint4.position.y + waiterTable.GetComponent<Tables>().tableHotDogList.Count / 3f,
                        TableExitPoint4.position.z);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint3.transform.position;

                        WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.rotation = TableExitPoint3.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.SetParent(foodTableParent);

                    waiterTable.GetComponent<Tables>().tableHotDogList.Add(WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1]);   //rawDropOffList rawTruckList

                    WaiterRawManager.waiterRawManager.rawWaiterList.RemoveAt(WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1);

                    waiterTable.GetComponent<Tables>().hotDogPrice -= 1;
                }

                if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 1 && waiterTable.GetComponent<Tables>().hamburgerPrice == 0 && waiterTable.GetComponent<Tables>().hotDogPrice > 0 && WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "Hamburger")
                {
                    int sayi = 1;
                    for (int i = 0; i < sayi; i++)
                    {
                        if (sayi < WaiterRawManager.waiterRawManager.rawWaiterList.Count)
                        {
                            if (WaiterRawManager.waiterRawManager.rawWaiterList[i].tag == "HotDog")
                            {
                                WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position = WaiterRawManager.waiterRawManager.rawWaiterList[i].transform.position;
                                GameObject g1 = WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1];
                                WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1] = WaiterRawManager.waiterRawManager.rawWaiterList[i];
                                WaiterRawManager.waiterRawManager.rawWaiterList[i] = g1;
                            }
                            if (!(WaiterRawManager.waiterRawManager.rawWaiterList[i].tag == "HotDog"))
                            {
                                sayi += 1;
                            }
                        }
                    }
                }

                if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 1 && waiterTable.GetComponent<Tables>().hotDogPrice == 0 && waiterTable.GetComponent<Tables>().hamburgerPrice > 0 && WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "HotDog")
                {
                    int sayi = 1;
                    for (int i = 0; i < sayi; i++)
                    {
                        if (sayi < WaiterRawManager.waiterRawManager.rawWaiterList.Count)
                        {
                            if (WaiterRawManager.waiterRawManager.rawWaiterList[i].tag == "Hamburger")
                            {
                                WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].transform.position = WaiterRawManager.waiterRawManager.rawWaiterList[i].transform.position;
                                GameObject g1 = WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1];
                                WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1] = WaiterRawManager.waiterRawManager.rawWaiterList[i];
                                WaiterRawManager.waiterRawManager.rawWaiterList[i] = g1;
                            }
                            if (!(WaiterRawManager.waiterRawManager.rawWaiterList[i].tag == "Hamburger"))
                            {
                                sayi += 1;
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    //*******************************************************************************************************************************************
    IEnumerator Rabbish()
    {
        while (true)
        {
            while (StackTrigger.instanceStackTrigger.rubbish == true && rawPlayerList.Count > 0)
            {
                for (i = 0; i < rawPlayerList.Count; i++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
                        Vector3 exitPointMove = rabbish2.transform.position;

                        rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        yield return new WaitForSeconds(0.00005f);
                    }

                    for (int k = 0; k < 10; k++)
                    {
                        Vector3 rawMove = rawPlayerList[rawPlayerList.Count - 1].transform.position;
                        Vector3 exitPointMove = rabbish1.transform.position;

                        rawPlayerList[rawPlayerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        yield return new WaitForSeconds(0.00005f);
                    }
                    Destroy(rawPlayerList[rawPlayerList.Count - 1]);
                    rawPlayerList.RemoveAt(rawPlayerList.Count - 1);
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator Transform(int stackCount1, int stackCount2, int rawPiece)
    {
        for (i = 0; i < rawTruckList.Count; i++)     //int i = rawList.Count; i > 0; i--
        {
            float rawCountMove = i;
            int rowCountMove1 = (int)rawCountMove / stackCount1;
            int rowCountMove2 = (int)rawCountMove / stackCount2;

            rawDropPoint.transform.position = new Vector3(
                rawDropPoint.position.x - (rawCountMove % (stackCount1) / 1.8f), // - 0.25f
                rawDropPoint.position.y + (((float)rowCountMove2 % 4) / 2.5f),
                rawDropPoint.position.z + (((float)rowCountMove1 % 4) / 2.25f));

            rawDropPoint.transform.rotation = new Quaternion(
                rawDropPoint.rotation.x,
                rawDropPoint.rotation.y,
                rawDropPoint.rotation.z,
                rawDropPoint.rotation.w);

            rawTruckList[rawTruckList.Count - 1 + k].transform.SetParent(rawDropParent);

            for (int l = 0; l < 100; l++)
            {
                Vector3 rawMove = rawTruckList[rawTruckList.Count - 1 + k].transform.position;
                Vector3 exitPointMove = rawDropPoint.transform.position;

                rawTruckList[rawTruckList.Count - 1 + k].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                yield return new WaitForSeconds(0.00005f);
            }

            k -= 1;
        }
    }
}