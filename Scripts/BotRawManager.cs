using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRawManager : MonoBehaviour
{
    public static BotRawManager botRawManager;
    public List<GameObject> botRawTakeList = new List<GameObject>();
    int rawTakePiece = 5;
    public Transform botStackPoint;
    public Transform botStackPoint2;
    public Transform botParent;
    private void Awake()
    {
        if (botRawManager == null)
        {
            botRawManager = this;
        }
    }
    void Start()
    {
        StartCoroutine(BotRawTake());
        //StartCoroutine(RawOvenTransform());
    }
    IEnumerator BotRawTake()
    {
        while (true)
        {
            if (rawTakePiece > botRawTakeList.Count && BotTriggerManager.botTriggerManager.botRawTake && RawMaterialManager.rawMaterialManager.rawDropOffList.Count > 0)
            {
                botStackPoint.transform.position = new Vector3(
                    botStackPoint2.position.x,
                    botStackPoint2.position.y + botRawTakeList.Count / 3f,
                    botStackPoint2.position.z);

                RawMaterialManager.rawMaterialManager.rawDropOffList[RawMaterialManager.rawMaterialManager.rawDropOffList.Count - 1].transform.position = botStackPoint.transform.position;
                RawMaterialManager.rawMaterialManager.rawDropOffList[RawMaterialManager.rawMaterialManager.rawDropOffList.Count - 1].transform.SetParent(botParent);
                botRawTakeList.Add(RawMaterialManager.rawMaterialManager.rawDropOffList[RawMaterialManager.rawMaterialManager.rawDropOffList.Count - 1]);
                RawMaterialManager.rawMaterialManager.rawDropOffList.RemoveAt(RawMaterialManager.rawMaterialManager.rawDropOffList.Count - 1);

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator RawOvenTransform()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);    
            while (botRawTakeList.Count > 0) 
            {
                if (RawMaterialManager.rawMaterialManager.rawOvenPiece > RawMaterialManager.rawMaterialManager.hotDogOvenList.Count && BotTriggerManager.botTriggerManager.botHotDogLeave == true && botRawTakeList[botRawTakeList.Count - 1].tag == "Raw")
                {
                    if (RawMaterialManager.rawMaterialManager.hamburgerOvenInList.Count == 0)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }

                    float rawCountMove = Ovens.ovens.hotDogOvenList.Count;
                    int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                    int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                    RawMaterialManager.rawMaterialManager.rawDropPoint8.transform.position = new Vector3(
                        RawMaterialManager.rawMaterialManager.rawDropPoint7.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f), // - 0.25f
                        RawMaterialManager.rawMaterialManager.rawDropPoint7.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                        RawMaterialManager.rawMaterialManager.rawDropPoint7.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = botRawTakeList[botRawTakeList.Count - 1].transform.position;
                        Vector3 exitPointMove = RawMaterialManager.rawMaterialManager.rawDropPoint8.transform.position;

                        botRawTakeList[botRawTakeList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        botRawTakeList[botRawTakeList.Count - 1].transform.rotation = RawMaterialManager.rawMaterialManager.rawDropPoint8.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    botRawTakeList[botRawTakeList.Count - 1].transform.SetParent(Ovens.ovens.ovenParent);

                    Ovens.ovens.hotDogOvenList.Add(botRawTakeList[botRawTakeList.Count - 1]);   //rawDropOffList rawTruckList
                    
                    botRawTakeList.RemoveAt(botRawTakeList.Count - 1);

                    yield return new WaitForSeconds(0.1f);
                }
                if (RawMaterialManager.rawMaterialManager.rawOvenPiece > Ovens.ovens.hamburgerOvenList.Count && BotTriggerManager.botTriggerManager.botHamburgerLeave == true && botRawTakeList.Count > 0 && botRawTakeList[botRawTakeList.Count - 1].tag == "Raw")
                {
                    if (RawMaterialManager.rawMaterialManager.hotDogOvenInList.Count == 0)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }

                    float rawCountMove = Ovens.ovens.hamburgerOvenList.Count;
                    int rowCountMove1 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount3;
                    int rowCountMove2 = (int)rawCountMove / RawMaterialManager.rawMaterialManager.stackCount4;

                    RawMaterialManager.rawMaterialManager.rawDropPoint5.transform.position = new Vector3(
                        RawMaterialManager.rawMaterialManager.rawDropPoint4.position.x + (rawCountMove % (RawMaterialManager.rawMaterialManager.stackCount3) / 1.8f), // - 0.25f
                        RawMaterialManager.rawMaterialManager.rawDropPoint4.position.y + (((float)rowCountMove2 % 2) / 2.5f),
                        RawMaterialManager.rawMaterialManager.rawDropPoint4.position.z - (((float)rowCountMove1 % 2) / 2.25f));

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = botRawTakeList[botRawTakeList.Count - 1].transform.position;
                        Vector3 exitPointMove = RawMaterialManager.rawMaterialManager.rawDropPoint5.transform.position;

                        botRawTakeList[botRawTakeList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        botRawTakeList[botRawTakeList.Count - 1].transform.rotation = RawMaterialManager.rawMaterialManager.rawDropPoint5.transform.rotation;

                        yield return new WaitForSeconds(0.00005f);
                    }

                    botRawTakeList[botRawTakeList.Count - 1].transform.SetParent(Ovens.ovens.ovenParent);

                    Ovens.ovens.hamburgerOvenList.Add(botRawTakeList[botRawTakeList.Count - 1]);   //rawDropOffList rawTruckList
                    
                    botRawTakeList.RemoveAt(botRawTakeList.Count - 1);

                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
