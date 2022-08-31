using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConveyorUpdate : MonoBehaviour
{
    public static ConveyorUpdate conveyorUpdate;

    public GameObject conveyor;
    public GameObject conveyorHamburger;
    public GameObject conveyorHotDog;
    public GameObject conveyor1;
    public GameObject conveyor2;
    public GameObject conveyorMain;

    public TextMeshProUGUI coinConveyorPrice;

    Animator animator;

    int playerTable;
    int playerTable2;
    int cylenderClose;
    public int conveyorUpdatePrice = 20;
    public bool conveyorUpdateBool = false;


    private void Awake()
    {
        if (conveyorUpdate == null)
        {
            conveyorUpdate = this;
        }
    }
    void Start()
    {
        playerTable = Animator.StringToHash("playerTable");
        playerTable2 = Animator.StringToHash("playerTable2");
        cylenderClose = Animator.StringToHash("cylenderClose");

        StartCoroutine(ConveyorUpdateManager());
        StartCoroutine(TruckLevelUpdate());
        StartCoroutine(CoinConveyorPrice());
    }
    IEnumerator ConveyorUpdateManager()
    {
        while (true)
        {
            if (CoinManager.coinManager.conveyor2)
            {
                animator = CoinManager.coinManager.conveyor2.GetComponent<Animator>();

                if (StackTrigger.instanceStackTrigger.conveyorUpdate == true)
                {
                    animator.SetBool(playerTable, true);
                }

                if (StackTrigger.instanceStackTrigger.conveyorUpdate == false)
                {
                    animator.SetBool(playerTable, false);
                }

                if (StackTrigger.instanceStackTrigger.conveyorUpdate2 == true)
                {
                    animator.SetBool(playerTable2, true);
                }

                if (StackTrigger.instanceStackTrigger.conveyorUpdate2 == false)
                {
                    animator.SetBool(playerTable2, false);
                }
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator TruckLevelUpdate()
    {
        while (true)
        {
            if (CoinManager.coinManager.conveyor)
            {
                GameObject Conveyor = CoinManager.coinManager.conveyor.transform.parent.gameObject;
                GameObject conveyor5 = Conveyor.transform.GetChild(4).gameObject;

                if (conveyorUpdateBool && conveyor5.tag == "ConveyorLvl1")
                {
                    conveyor5.tag = "ConveyorLvl2";

                    Conveyor.GetComponent<Ovens>().moveSpeed = 0.7f;
                    Conveyor.GetComponent<Ovens>().rawDropOffPiece = 6;
                    
                    yield return new WaitForSeconds(2f);
                    conveyorUpdateBool = false;

                    conveyor2.GetComponent<ConveyorUpdate>().conveyorUpdatePrice = 40;
                }
                if (conveyorUpdateBool && conveyor5.tag == "ConveyorLvl2")
                {
                    conveyor5.tag = "ConveyorLvl3";

                    Conveyor.GetComponent<Ovens>().moveSpeed = 1f;
                    Conveyor.GetComponent<Ovens>().rawDropOffPiece = 8;

                    yield return new WaitForSeconds(2f);
                    conveyorUpdateBool = false;

                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator CoinConveyorPrice()
    {
        while (true)
        {
            if (CoinManager.coinManager.conveyor)
            {
                conveyor1 = CoinManager.coinManager.conveyor.transform.GetChild(0).gameObject;
                conveyor2 = conveyor1.transform.GetChild(0).gameObject;

                conveyorMain = CoinManager.coinManager.conveyor.transform.parent.gameObject;

                GameObject canvas = conveyor2.transform.GetChild(0).gameObject;
                GameObject conveyorPrice = canvas.transform.GetChild(0).gameObject;
                coinConveyorPrice = conveyorPrice.GetComponent<TextMeshProUGUI>();

                coinConveyorPrice.text = conveyor2.GetComponent<ConveyorUpdate>().conveyorUpdatePrice.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
