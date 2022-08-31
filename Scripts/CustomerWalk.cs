using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalk : MonoBehaviour
{
    //public GameObject player;
    //private GameObject ChildGameObject;
    

    //Animator animator;

    //private List<GameObject> customer = new List<GameObject>();

    //public int xPos;
    //public int zPos;

    //int i;
    //int isWalking;

    //NavMeshAgent agent;

    //public bool orderOn;



    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    animator = GetComponent<Animator>();
    //    isWalking = Animator.StringToHash("IsWalking");
    //    //StartCoroutine(CustomerCreate());
    //}
    //void Update()
    //{
    //    if (Input.GetKeyDown("a"))
    //    {
    //        animator.SetBool(isWalking, true);
    //        agent.SetDestination(table1.transform.position);
    //    }
    //    if (Input.GetKeyDown("b"))
    //    {
    //        agent.SetDestination(table1.transform.position);
    //        animator.SetBool(isWalking, true);
    //    }
    //}
    //IEnumerator CustomerCreate()
    //{
    //    for (int j = 0; j < 10; j++)
    //    {
    //        xPos = Random.Range(2, 8);
    //        zPos = Random.Range(-3, -8);
    //        int random = Random.Range(0, 19);

    //        GameObject playerNew = Instantiate(player, new Vector3(xPos, 0.1f, zPos), Quaternion.identity);

    //        for (int i = 0; i < 19; i++)
    //        {
    //            ChildGameObject = playerNew.transform.GetChild(i).gameObject;
    //            ChildGameObject.SetActive(false);
    //        }

    //        ChildGameObject = playerNew.transform.GetChild(random).gameObject;
    //        ChildGameObject.SetActive(true);

    //        customer.Add(playerNew);

    //        yield return new WaitForSeconds(0.3f);
    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "OrderOn")
    //    {
    //        print("Çlaýþýyo");
    //        if (animator == null)
    //        {
    //            animator.SetBool(isWalking, true);
    //        }
    //        animator.SetBool(isWalking, false);
    //    }
    //}
    ////public void OnTriggerExit(Collider other)
    ////{
    ////    if (other.tag == "OrderOn")
    ////    {
    ////        animator.SetBool(isWalking, true);
    ////    }
    ////}
}
