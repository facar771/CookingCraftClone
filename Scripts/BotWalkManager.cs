using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotWalkManager : MonoBehaviour
{
    public static BotWalkManager botWalkManager;

    Animator animator;

    GameObject botRawTransform;
    public GameObject botHamburgerDropTransform;
    public GameObject botHotDogDropTransform;

    public GameObject Truck;
    public GameObject Hamburger;
    public GameObject HotDog;

    int isWalking;

    public bool orderOn;
    public bool ovenChange;

    NavMeshAgent agent;
    private void Awake()
    {
        if (botWalkManager == null)
        {
            botWalkManager = this;
        }
    }
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        isWalking = Animator.StringToHash("IsWalking");
        StartCoroutine(CustomerWalk());
    }
    IEnumerator CustomerWalk()
    {
        while (true)
        {
            if (Truck && Hamburger && HotDog)
            {
                GameObject truckLeave = Truck.transform.GetChild(1).gameObject;
                GameObject parent = truckLeave.transform.GetChild(0).gameObject;
                botRawTransform = parent.transform.GetChild(2).gameObject;

                GameObject conveyor1 = Hamburger.transform.GetChild(0).gameObject;
                botHamburgerDropTransform = conveyor1.transform.GetChild(3).gameObject;

                GameObject conveyor2 = HotDog.transform.GetChild(0).gameObject;
                botHotDogDropTransform = conveyor2.transform.GetChild(3).gameObject;
            }
            if (BotCreate.botCreate.botActive)
            {
                if (RawMaterialManager.rawMaterialManager.hamburgerOvenList.Count < RawMaterialManager.rawMaterialManager.rawOvenPiece && !ovenChange)
                {
                    while (!BotTriggerManager.botTriggerManager.botRawTake)
                    {
                        animator.SetBool(isWalking, true);
                        agent.SetDestination(botRawTransform.transform.position);

                        yield return new WaitForSeconds(0.1f);
                    }
                    if (BotTriggerManager.botTriggerManager.botRawTake)
                    {
                        animator.SetBool(isWalking, false);
                        agent.isStopped = true;
                    }
                    while (BotRawManager.botRawManager.botRawTakeList.Count == 5)
                    {
                        animator.SetBool(isWalking, true);
                        agent.isStopped = false;
                        agent.SetDestination(botHamburgerDropTransform.transform.position);
                        if (BotTriggerManager.botTriggerManager.botHamburgerLeave)
                        {
                            animator.SetBool(isWalking, false);
                            agent.isStopped = true;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                    while (!(BotRawManager.botRawManager.botRawTakeList.Count == 0) && BotTriggerManager.botTriggerManager.botHamburgerLeave)
                    {
                        yield return new WaitForSeconds(0.1f);
                        agent.isStopped = false;
                        if (BotRawManager.botRawManager.botRawTakeList.Count == 0)
                        {
                            agent.SetDestination(botRawTransform.transform.position);
                            ovenChange = true;
                        }
                    }
                }

                if (RawMaterialManager.rawMaterialManager.hotDogOvenList.Count < RawMaterialManager.rawMaterialManager.rawOvenPiece && ovenChange)
                {
                    while (!BotTriggerManager.botTriggerManager.botRawTake)
                    {
                        animator.SetBool(isWalking, true);
                        agent.SetDestination(botRawTransform.transform.position);

                        yield return new WaitForSeconds(0.1f);
                    }
                    if (BotTriggerManager.botTriggerManager.botRawTake)
                    {
                        animator.SetBool(isWalking, false);
                        agent.isStopped = true;
                    }
                    while (BotRawManager.botRawManager.botRawTakeList.Count == 5)
                    {
                        animator.SetBool(isWalking, true);
                        agent.isStopped = false;
                        agent.SetDestination(botHotDogDropTransform.transform.position);
                        if (BotTriggerManager.botTriggerManager.botHotDogLeave)
                        {
                            animator.SetBool(isWalking, false);
                            agent.isStopped = true;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                    while (!(BotRawManager.botRawManager.botRawTakeList.Count == 0) && BotTriggerManager.botTriggerManager.botHotDogLeave)
                    {
                        yield return new WaitForSeconds(0.1f);
                        agent.isStopped = false;
                        if (BotRawManager.botRawManager.botRawTakeList.Count == 0)
                        {
                            agent.SetDestination(botRawTransform.transform.position);
                            ovenChange = false;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
