using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaiterWalkManager : MonoBehaviour
{
    public static WaiterWalkManager waiterWalkManager;

    public List<GameObject> orderOnTables = new List<GameObject>();

    Animator animator;

    NavMeshAgent agent;

    public GameObject waiterHamburgerOven;
    public GameObject waiterHotDogOven;

    public GameObject hamburgerOven;
    public GameObject hotDogOven;

    public GameObject TABLES;

    GameObject coinTableMain;
    GameObject coinTable;

    Transform waiterPoint;

    int isWalking;
    int waiterCapacity = 2;

    bool hamburger = false;

    private void Awake()
    {
        if (waiterWalkManager == null)
        {
            waiterWalkManager = this;
        }
    }
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        isWalking = Animator.StringToHash("IsWalking");
        //StartCoroutine(WaiterWalk());
        StartCoroutine(TableListManager());
        StartCoroutine(WalkManager2());
    }
    IEnumerator WaiterWalk()
    {
        while (true)
        {
            if (hamburgerOven && hotDogOven) // Waiter ACTÝVE ??
            {
                GameObject ovenLeave = hamburgerOven.transform.GetChild(5).gameObject;
                waiterHamburgerOven = ovenLeave.transform.GetChild(1).gameObject;

                GameObject ovenLeave2 = hotDogOven.transform.GetChild(5).gameObject;
                waiterHotDogOven = ovenLeave2.transform.GetChild(1).gameObject;

                if (WaiterTrigger.waiterTrigger.waiterZone)
                {
                    animator.SetBool(isWalking, true);
                    agent.SetDestination(waiterHotDogOven.transform.position);
                    yield return new WaitForSeconds(0.2f);
                }
                if (orderOnTables.Count == 0 && WaiterRawManager.waiterRawManager.rawWaiterList.Count > 0)
                {
                    agent.isStopped = true;
                    animator.SetBool(isWalking, false);
                    yield return new WaitForSeconds(0.2f);
                }
                if (WaiterTrigger.waiterTrigger.waiterHamburgerTake || WaiterTrigger.waiterTrigger.waiterHotDogTake &&
                    WaiterRawManager.waiterRawManager.rawWaiterList.Count < 1)
                {
                    animator.SetBool(isWalking, false);
                    agent.isStopped = true;

                    yield return new WaitForSeconds(0.5f);
                    
                    //if (orderOnTables.Count > 0 && !coinTable.GetComponent<Tables>().customerHere)
                    //{
                    //    print("ÇALIÞMMAMASI LAZIM ");
                    //    orderOnTables.RemoveAt(0);
                    //}
                }
                if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 1 && !WaiterTrigger.waiterTrigger.waiterTablePut) // && !MASA TRÝGGER KODU EKLENCEK
                {
                    if (orderOnTables.Count == 0)
                    {
                        int tablePiece = TABLES.transform.childCount;
                        for (int i = 0; i < tablePiece; i++)
                        {
                            coinTableMain = TABLES.transform.GetChild(i).gameObject;
                            coinTable = coinTableMain.transform.GetChild(0).gameObject;
                            if (coinTable.GetComponent<Tables>().tableOn)
                            {
                                orderOnTables.Add(coinTable);
                                print("Kaç kere");
                            }
                        }
                    }

                    if (orderOnTables.Count != 0)
                    {
                        waiterPoint = orderOnTables[0].transform.GetChild(4);

                        animator.SetBool(isWalking, true);
                        agent.isStopped = false;
                        agent.SetDestination(waiterPoint.transform.position);
                    }
                    yield return new WaitForSeconds(0.2f);
                }
                if (WaiterTrigger.waiterTrigger.waiterTablePut)
                {
                    animator.SetBool(isWalking, false);
                    agent.isStopped = true;

                    while (orderOnTables[0].GetComponent<Tables>().customerHere)
                    {
                        yield return new WaitForSeconds(1f);

                        if (WaiterRawManager.waiterRawManager.rawWaiterList.Count == 0 ||
                            orderOnTables[0].GetComponent<Tables>().hamburgerPrice == 0 ||
                            orderOnTables[0].GetComponent<Tables>().hotDogPrice == 0 ||
                            (orderOnTables[0].GetComponent<Tables>().hotDogPrice != 0 &&
                            WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "Hamburger") ||
                            (orderOnTables[0].GetComponent<Tables>().hamburgerPrice != 0 &&
                            WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "HotDog"))
                        {
                            agent.isStopped = false;
                            if ((orderOnTables[0].GetComponent<Tables>().hamburgerPrice != 0 &&
                            WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "HotDog"))
                            {
                                print("hambuger2 a gitti");
                                animator.SetBool(isWalking, true);
                                agent.SetDestination(waiterHamburgerOven.transform.position);
                                hamburger = true;
                            }
                            yield return new WaitForSeconds(1.5f);
                            if ((orderOnTables[0].GetComponent<Tables>().hotDogPrice != 0 &&
                            WaiterRawManager.waiterRawManager.rawWaiterList[WaiterRawManager.waiterRawManager.rawWaiterList.Count - 1].tag == "Hamburger"))
                            {
                                print("hotDog2 a gitti");
                                animator.SetBool(isWalking, true);
                                agent.SetDestination(waiterHotDogOven.transform.position);
                                hamburger = false;
                            }
                            yield return new WaitForSeconds(2f);
                        }
                    }

                    while (!orderOnTables[0].GetComponent<Tables>().customerHere)
                    {
                        print("Burasýda Çlaýþýyo");
                        agent.isStopped = false;
                        if (!hamburger)
                        {
                            animator.SetBool(isWalking, true);
                            agent.SetDestination(waiterHamburgerOven.transform.position);
                            hamburger = true;
                        }
                        yield return new WaitForSeconds(0.2f);
                        if (hamburger)
                        {
                            animator.SetBool(isWalking, true);
                            agent.SetDestination(waiterHotDogOven.transform.position);
                            hamburger = false;
                            orderOnTables.RemoveAt(0);
                        }
                        yield return new WaitForSeconds(0.2f);
                    }
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator WalkManager2()
    {
        while (true)
        {
            if (CoinManager.coinManager.botCreate)
            {
                GameObject g1 = CoinManager.coinManager.botCreate.transform.GetChild(0).gameObject;
                GameObject g2 = g1.transform.GetChild(0).gameObject;

                if (g2.GetComponent<BotCreate>().waiterActive)
                {
                    if (hamburgerOven && hotDogOven)
                    {
                        GameObject ovenLeave = hamburgerOven.transform.GetChild(5).gameObject;
                        waiterHamburgerOven = ovenLeave.transform.GetChild(1).gameObject;

                        GameObject ovenLeave2 = hotDogOven.transform.GetChild(5).gameObject;
                        waiterHotDogOven = ovenLeave2.transform.GetChild(1).gameObject;

                        if (WaiterTrigger.waiterTrigger.waiterZone) // ÝLK BAÞLANGIÇ
                        {
                            print("Bura ÇALIÞITO");
                            animator.SetBool(isWalking, true);
                            agent.isStopped = false;
                            agent.SetDestination(waiterHotDogOven.transform.position);
                        }

                        if (WaiterRawManager.waiterRawManager.rawWaiterList.Count > 0 && orderOnTables.Count > 0 && (WaiterTrigger.waiterTrigger.waiterHamburgerTake || WaiterTrigger.waiterTrigger.waiterHotDogTake))
                        {
                            // ELÝMÝZ DOLU MASAYA GÝDÝYORUZ

                            yield return new WaitForSeconds(0.5f);
                            int random = Random.Range(0, orderOnTables.Count);

                            agent.isStopped = false;
                            agent.SetDestination(orderOnTables[random].transform.position);
                            animator.SetBool(isWalking, true);

                            print("normalde çalýþýyo");
                        }

                        if (WaiterTrigger.waiterTrigger.waiterTablePut)
                        {
                            // MASADAYIZ YEMEK BIRAKIP DÖNÜYORUZ

                            animator.SetBool(isWalking, false);
                            agent.isStopped = true;

                            yield return new WaitForSeconds(0.5f);

                            int random2 = Random.Range(0, 2);
                            print(random2);
                            if (random2 == 0)
                            {
                                animator.SetBool(isWalking, true);
                                agent.isStopped = false;
                                agent.SetDestination(waiterHamburgerOven.transform.position);
                            }
                            if (random2 == 1)
                            {
                                animator.SetBool(isWalking, true);
                                agent.isStopped = false;
                                agent.SetDestination(waiterHotDogOven.transform.position);
                            }

                            yield return new WaitForSeconds(0.5f);
                        }

                        if ((WaiterTrigger.waiterTrigger.waiterHamburgerTake || WaiterTrigger.waiterTrigger.waiterHotDogTake) && orderOnTables.Count == 0)
                        {
                            animator.SetBool(isWalking, false);
                            agent.isStopped = true;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator TableListManager()
    {
        while (true)
        {
            int tablePiece = TABLES.transform.childCount;
            for (int i = 0; i < tablePiece; i++)
            {
                coinTableMain = TABLES.transform.GetChild(i).gameObject;
                coinTable = coinTableMain.transform.GetChild(0).gameObject;
                GameObject waiterOrder = coinTable.transform.GetChild(2).gameObject;

                if (coinTable.GetComponent<Tables>().tableOn && waiterOrder.tag != "WaiterOrderOn")
                {
                    orderOnTables.Add(coinTable);
                    print(orderOnTables.Count);

                    waiterOrder.tag = "WaiterOrderOn";
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
