using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;

    public List<GameObject> rawList1 = new List<GameObject>();
    public List<Transform> prevObjectList = new List<Transform>();

    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject raw;
    [SerializeField] private GameObject Man;

    public bool work;

    private int rawLimit = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //distanceBetweenObjects = prevObject.localScale.y;
        StartCoroutine(RawTransform());
    }

    public void GetCalis()
    {
        
    }

    public void GetRaw()
    {
        if (rawList1.Count <= rawLimit - 1)
        {
            GameObject temp2 = Instantiate(raw);
            temp2.transform.position = new Vector3(prevObject.position.x, rawList1.Count / 10, prevObject.position.z);
            rawList1.Add(temp2);
            temp2.transform.SetParent(parent);
        }
    }

    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        print("PickUp Çalýþýyo");
        if (needTag)
        {
            pickedObject.tag = tag;
        }

        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceBetweenObjects : -distanceBetweenObjects;

        pickedObject.transform.localPosition = desPos;

        prevObject = pickedObject.transform;

    }

    public IEnumerator RawTransform()
    {
        int i = 0;
        while (true)
        {
            if (true)
            {
                yield return new WaitForSeconds(0.1f);

                if (RawMaterialCreate.rawInstance.rawList.Count < rawLimit)
                {
                    while (i < RawMaterialCreate.rawInstance.rawList.Count)   //20
                    {
                        int k = 0;

                        for (i = 0; i < RawMaterialCreate.rawInstance.rawList.Count; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            //Transform prevObject1 = Instantiate(prevObject);

                            Transform tr1 = RawMaterialCreate.rawInstance.exitPointList[RawMaterialCreate.rawInstance.exitPointList.Count - 1];

                            tr1.transform.position = new Vector3(
                                prevObject.position.x, // - 0.25f
                                prevObject.position.y + (prevObjectList.Count) / 3f,
                                prevObject.position.z);

                            tr1.transform.SetParent(parent);

                            prevObjectList.Add(tr1);

                            RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.SetParent(parent);

                            for (int l = 0; l < 100; l++)
                            {
                                Vector3 rawMove = RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.position;
                                Vector3 exitPointMove = tr1.transform.position;

                                RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                yield return new WaitForSeconds(0.00005f);
                            }

                            k -= 1;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (RawMaterialCreate.rawInstance.rawList.Count > rawLimit)
                {
                    while (i < rawLimit)   //20
                    {
                        int k = 0;

                        for (i = 0; i < RawMaterialCreate.rawInstance.rawList.Count; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            //Transform prevObject1 = Instantiate(prevObject);

                            Transform tr1 = RawMaterialCreate.rawInstance.exitPointList[RawMaterialCreate.rawInstance.exitPointList.Count - 1];

                            tr1.transform.position = new Vector3(
                                prevObject.position.x, // - 0.25f
                                prevObject.position.y + (prevObjectList.Count) / 3f,
                                prevObject.position.z);

                            tr1.transform.SetParent(parent);

                            prevObjectList.Add(tr1);

                            RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.SetParent(parent);

                            for (int l = 0; l < 100; l++)
                            {
                                Vector3 rawMove = RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.position;
                                Vector3 exitPointMove = tr1.transform.position;

                                RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                yield return new WaitForSeconds(0.00005f);
                            }

                            k -= 1;
                        }

                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    /*
    public IEnumerator RawTransformContainer()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (StackTrigger.instanceStackTrigger.inTriggerContainer == true && RawMaterialCreate.rawInstance.exitPointList.Count > 0)
            {
                yield return new WaitForSeconds(0.1f);

                if (RawMaterialCreate.rawInstance.rawList.Count < rawLimit)
                {
                    print("çalýþýyo1" + RawMaterialCreate.rawInstance.rawList.Count);
                    while (i < RawMaterialCreate.rawInstance.rawList.Count)   //20
                    {
                        print("çalýþýyo2");
                        int k = 0;

                        for (i = 0; i < RawMaterialCreate.rawInstance.rawList.Count; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            print("i =" + i);

                            //Transform prevObject1 = Instantiate(prevObject);

                            Transform tr1 = RawMaterialCreate.rawInstance.exitPointList[RawMaterialCreate.rawInstance.exitPointList.Count - 1];

                            tr1.transform.position = new Vector3(
                                prevObject.position.x, // - 0.25f
                                prevObject.position.y + (prevObjectList.Count) / 3f,
                                prevObject.position.z);

                            tr1.transform.SetParent(parent);

                            prevObjectList.Add(tr1);

                            RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.SetParent(parent);

                            for (int l = 0; l < 100; l++)
                            {
                                Vector3 rawMove = RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.position;
                                Vector3 exitPointMove = tr1.transform.position;

                                RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                yield return new WaitForSeconds(0.00005f);
                            }

                            k -= 1;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (RawMaterialCreate.rawInstance.rawList.Count > rawLimit)
                {
                    print("RawListCount: " + RawMaterialCreate.rawInstance.rawList.Count);
                    print("RawLimit" + rawLimit);

                    while (i < rawLimit)   //20
                    {
                        print("çalýþýyo4");
                        int k = 0;

                        for (i = 0; i < rawLimit; i++)     //int i = rawList.Count; i > 0; i--
                        {
                            print("i =" + i);

                            //Transform prevObject1 = Instantiate(prevObject);

                            Transform tr1 = RawMaterialCreate.rawInstance.exitPointList[RawMaterialCreate.rawInstance.exitPointList.Count - 1];

                            tr1.transform.position = new Vector3(
                                prevObject.position.x, // - 0.25f
                                prevObject.position.y + (prevObjectList.Count) / 3f,
                                prevObject.position.z);

                            tr1.transform.SetParent(parent);

                            prevObjectList.Add(tr1);

                            RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.SetParent(parent);

                            for (int l = 0; l < 100; l++)
                            {
                                Vector3 rawMove = RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.position;
                                Vector3 exitPointMove = tr1.transform.position;

                                RawMaterialCreate.rawInstance.rawList[RawMaterialCreate.rawInstance.rawList.Count - 1 + k].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);
                                yield return new WaitForSeconds(0.00005f);
                            }

                            k -= 1;
                        }

                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
        }
    }
    */

}
