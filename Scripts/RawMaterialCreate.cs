using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialCreate : MonoBehaviour
{
    public static RawMaterialCreate rawInstance;

    public List<GameObject> rawList = new List<GameObject>();
    public List<GameObject> rawLeaveList = new List<GameObject>();

    public List<Transform> exitPointList = new List<Transform>();

    //public static RawMaterialCreate instance;

    //StackManager.instance.PickUp

    //[SerializeField] private float distanceBetweenObjects1;
    //[SerializeField] private float distanceBetweenObjects;
    //[SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform truckLeaveParent;

    public GameObject truck;
    public GameObject raw;
    //public GameObject player;

    public Transform exitPoint;
    public Transform exitPoint1;
    public Transform exitPoint2;
    //public Transform Biker;

    public float t;
    private int truckLeavePiece = 10;
    int m = 0;

    private float maximumCome = 22f;

    bool isWorking = true;
    int stackCount1 = 4;
    int stackCount2 = 16;

    void Start()
    {
        //RawCreate();

        //distanceBetweenObjects = prevObject.localScale.y;

        StartCoroutine(RawCreate());

        StartCoroutine(RawTransform());

        //RemoveLast();

        //RawCreateFirst();
    }

    private void Awake()
    {
        if (rawInstance == null)
        {
            rawInstance = this;
        }
    }

    public void RemoveLast()
    {
        /*
        if (rawList.Count > 0)
        {
            Destroy(rawList[rawList.Count - 1]);
            rawList.RemoveAt(rawList.Count - 1);
        }
        */
    }

    IEnumerator TruckCome()
    {
        while (true)
        {
            if (truck.transform.position.z < 23)
            {
                yield return new WaitForSeconds(1f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator TruckBack()
    {
        while (true)
        {
            if (truck.transform.position.z > 29)
            {
                yield return new WaitForSeconds(2f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator RawTransform()
    {
        int i = 0;
        int k = 0;
        while (true)
        {
            StartCoroutine(TruckBack());

            yield return new WaitForSeconds(1f);

            if (rawList.Count < truckLeavePiece)
            {
                while (i < rawList.Count)   //20
                {
                    if (truck.transform.position.z < maximumCome + 0.1)
                    {
                        for (i = 0; i < truckLeavePiece; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            float rawCountMove = i;
                            int rowCountMove1 = (int)rawCountMove / stackCount1;
                            int rowCountMove2 = (int)rawCountMove / stackCount2;

                            //Transform tr = Instantiate(exitPoint1);

                            exitPoint1.transform.position = new Vector3(
                                exitPoint2.position.x - (rawCountMove % (stackCount1) / 1.8f), // - 0.25f
                                exitPoint2.position.y + (((float)rowCountMove2 % 4) / 2.5f),
                                exitPoint2.position.z + (((float)rowCountMove1 % 4) / 2.25f));

                            //exitPoint1.transform.SetParent(truckLeaveParent);

                            //exitPointList.Add(exitPoint1);

                            if (rawLeaveList.Count < 1)
                            {
                                rawList[rawList.Count - 1].transform.SetParent(truckLeaveParent);

                                print(rawList.Count);

                                print(rawList);

                                for (int l = 0; l < 100; l++)
                                {
                                    Vector3 rawMove = rawList[rawList.Count - 1].transform.position;
                                    Vector3 exitPointMove = exitPoint1.transform.position;

                                    rawList[rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                    yield return new WaitForSeconds(0.00005f);
                                }

                                rawLeaveList.Add(rawList[rawList.Count - 1]);
                                rawList.RemoveAt(rawList.Count - 1);    //BURADA KALDIN
                            }

                            else
                            {
                                rawList[rawList.Count - 1].transform.SetParent(truckLeaveParent);

                                print(rawList.Count);

                                print(rawList);

                                for (int l = 0; l < 100; l++)
                                {
                                    Vector3 rawMove = rawList[rawList.Count - 1].transform.position;
                                    Vector3 exitPointMove = exitPoint1.transform.position;

                                    rawList[rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                    yield return new WaitForSeconds(0.00005f);
                                }

                                rawLeaveList.Add(rawList[rawList.Count - 1]);
                                rawList.RemoveAt(rawList.Count - 1);    //BURADA KALDIN
                            }

                            k -= 1;
                            print(exitPoint1.transform.position);
                        }
                    }

                    m += 1;
                    yield return new WaitForSeconds(0.1f);
                }
            }

            else if (rawList.Count > truckLeavePiece)
            {
                while (i < truckLeavePiece)   //20
                {
                    if (truck.transform.position.z < maximumCome + 0.1)
                    {
                        for (i = 0; i < truckLeavePiece; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            float rawCountMove = i;
                            int rowCountMove1 = (int)rawCountMove / stackCount1;
                            int rowCountMove2 = (int)rawCountMove / stackCount2;

                            //Transform tr = Instantiate(exitPoint1);

                            exitPoint1.transform.position = new Vector3(
                                exitPoint2.position.x - (rawCountMove % (stackCount1) / 1.8f), // - 0.25f
                                exitPoint2.position.y + (((float)rowCountMove2 % 4) / 2.5f),
                                exitPoint2.position.z + (((float)rowCountMove1 % 4) / 2.25f));

                            //exitPoint1.transform.SetParent(truckLeaveParent);

                            //exitPointList.Add(exitPoint1);

                            if (rawLeaveList.Count < 1)
                            {
                                rawList[rawList.Count - 1].transform.SetParent(truckLeaveParent);

                                print(rawList.Count);

                                print(rawList);

                                for (int l = 0; l < 100; l++)
                                {
                                    Vector3 rawMove = rawList[rawList.Count - 1].transform.position;
                                    Vector3 exitPointMove = exitPoint1.transform.position;

                                    rawList[rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                    yield return new WaitForSeconds(0.00005f);
                                }

                                rawLeaveList.Add(rawList[rawList.Count - 1]);
                                rawList.RemoveAt(rawList.Count - 1);    //BURADA KALDIN
                            }

                            else
                            {
                                rawList[rawList.Count -1].transform.SetParent(truckLeaveParent);

                                print(rawList.Count);

                                print(rawList);

                                for (int l = 0; l < 100; l++)
                                {
                                    Vector3 rawMove = rawList[rawList.Count - 1].transform.position;
                                    Vector3 exitPointMove = exitPoint1.transform.position;

                                    rawList[rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                    yield return new WaitForSeconds(0.00005f);
                                }

                                rawLeaveList.Add(rawList[rawList.Count - 1]);
                                rawList.RemoveAt(rawList.Count - 1);    //BURADA KALDIN
                            }

                            k -= 1;

                            print(exitPoint1.transform.position);

                        }
                    }
                    m += 1;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            StartCoroutine(TruckCome());
            //Burasý
        }
    }

    void Transform()
    {

    }

    IEnumerator RawCreate()
    {
        while (true)
        {
            while (truck.transform.position.z > 29)
            {
                float rawCount = rawList.Count;
                int rowCount1 = (int)rawCount / stackCount1;
                int rowCount2 = (int)rawCount / stackCount2;

                if (isWorking == true)
                {
                    GameObject temp = Instantiate(raw);

                    temp.transform.position = new Vector3(
                        exitPoint.position.x - (rawCount % (stackCount1) / 1.8f) - 0.25f,
                        exitPoint.position.y + (((float)rowCount2 % 4) / 2.5f),
                        exitPoint.position.z + (((float)rowCount1 % 4) / 2.25f));

                    // new Quaternion ***********************************

                    temp.transform.SetParent(parent);       // Kamyonun içine yüklemek için

                    rawList.Add(temp);      // Listeye ekleniyor

                    if (rawList.Count >= 20)
                    {
                        isWorking = false;
                    }
                }

                else if (rawList.Count < 20)
                {
                    isWorking = true;
                }
                yield return new WaitForSeconds(0.001f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }



    /*
    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }

        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceBetweenObjects1 : -distanceBetweenObjects1;
        desPos.z += pickedObject.transform.localScale.z;

        pickedObject.transform.localPosition = desPos;

        prevObject = pickedObject.transform;
    }

    // exitPoint.position.x - ((float)rowCount%3)
    // (rawCount%stackCount / 20)
    // exitPoint.position.z
    */

    /*
    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = Biker.position;
        transform.position = Vector3.Lerp(a, b, t);
    }
    */

    //public void RawCreate()
    //IEnumerator RawCreate()
    //yield return new WaitForSeconds(0.1f);

    /*
    IEnumerator RawCreate()
    {
        GameObject temp;
        int i = 0;
        int j = 0;
        int k = 0;

        while (true)
        {
            if (isWorking == true)
            {
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        for (k = 0; k < 5; k++)
                        {
                            temp = Instantiate(raw);

                            temp.transform.position = new Vector3(exitPoint.position.x - 0.25f - k / 1.75f, exitPoint.position.y + (i / 2.5f), exitPoint.position.z + ((float)j / 2));    // + rawCount / 10
                            rawList.Add(temp);
                        }
                    }
                }
                if (rawList.Count >=30)
                {
                    isWorking = false;
                }
            }

            else if (rawList.Count < 30)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    */

    /*
        for (int i = rawList.Count; i > 0; i--)
        {
            float rawCountMove = i;
            int rowCountMove1 = (int)rawCountMove / stackCount1;
            int rowCountMove2 = (int)rawCountMove / stackCount2;

            //Transform tr = Instantiate(exitPoint1);

            rawList[rawList.Count - 1 + k].transform.position = new Vector3(
                exitPoint1.position.x - (rawCountMove % (stackCount1) / 1.8f) - 0.25f,
                exitPoint1.position.y + (((float)rowCountMove2 % 4) / 2.5f),
                exitPoint1.position.z + (((float)rowCountMove1 % 4) / 2.25f));

            Vector3 rawMove = rawList[rawList.Count - 1 + k].transform.position;
            Vector3 exitPointMove = tr.transform.position;
            
            rawList[rawList.Count - 1 + k].transform.SetParent(truckLeaveParent);

            for (int l = 0; l < 300; l++)
            {
                rawList[rawList.Count - 1 + k].transform.position = Vector3.Lerp(rawMove, exitPointMove, t);
                yield return new WaitForSeconds(0.001f);
            }

            k -= 1;
            
            yield return new WaitForSeconds(0.2f);
        } 
    */

    /*
        for (int i = 0; i < rawCount; i++)
                {
                    float rawCount = rawList.Count;
                    int rowCount1 = (int)rawCount / stackCount1;
                    int rowCount2 = (int)rawCount / stackCount2;

                    GameObject temp = Instantiate(raw);

                    temp.transform.position = new Vector3(
                        exitPoint.position.x - (rawCount % (stackCount1) / 1.8f) - 0.25f,
                        exitPoint.position.y + (((float)rowCount2 % 4) / 2.5f),
                        exitPoint.position.z + (((float)rowCount1 % 4) / 2.25f));

                    temp.transform.SetParent(parent);       // Kamyonun içine yüklemek için

                    rawList.Add(temp);      // Listeye ekleniyor

                }
    */
}

