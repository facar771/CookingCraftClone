using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCreate : MonoBehaviour
{
    public static BotCreate botCreate;

    public GameObject TableAnimation;

    Animator animator;

    int playerTable;
    int playerTable2;
    int cylenderClose;
    public int coinPayBotPrice = 20;

    public bool botActive = false;
    public bool waiterActive = false;

    private void Awake()
    {
        if (botCreate == null)
        {
            botCreate = this;
        }
    }
    void Start()
    {
        playerTable = Animator.StringToHash("playerTable");
        playerTable2 = Animator.StringToHash("playerTable2");
        cylenderClose = Animator.StringToHash("cylenderClose");

        StartCoroutine(BotCreateAnimator());
    }

    IEnumerator BotCreateAnimator()
    {
        while (true)
        {
            if (CoinManager.coinManager.botCreate)
            {
                GameObject g1 = CoinManager.coinManager.botCreate.transform.GetChild(0).gameObject;
                GameObject g2 = g1.transform.GetChild(0).gameObject;

                animator = g2.GetComponent<Animator>();

                if (StackTrigger.instanceStackTrigger.botCreate == true)
                {
                    animator.SetBool(playerTable, true);
                }

                if (StackTrigger.instanceStackTrigger.botCreate == false)
                {
                    animator.SetBool(playerTable, false);
                }

                if (StackTrigger.instanceStackTrigger.botCreate2 == true)
                {
                    animator.SetBool(playerTable2, true);

                    if (CoinManager.coinManager.botOn && g2.tag == "BotCreate")
                    {
                        animator.SetBool(cylenderClose, true);
                        botActive = true;
                    }
                    if (CoinManager.coinManager.botOn && g2.tag == "WaiterUpdate1")
                    {
                        waiterActive = true;
                    }
                }

                if (StackTrigger.instanceStackTrigger.botCreate2 == false)
                {
                    animator.SetBool(playerTable2, false);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
