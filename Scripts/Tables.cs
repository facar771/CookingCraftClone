using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Tables : MonoBehaviour
{
    public static Tables tables;

    List<GameObject> CustomerFullList = new List<GameObject>();

    public List<GameObject> tableHamburgerList = new List<GameObject>();
    public List<GameObject> tableHotDogList = new List<GameObject>();
    public List<GameObject> foodEatingList = new List<GameObject>();
    public List<GameObject> coinList = new List<GameObject>();

    public GameObject exit;
    public GameObject coin;

    GameObject masa;
    GameObject canvas;
    GameObject canvasHamburger;
    GameObject canvasHotDog;
    GameObject canvasHamburgerImg;
    GameObject canvasHotDogImg;
    TextMeshProUGUI hamburgerText;
    TextMeshProUGUI hotDogText;

    public Transform playerPoint;

    public bool tableOn = false;
    public bool orderOn = false;
    public bool foodFinished = false;
    public bool putFood = false;
    public bool customerHere = false;
    public bool customerExit = false;
    public bool coinOn = false;

    public int totalOrder = 0;
    public int hamburgerPrice = 0;
    public int hotDogPrice = 0;
    public int coinPayPrice = 30;
    public int coinPiece = 10;

    private void Awake()
    {
        if (tables == null)
        {
            tables = this;
        }
    }
    void Start()
    {
        StartCoroutine(CustomerOrder());
        StartCoroutine(CustomerWalk());
        StartCoroutine(FullCustomerManager());
        StartCoroutine(FoodEat());
        StartCoroutine(Coin());
        StartCoroutine(CoinCreater());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TableCreate.tableCreate.Table = this.gameObject;
            //OrderManager.orderManager.table = this.gameObject;
            putFood = true;
        }
        if (other.tag == "Customer")
        {
            customerHere = true;
        }
        if (other.tag == "Waiter")
        {
            putFood = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            putFood = false;
        }
        if (other.tag == "CustomerFull")
        {
            customerHere = false;
        }
        if (other.tag == "Waiter")
        {
            putFood = false;
        }
    }

    IEnumerator CustomerWalk()
    {
        while (true)
        {
            int isWalking = Animator.StringToHash("IsWalking");
            GameObject masa = this.gameObject.transform.GetChild(0).gameObject;
            GameObject point = masa.transform.GetChild(7).gameObject;

            while (RandomPlayer.randomPlayer.customerList.Count > 0 && tableOn && !orderOn)
            {
                GameObject customer = RandomPlayer.randomPlayer.customerList[0];
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                Animator animator = customer.GetComponent<Animator>();
                if (!point.GetComponent<TableTriggerManager>().orderOn && customer.tag == "Customer")
                {
                    animator.SetBool(isWalking, true);
                    agent.SetDestination(point.transform.position);
                }
                if (point.GetComponent<TableTriggerManager>().orderOn && !foodFinished)
                {
                    animator.SetBool(isWalking, false);
                    agent.isStopped = true;

                    customerExit = false;

                    Vector3 direction = masa.transform.position - customer.transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    customer.transform.rotation = Quaternion.Lerp(customer.transform.rotation, rotation, 5f);

                    CustomerFullList.Add(RandomPlayer.randomPlayer.customerList[0]);
                    RandomPlayer.randomPlayer.customerList.RemoveAt(0);

                    orderOn = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FullCustomerManager()
    {
        while (true)
        {
            int isWalking = Animator.StringToHash("IsWalking");
            GameObject masa = this.gameObject.transform.GetChild(0).gameObject;
            GameObject point = masa.transform.GetChild(7).gameObject;

            if (orderOn && CustomerFullList.Count > 0)
            {
                GameObject customer = CustomerFullList[CustomerFullList.Count - 1];
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                Animator animator = customer.GetComponent<Animator>();

                if (customerExit && customer.tag == "Customer")
                {
                    coinOn = true;

                    if (!exit.GetComponent<TableTriggerManager>().exit)
                    {
                        print("Çalýþmýyormu");
                        yield return new WaitForSeconds(0.5f);
                        coinOn = false;
                        customer.tag = "CustomerFull";
                        animator.SetBool(isWalking, true);
                        agent.isStopped = false;
                        agent.SetDestination(exit.transform.position);
                    }
                }
            }

            if (exit.GetComponent<TableTriggerManager>().exit && CustomerFullList.Count > 0)
            {
                GameObject customer = CustomerFullList[0];
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                Animator animator = customer.GetComponent<Animator>();

                if (customer.tag == "CustomerFull" && exit.GetComponent<TableTriggerManager>().exit)
                {
                    customerExit = false;
                    Destroy(CustomerFullList[0]);
                    CustomerFullList.RemoveAt(0);
                    CoinManager.coinManager.coinOn = true;
                    exit.GetComponent<TableTriggerManager>().exit = false;
                }
            }
            if (exit.GetComponent<TableTriggerManager>().exit && CustomerFullList.Count > 1)
            {
                GameObject customer = CustomerFullList[1];
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                Animator animator = customer.GetComponent<Animator>();

                if (customer.tag == "CustomerFull" && exit.GetComponent<TableTriggerManager>().exit)
                {
                    customerExit = false;
                    Destroy(CustomerFullList[1]);
                    CustomerFullList.RemoveAt(1);
                    CoinManager.coinManager.coinOn = true;
                    print("Ne kadar Çalýþýyo");
                    exit.GetComponent<TableTriggerManager>().exit = false;
                }
            }
            if (exit.GetComponent<TableTriggerManager>().exit && CustomerFullList.Count > 2)
            {
                GameObject customer = CustomerFullList[2];
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                Animator animator = customer.GetComponent<Animator>();

                if (customer.tag == "CustomerFull" && exit.GetComponent<TableTriggerManager>().exit)
                {
                    customerExit = false;
                    Destroy(CustomerFullList[2]);
                    CustomerFullList.RemoveAt(2);
                    CoinManager.coinManager.coinOn = true;
                    print("Ne kadar Çalýþýyo");
                    exit.GetComponent<TableTriggerManager>().exit = false;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator CustomerOrder()
    {
        while (true)
        {
            if (LevelManager.levelManager.level1)
            {
                masa = this.gameObject.transform.GetChild(0).gameObject;
                canvas = masa.transform.GetChild(0).gameObject;

                canvasHamburger = canvas.transform.GetChild(2).gameObject;
                canvasHotDog = canvas.transform.GetChild(3).gameObject;

                canvasHamburgerImg = canvas.transform.GetChild(0).gameObject;
                canvasHotDogImg = canvas.transform.GetChild(1).gameObject;

                hamburgerText = canvasHamburger.GetComponent<TextMeshProUGUI>();
                hotDogText = canvasHotDog.GetComponent<TextMeshProUGUI>();
            }
            if (LevelManager.levelManager.level2)
            {
                masa = this.gameObject.transform.GetChild(0).gameObject;
                canvas = masa.transform.GetChild(0).gameObject;

                canvasHamburger = canvas.transform.GetChild(2).gameObject;
                canvasHotDog = canvas.transform.GetChild(3).gameObject;

                canvasHamburgerImg = canvas.transform.GetChild(0).gameObject;
                canvasHotDogImg = canvas.transform.GetChild(1).gameObject;

                hamburgerText = canvasHamburger.GetComponent<TextMeshProUGUI>();
                hotDogText = canvasHotDog.GetComponent<TextMeshProUGUI>();
            }

            if (totalOrder == 0 && this.tableOn)
            {
                hamburgerPrice = Random.Range(1, 3);
                hotDogPrice = Random.Range(1, 3);
                if (GAMEmanager.gAMEmanager.game1)
                {
                    hotDogPrice = 0;
                    canvasHotDogImg.SetActive(false);
                    canvasHotDog.SetActive(false);
                }
                totalOrder = hamburgerPrice + hotDogPrice;
            }

            while (orderOn && customerHere)
            {
                canvas.SetActive(true);

                totalOrder = hamburgerPrice + hotDogPrice;

                hamburgerText.text = hamburgerPrice.ToString();
                hotDogText.text = hotDogPrice.ToString();

                yield return new WaitForSeconds(0.1f);

                if (hamburgerPrice == 0)
                {
                    canvasHamburgerImg.SetActive(false);
                    canvasHamburger.SetActive(false);
                }

                if (hotDogPrice == 0)
                {
                    canvasHotDogImg.SetActive(false);
                    canvasHotDog.SetActive(false);
                }

                if (hamburgerPrice == 0 && hotDogPrice == 0 && RandomPlayer.randomPlayer.customerList.Count > 0)
                {
                    foodFinished = true;
                }

            }
            yield return new WaitForSeconds(0.1f);

            if (!orderOn && foodFinished)
            {
                foodFinished = false;

                canvas.SetActive(false);
                print("ÇALIÞIYOMUUU");
                canvasHamburgerImg.SetActive(true);
                canvasHamburger.SetActive(true);

                canvasHotDogImg.SetActive(true);
                canvasHotDog.SetActive(true);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator FoodEat()
    {
        while (true)
        {
            if (CustomerFullList.Count > 0)
            {
                yield return new WaitForSeconds(0.15f);

                int isWalking = Animator.StringToHash("IsWalking");
                GameObject customer = CustomerFullList[0];
                //Animator animator = customer.GetComponent<Animator>();

                if (tableHamburgerList.Count > 0 && foodEatingList.Count == 0)
                {
                    GameObject masa = this.gameObject.transform.GetChild(0).gameObject;
                    GameObject TableExitPoint5 = masa.transform.GetChild(6).gameObject;


                    yield return new WaitForSeconds(0.1f);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = tableHamburgerList[tableHamburgerList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint5.transform.position;

                        tableHamburgerList[tableHamburgerList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    foodEatingList.Add(tableHamburgerList[tableHamburgerList.Count - 1]);
                    //animator.SetBool(isWalking, true);
                    yield return new WaitForSeconds(2f);

                    Destroy(tableHamburgerList[tableHamburgerList.Count - 1]);
                    tableHamburgerList.RemoveAt(tableHamburgerList.Count - 1);
                    foodEatingList.RemoveAt(foodEatingList.Count - 1);
                }

                //animator.SetBool(isWalking, false);
                yield return new WaitForSeconds(0.15f);

                if (tableHotDogList.Count > 0 && foodEatingList.Count == 0)
                {
                    GameObject masa = this.gameObject.transform.GetChild(0).gameObject;
                    GameObject TableExitPoint5 = masa.transform.GetChild(6).gameObject;

                    yield return new WaitForSeconds(0.1f);

                    for (int l = 0; l < 20; l++)
                    {
                        Vector3 rawMove = tableHotDogList[tableHotDogList.Count - 1].transform.position;
                        Vector3 exitPointMove = TableExitPoint5.transform.position;

                        tableHotDogList[tableHotDogList.Count - 1].transform.position = Vector3.Lerp(rawMove, exitPointMove, 0.2f);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    foodEatingList.Add(tableHotDogList[tableHotDogList.Count - 1]);
                    //animator.SetBool(isWalking, true);
                    yield return new WaitForSeconds(2f);

                    Destroy(tableHotDogList[tableHotDogList.Count - 1]);
                    tableHotDogList.RemoveAt(tableHotDogList.Count - 1);
                    foodEatingList.RemoveAt(foodEatingList.Count - 1);
                }
                if (foodFinished && tableHamburgerList.Count == 0 && tableHotDogList.Count == 0 && orderOn)
                {
                    customerExit = true;
                }
                yield return new WaitForSeconds(0.1f);  
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoinCreater()
    {
        while (true)
        {
            while (foodFinished && coinList.Count < coinPiece && coinOn)
            {
                GameObject masa = this.gameObject.transform.GetChild(0).gameObject;
                Transform tablePoint = masa.transform.GetChild(11).transform;

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
    IEnumerator Coin()
    {
        while (true)
        {
            if (putFood && coinList.Count > 0 && foodFinished)
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
                    orderOn = false;
                }
                Destroy(coinList[coinList.Count - 1]);
                coinList.RemoveAt(coinList.Count - 1);

                CoinManager.coinManager.totalCoin += 1;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
