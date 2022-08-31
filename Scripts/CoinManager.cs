using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager coinManager;

    public TextMeshProUGUI coinPrice;
    public TextMeshProUGUI coinPrice2;
    public TextMeshProUGUI totalCoinPrice;
    public TextMeshProUGUI coinbotPrice;
    public TextMeshProUGUI coinTruckPrice;
    public TextMeshProUGUI coinTruckPrice2;
    public TextMeshProUGUI coinUpdate;
    

    public List<GameObject> coinList = new List<GameObject>();
    public List<GameObject> playerCoinList = new List<GameObject>();
    public List<GameObject> rawPlayerList = new List<GameObject>();

    public GameObject coin;
    public GameObject g;

    public GameObject table;
    public GameObject table1;
    public GameObject table2;

    public GameObject update;

    public GameObject botCreate;

    public Transform tablePayPoint1;
    public Transform tablePayPoint2;
    public Transform tablePayPoint3;
    public Transform tablePayPoint4;

    public Transform playerPayPoint;

    public Transform tablePoint;
    public Transform playerPoint;

    public Transform botPayPoint;
    public Transform botPayPoint2;

    public Transform truckPayPoint;
    public Transform truckPayPoint2;

    public Transform rawDropPoint2;
    public Transform rawDropPoint3;

    public Transform rawPlayerParent;

    public Transform rabbish1;
    public Transform rabbish2;

    public GameObject TRUCK;
    public GameObject kamyon;
    public GameObject conveyor;
    public GameObject conveyor1;
    public GameObject conveyor2;
    public GameObject conveyorMain;

    public bool tableOn;
    public bool tableOn2;
    public bool botOn;
    public bool truckUpdateOn;
    public bool coinOn = false;

    int playerCoins = 0;
    public int totalCoin = 80;
    private int coinPayBotPrice = 20;
    public int coinTruckupdatePrice = 20;
    public int coinPiece = 10;
    int i = 0;
    int speed = 10;

    private void Awake()
    {
        if (coinManager == null)
        {
            coinManager = this;
        }
    }

    void Start()
    {
        coinTruckupdatePrice = 20;
        coinPiece = 10;

        StartCoroutine(CoinPay());
        StartCoroutine(CoinPrice());
        StartCoroutine(CoinBotPay());
        StartCoroutine(CoinBotPrice());
        StartCoroutine(CoinTruckPrice());
        StartCoroutine(CoinTruckPay());
        StartCoroutine(CoinCreater());
        StartCoroutine(Coin());
        StartCoroutine(CoinConveyorPay());
        StartCoroutine(CoinLevelPay());
        StartCoroutine(CoinUpdate());
        StartCoroutine(CoinTotal());
    }

    IEnumerator CoinPay()       
    {
        while (true)
        {
            if (table)
            {
                g = table.transform.GetChild(0).gameObject;
            }
            if (table && StackTrigger.instanceStackTrigger.tableMain && !g.transform.GetComponent<Tables>().tableOn)
            {
                GameObject coinClone = Instantiate(coin);
                coinClone.transform.position = new Vector3(
                    playerPayPoint.position.x,
                    playerPayPoint.position.y,
                    playerPayPoint.position.z);

                coinList.Add(coinClone);

                g = table.transform.GetChild(0).gameObject;
                GameObject cylender = g.transform.GetChild(1).gameObject;
                GameObject canvas = cylender.transform.GetChild(0).gameObject;
                GameObject coinPriceText = canvas.transform.GetChild(0).gameObject;
                coinPrice = coinPriceText.GetComponent<TextMeshProUGUI>();

                GameObject transformPoint = g.transform.GetChild(3).gameObject;
                GameObject transformPoint2 = g.transform.GetChild(2).gameObject;

                for (int j = 0; j < speed; j++)
                {
                    Vector3 coinMove = coinList[coinList.Count - 1].transform.position;
                    Vector3 tablePay = transformPoint.transform.position;

                    coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove, tablePay, 0.1f);
                    yield return new WaitForSeconds(0.0005f);
                }

                for (int k = 0; k < speed; k++)
                {
                    Vector3 coinMove1 = coinList[coinList.Count - 1].transform.position;
                    Vector3 tablePay1 = transformPoint2.transform.position;

                    coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove1, tablePay1, 0.1f);
                    yield return new WaitForSeconds(0.0005f);
                }

                speed -= 1;
                if (speed < 3)
                {
                    speed = 3;
                }

                Destroy(coinList[coinList.Count - 1]);
                coinList.RemoveAt(coinList.Count - 1);
                g.transform.GetComponent<Tables>().coinPayPrice -= 1;
                totalCoin -= 1;
            }
            while (StackTrigger.instanceStackTrigger.tableMain == true && g.transform.GetComponent<Tables>().coinPayPrice < 1 && !g.transform.GetComponent<Tables>().tableOn)
            {
                g.transform.GetComponent<Tables>().tableOn = true;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CoinBotPay()
    {
        while (true)
        {
            if (botCreate)
            {
                GameObject botCreate2 = botCreate.transform.GetChild(0).gameObject;
                GameObject botCreate3 = botCreate2.transform.GetChild(0).gameObject;
                botPayPoint = botCreate3.transform.GetChild(2);
                botPayPoint2 = botCreate3.transform.GetChild(1);

                if (StackTrigger.instanceStackTrigger.botCreate2 && botCreate3.GetComponent<BotCreate>().coinPayBotPrice > 0)
                {
                    GameObject coinClone = Instantiate(coin);
                    coinClone.transform.position = new Vector3(
                        playerPayPoint.position.x,
                        playerPayPoint.position.y,
                        playerPayPoint.position.z);

                    coinList.Add(coinClone);

                    for (int j = 0; j < speed; j++)
                    {
                        Vector3 coinMove = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay = botPayPoint.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove, tablePay, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    for (int k = 0; k < speed; k++)
                    {
                        Vector3 coinMove1 = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay1 = botPayPoint2.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove1, tablePay1, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    speed -= 1;
                    if (speed < 3)
                    {
                        speed = 3;
                    }

                    Destroy(coinList[coinList.Count - 1]);
                    coinList.RemoveAt(coinList.Count - 1);
                    botCreate3.GetComponent<BotCreate>().coinPayBotPrice -= 1;
                    totalCoin -= 1;

                }
                if (StackTrigger.instanceStackTrigger.botCreate2 && botCreate3.GetComponent<BotCreate>().coinPayBotPrice < 1)
                {
                    botOn = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CoinTruckPay()
    {
        while (true)
        {
            if (TRUCK)  
            {
                kamyon = TRUCK.transform.GetChild(0).gameObject;
                if (StackTrigger.instanceStackTrigger.truckUpdate2 && coinTruckupdatePrice > 0 && TRUCK)
                {
                    kamyon = TRUCK.transform.GetChild(0).gameObject;
                    GameObject truckUpdate = TRUCK.transform.GetChild(2).gameObject;
                    GameObject truckUpdate1 = truckUpdate.transform.GetChild(0).gameObject;
                    GameObject truckUpdate2 = truckUpdate1.transform.GetChild(0).gameObject;
                    GameObject truckPayPoint2 = truckUpdate2.transform.GetChild(1).gameObject;
                    GameObject truckPayPoint = truckUpdate2.transform.GetChild(2).gameObject;

                    GameObject coinClone = Instantiate(coin);
                    coinClone.transform.position = new Vector3(
                        playerPayPoint.position.x,
                        playerPayPoint.position.y,
                        playerPayPoint.position.z);

                    coinList.Add(coinClone);

                    for (int j = 0; j < speed; j++)
                    {
                        Vector3 coinMove = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay = truckPayPoint.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove, tablePay, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    for (int k = 0; k < speed; k++)
                    {
                        Vector3 coinMove1 = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay1 = truckPayPoint2.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove1, tablePay1, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    speed -= 1;
                    if (speed < 3)
                    {
                        speed = 3;
                    }

                    Destroy(coinList[coinList.Count - 1]);
                    coinList.RemoveAt(coinList.Count - 1);
                    coinTruckupdatePrice -= 1;
                    totalCoin -= 1;

                    if (StackTrigger.instanceStackTrigger.truckUpdate2 && coinTruckupdatePrice == 0)
                    {
                        truckUpdateOn = true;
                    }
                }
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator CoinConveyorPay()
    {
        while (true)
        {
            if (conveyor)
            {
                conveyor1 = conveyor.transform.GetChild(0).gameObject;
                conveyor2 = conveyor1.transform.GetChild(0).gameObject;

                conveyorMain = conveyor.transform.parent.gameObject;

                if (StackTrigger.instanceStackTrigger.conveyorUpdate2 && conveyor2.GetComponent<ConveyorUpdate>().conveyorUpdatePrice > 0)
                {
                    GameObject truckUpdate1 = conveyor.transform.GetChild(0).gameObject;
                    GameObject truckUpdate2 = truckUpdate1.transform.GetChild(0).gameObject;
                    GameObject truckPayPoint2 = truckUpdate2.transform.GetChild(1).gameObject;
                    GameObject truckPayPoint = truckUpdate2.transform.GetChild(2).gameObject;

                    GameObject coinClone = Instantiate(coin);
                    coinClone.transform.position = new Vector3(
                        playerPayPoint.position.x,
                        playerPayPoint.position.y,
                        playerPayPoint.position.z);

                    coinList.Add(coinClone);

                    for (int j = 0; j < speed; j++)
                    {
                        Vector3 coinMove = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay = truckPayPoint.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove, tablePay, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    for (int k = 0; k < speed; k++)
                    {
                        Vector3 coinMove1 = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay1 = truckPayPoint2.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove1, tablePay1, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    speed -= 1;
                    if (speed < 3)
                    {
                        speed = 3;
                    }

                    Destroy(coinList[coinList.Count - 1]);
                    coinList.RemoveAt(coinList.Count - 1);
                    conveyor2.GetComponent<ConveyorUpdate>().conveyorUpdatePrice -= 1;
                    totalCoin -= 1;

                    if (StackTrigger.instanceStackTrigger.conveyorUpdate2 && conveyor2.GetComponent<ConveyorUpdate>().conveyorUpdatePrice == 0)
                    {
                        ConveyorUpdate.conveyorUpdate.conveyorUpdateBool = true;
                    }
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CoinLevelPay()
    {
        while (true)
        {
            if (update)
            {
                if ((StackTrigger.instanceStackTrigger.levelUpdate11 || StackTrigger.instanceStackTrigger.levelUpdate22) && update.GetComponent<UpdatePrice>().levelUpdatePrice > 0)
                {
                    GameObject u1 = update.transform.GetChild(0).gameObject;
                    GameObject u2 = u1.transform.GetChild(0).gameObject;
                    Transform truckPayPoint1 = u2.transform.GetChild(2);
                    Transform truckPayPoint2 = u2.transform.GetChild(1);

                    GameObject coinClone = Instantiate(coin);
                    coinClone.transform.position = new Vector3(
                        playerPayPoint.position.x,
                        playerPayPoint.position.y,
                        playerPayPoint.position.z);

                    coinList.Add(coinClone);

                    for (int j = 0; j < speed; j++)
                    {
                        Vector3 coinMove = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay = truckPayPoint1.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove, tablePay, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    for (int k = 0; k < speed; k++)
                    {
                        Vector3 coinMove1 = coinList[coinList.Count - 1].transform.position;
                        Vector3 tablePay1 = truckPayPoint2.transform.position;

                        coinList[coinList.Count - 1].transform.position = Vector3.Lerp(coinMove1, tablePay1, 0.1f);
                        yield return new WaitForSeconds(0.0005f);
                    }

                    speed -= 1;
                    if (speed < 3)
                    {
                        speed = 3;
                    }

                    Destroy(coinList[coinList.Count - 1]);
                    coinList.RemoveAt(coinList.Count - 1);
                    update.GetComponent<UpdatePrice>().levelUpdatePrice -= 1;
                    totalCoin -= 1;

                    if (update.GetComponent<UpdatePrice>().levelUpdatePrice == 0)
                    {
                        LevelChangeUpdate.levelChangeUpdate.levelChange = true;
                    }
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CoinUpdate()
    {
        while (true)
        {
            if (update)
            {
                coinUpdate.text = update.GetComponent<UpdatePrice>().levelUpdatePrice.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinTotal()
    {
        while (true)
        {
            
            totalCoinPrice.text = totalCoin.ToString();
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinPrice()
    {
        while (true)
        {
            if (g)
            {
                coinPrice.text = g.transform.GetComponent<Tables>().coinPayPrice.ToString();
                totalCoinPrice.text = totalCoin.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinBotPrice()
    {
        while (true)
        {
            if (botCreate)
            {
                GameObject botCreate2 = botCreate.transform.GetChild(0).gameObject;
                GameObject botCreate3 = botCreate2.transform.GetChild(0).gameObject;
                GameObject canvas = botCreate3.transform.GetChild(0).gameObject;
                GameObject coinbotPrice2 = canvas.transform.GetChild(0).gameObject;
                coinbotPrice = coinbotPrice2.GetComponent<TextMeshProUGUI>();

                coinbotPrice.text = botCreate3.GetComponent<BotCreate>().coinPayBotPrice.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinTruckPrice()
    {
        while (true)
        {
            if (TRUCK)
            {
                GameObject truckUpdate = TRUCK.transform.GetChild(2).gameObject;
                GameObject truckUpdate1 = truckUpdate.transform.GetChild(0).gameObject;
                GameObject truckUpdate2 = truckUpdate1.transform.GetChild(0).gameObject;
                GameObject canvas = truckUpdate2.transform.GetChild(0).gameObject;
                GameObject coinTruckPrice2 = canvas.transform.GetChild(0).gameObject;
                coinTruckPrice = coinTruckPrice2.GetComponent<TextMeshProUGUI>();

                coinTruckPrice.text = coinTruckupdatePrice.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    

    IEnumerator Coin()
    {
        while (true)
        {
            if (StackTrigger.instanceStackTrigger.table == true && coinList.Count > 0 && OrderManager.orderManager.foodFinished)
            {
                for (int l = 0; l < 10; l++)
                {
                    Vector3 rawMove = coinList[coinList.Count - 1].transform.position;
                    Vector3 exitPointMove = playerPoint.transform.position;

                    coinList[coinList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.1f);

                    yield return new WaitForSeconds(0.0001f);
                }
                if (coinList.Count == 1)
                {
                    table1.GetComponent<CustomerWalkManager>().orderOn = false;
                }
                Destroy(coinList[coinList.Count - 1]);
                coinList.RemoveAt(coinList.Count - 1);

                totalCoin += 1;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }



    IEnumerator CoinCreater()
    {
        while (true)
        {
            while ( OrderManager.orderManager.foodFinished && coinList.Count < coinPiece && coinOn)
            {
                for (int i = 0; i < coinPiece; i++)
                {
                    GameObject coins = Instantiate(coin);
                    coins.transform.position = new Vector3(
                            tablePoint.position.x,
                            tablePoint.position.y + coinList.Count / 5f,
                            tablePoint.position.z);
                    coinList.Add(coins);
                }
                coinOn = false;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinCreaterGecici()
    {
        while (true)
        {
            if (playerCoinList.Count < coinPiece)
            {
                for (int i = 0; i < coinPiece; i++)
                {
                    GameObject coins = Instantiate(coin);
                    coins.transform.position = new Vector3(
                            rawDropPoint2.position.x,
                            rawDropPoint2.position.y + playerCoinList.Count / 5f,
                            rawDropPoint2.position.z);
                    playerCoinList.Add(coins);

                    coins.transform.SetParent(rawPlayerParent);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CoinTable()
    {
        while (true)
        {
            while (StackTrigger.instanceStackTrigger.tableCreate == true && playerCoins > 0)
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
            yield return new WaitForSeconds(1f);
        }
    }
}
