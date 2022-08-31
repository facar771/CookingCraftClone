using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckUpdate : MonoBehaviour
{
    public static TruckUpdate truckUpdate;

    public GameObject TruckUpdateZone;
    public GameObject truck;

    Animator animator;

    int playerTable;
    int playerTable2;
    int cylenderClose;
    public float truckX;

    public bool truckUpdateActive = false;

    private void Awake()
    {
        if (truckUpdate == null)
        {
            truckUpdate = this;
        }
    }
    void Start()
    {
        animator = TruckUpdateZone.GetComponent<Animator>();

        playerTable = Animator.StringToHash("playerTable");
        playerTable2 = Animator.StringToHash("playerTable2");
        cylenderClose = Animator.StringToHash("cylenderClose");

        StartCoroutine(TruckUpdateManager());
        StartCoroutine(TruckLevelUpdate());
    }
    IEnumerator TruckUpdateManager()
    {
        while (true)
        {
            if (StackTrigger.instanceStackTrigger.truckUpdate == true)
            {
                animator.SetBool(playerTable, true);
            }

            if (StackTrigger.instanceStackTrigger.truckUpdate == false)
            {
                animator.SetBool(playerTable, false);
            }

            if (StackTrigger.instanceStackTrigger.truckUpdate2 == true)
            {
                animator.SetBool(playerTable2, true);

                if (CoinManager.coinManager.truckUpdateOn)
                {
                    truckUpdateActive = true;
                }
            }

            if (StackTrigger.instanceStackTrigger.truckUpdate2 == false)
            {
                animator.SetBool(playerTable2, false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator TruckLevelUpdate()
    {
        while (true)
        {
            print(truckUpdateActive);
            if (truckUpdateActive && truck.tag == "TruckLvl1")
            {
                truck.tag = "TruckLvl2";
                Vector3 position = new Vector3(truckX, 0f, 30);
                truck.transform.position = position;

                RawMaterialManager.rawMaterialManager.rawPiece = 10;
                RawMaterialManager.rawMaterialManager.rawLeavePiece = 12;

                yield return new WaitForSeconds(2f);
                truckUpdateActive = false;
                CoinManager.coinManager.truckUpdateOn = false;
                CoinManager.coinManager.coinTruckupdatePrice = 40;
            }

            if (truckUpdateActive && truck.tag == "TruckLvl2")
            {
                truck.tag = "TruckLvl3";
                Vector3 position = new Vector3(truckX, 0f, 30);
                truck.transform.position = position;

                RawMaterialManager.rawMaterialManager.rawPiece = 15;
                RawMaterialManager.rawMaterialManager.rawLeavePiece = 20;

                yield return new WaitForSeconds(2f);
                truckUpdateActive = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
