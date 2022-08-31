using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCreate : MonoBehaviour
{
    public static TableCreate tableCreate;

    public List<GameObject> tableList = new List<GameObject>();

    public GameObject Table;

    int playerTable;
    int playerTable2;
    int playerTable3;
    int cylenderClose;

    Animator animator;
    Animator animator2;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        if (tableCreate == null)
        {
            tableCreate = this;
        }
    }
    void Start()
    {
        playerTable = Animator.StringToHash("playerTable");
        playerTable2 = Animator.StringToHash("playerTable2");
        playerTable3 = Animator.StringToHash("tableActive");
        cylenderClose = Animator.StringToHash("cylenderClose");
        //tableFirst = Animator.StringToHash("TableFirst");

        StartCoroutine(TableAnimator());
    }
    IEnumerator TableAnimator()
    {
        while (true)
        {
            if (StackTrigger.instanceStackTrigger.tableCreate && Table)
            {
                GameObject cylender = Table.transform.GetChild(1).gameObject;
                animator = cylender.GetComponent<Animator>();
                animator.SetBool(playerTable, true);

                if (StackTrigger.instanceStackTrigger.tableMain == true)
                {
                    animator.SetBool(playerTable2, true);

                    if (Table.GetComponent<Tables>().tableOn)
                    {
                        GameObject tableIn = Table.transform.GetChild(0).gameObject;
                        meshRenderer = tableIn.GetComponent<MeshRenderer>();
                        meshRenderer.enabled = true;

                        animator2 = tableIn.GetComponent<Animator>();
                        animator2.SetBool(playerTable3, true);
                        animator.SetBool(cylenderClose, true);
                    }
                }
                if (StackTrigger.instanceStackTrigger.tableMain == false)
                {
                    animator.SetBool(playerTable2, false);
                }
            }
            if (Table && !StackTrigger.instanceStackTrigger.tableCreate)
            {
                GameObject cylender = Table.transform.GetChild(1).gameObject;
                animator = cylender.GetComponent<Animator>();
                animator.SetBool(playerTable, false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}