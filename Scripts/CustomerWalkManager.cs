using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalkManager : MonoBehaviour
{
    public static CustomerWalkManager customerWalkManager;

    List<GameObject> CustomerFullList = new List<GameObject>();

    public GameObject tableMain;

    public GameObject exit;

    Animator animator;

    int isWalking;

    NavMeshAgent agent;
    NavMeshAgent agent2;

    public bool orderOn;

    public bool foodFinished;

    private void Awake()
    {
        if (customerWalkManager == null)
        {
            customerWalkManager = this;
        }
    }

    void Start()
    {
        //isWalking = Animator.StringToHash("IsWalking");

        //StartCoroutine(CustomerWalk());
        //StartCoroutine(FullCustomerManager());
    }

    IEnumerator CustomerWalk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject object1 = tableMain.transform.GetChild(0).gameObject;
            GameObject object2 = object1.transform.GetChild(0).gameObject;
            GameObject table = object2.transform.GetChild(7).gameObject;
            print("Anlamak için");

            while (RandomPlayer.randomPlayer.customerList.Count > 0/* && TableCreate.tableCreate.tableActive */&& this.tag == "TableMain")
            {
                if (!orderOn)
                {
                    GameObject customer = RandomPlayer.randomPlayer.customerList[RandomPlayer.randomPlayer.customerList.Count - 1];
                    agent = customer.GetComponent<NavMeshAgent>();
                    animator = customer.GetComponent<Animator>();

                    if (!table.GetComponent<TableTriggerManager>().orderOn && customer.tag == "Customer")
                    {
                        animator.SetBool(isWalking, true);
                        agent.SetDestination(table.transform.position);
                    }

                    if (table.GetComponent<TableTriggerManager>().orderOn && !OrderManager.orderManager.foodFinished) 
                    {
                        print("Çalýþýyor MU ");
                        animator.SetBool(isWalking, false);
                        agent.isStopped = true;

                        CustomerFullList.Add(RandomPlayer.randomPlayer.customerList[RandomPlayer.randomPlayer.customerList.Count - 1]);
                        RandomPlayer.randomPlayer.customerList.RemoveAt(RandomPlayer.randomPlayer.customerList.Count - 1);

                        orderOn = true;
                    }
                }
                yield return new WaitForSeconds(0.2f);
            }
            
        }
    }

    IEnumerator FullCustomerManager()
    {
        while (true)
        {
            if (orderOn && CustomerFullList.Count > 0 && this.tag == "TableMain")
            {
                GameObject customer = CustomerFullList[CustomerFullList.Count - 1];
                agent = customer.GetComponent<NavMeshAgent>();
                animator = customer.GetComponent<Animator>();
                CoinManager.coinManager.coinOn = true;

                if (OrderManager.orderManager.foodFinished && !TableTriggerManager.tableTriggerManager.exit)
                {
                    customer.tag = "CustomerFull";
                    animator.SetBool(isWalking, true);
                    agent.isStopped = false;
                    agent.SetDestination(exit.transform.position);
                    print("Kaç Kere çlaýþýyo");
                    CoinManager.coinManager.coinOn = false;
                }
            }

            if (!orderOn && CustomerFullList.Count > 0 && this.tag == "TableMain")
            {
                GameObject customer = CustomerFullList[CustomerFullList.Count - 1];
                agent = customer.GetComponent<NavMeshAgent>();
                animator = customer.GetComponent<Animator>();

                if (customer.tag == "CustomerFull" && exit.GetComponent<TableTriggerManager>().exit)
                {
                    Destroy(CustomerFullList[CustomerFullList.Count - 1]);
                    CustomerFullList.RemoveAt(CustomerFullList.Count - 1);
                    CoinManager.coinManager.coinOn = true;
                    exit.GetComponent<TableTriggerManager>().exit = false;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }


    //while (RandomPlayer.randomPlayer.customerList.Count > 0 && TableCreate.tableCreate.tableActive2 && this.tag == "TableMain2")
    //{
    //    print("umursamýyo");
    //    GameObject customer = RandomPlayer.randomPlayer.customerList[RandomPlayer.randomPlayer.customerList.Count - 1];
    //    agent = customer.GetComponent<NavMeshAgent>();
    //    animator = customer.GetComponent<Animator>();

    //    if (!table2.GetComponent<TableTriggerManager>().orderOn4 && customer.tag == "Customer")
    //    {
    //        animator.SetBool(isWalking, true);
    //        agent.SetDestination(table2.transform.position);
    //    }

    //    if (table2.GetComponent<TableTriggerManager>().orderOn4 && !OrderManager.orderManager.foodFinished)
    //    {
    //        print("OrderOn2");
    //        orderOn = true;
    //        animator.SetBool(isWalking, false);
    //        agent.isStopped = true;
    //    }

    //    if (OrderManager.orderManager.foodFinished && !TableTriggerManager.tableTriggerManager.exit)
    //    {
    //        customer.tag = "CustomerFull";
    //        animator.SetBool(isWalking, true);
    //        agent.isStopped = false;
    //        agent.SetDestination(exit.transform.position);
    //        orderOn = false;

    //    }

    //    if (customer.tag == "CustomerFull" && exit.GetComponent<TableTriggerManager>().exit)
    //    {
    //        OrderManager.orderManager.foodFinished = false;
    //        Destroy(RandomPlayer.randomPlayer.customerList[RandomPlayer.randomPlayer.customerList.Count - 1]);
    //        RandomPlayer.randomPlayer.customerList.RemoveAt(RandomPlayer.randomPlayer.customerList.Count - 1);
    //    }


    //    yield return new WaitForSeconds(0.2f);
    //}
}
