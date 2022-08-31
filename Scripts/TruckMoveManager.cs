using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMoveManager : MonoBehaviour
{
    public static TruckMoveManager truckManagerinstanse;

    public GameObject truck;
    public GameObject doorR;
    public GameObject doorL;

    public float maximumGo = 30f;
    public float maximumCome = 22f;
    private float moveSpeed = 2f;
    public float truckX;

    public bool truckIsHere = false;
    bool asdasd = false;

    Animator animatorR;
    Animator animatorL;

    int isComingR;
    int isComingL;
    int isNotComingR;
    int isNotComingL;

    private void Awake()
    {
        if (truckManagerinstanse == null)
        {
            truckManagerinstanse = this;
        }
    }
    void Start()
    {
        

        animatorR = doorR.GetComponent<Animator>();
        animatorL = doorL.GetComponent<Animator>();

        isComingR = Animator.StringToHash("Open");
        isComingL = Animator.StringToHash("Open");

        isNotComingR = Animator.StringToHash("Close");
        isNotComingL = Animator.StringToHash("Close");

        StartCoroutine(TruckMove());
    }

    IEnumerator TruckMove()
    {
        while (true)
        {
            if (!asdasd)
            {
                yield return new WaitForSeconds(0.1f);
                Vector3 position = new Vector3(truckX, 0f, 30);
                truck.transform.position = position;
                asdasd = true;
            }
            if (truckIsHere)
            {
                TruckCome();
            }
            if (!truckIsHere)
            {
                TruckGo();
            }
            yield return new WaitForSeconds(0.005f);    //Kamyonun hýzýný ayarla    
        }
    }

    public IEnumerator TruckGoManager()
    {
        while (true)
        {
            if (truck.transform.position.z < 23)
            {
                yield return new WaitForSeconds(1f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TruckComeManager()
    {
        while (true)
        {
            if (truck.transform.position.z > 29)
            {
                yield return new WaitForSeconds(2f);
                TruckMoveManager.truckManagerinstanse.truckIsHere = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void TruckGo()
    {
        if (truck.transform.position.z < maximumGo)
        {
            truck.transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);

            if (truck.transform.position.z > maximumCome && truck.transform.position.z < maximumCome + 0.1f)
            {
                animatorR.SetBool(isComingR, false);
                animatorL.SetBool(isComingL, false);

                animatorR.SetBool(isNotComingR, false);
                animatorL.SetBool(isNotComingL, false);
            }

            else if (truck.transform.position.z > maximumCome + 0.2f)
            {
                animatorR.SetBool(isNotComingR, true);
                animatorL.SetBool(isNotComingL, true);
            }
        }
    }

    void TruckCome()
    {
        if (truck.transform.position.z > maximumCome)
        {
            truck.transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime);

            if (truck.transform.position.z > maximumCome + 4f)      //Kapýlar Hareketsiz
            {
                animatorR.SetBool(isComingR, false);
                animatorL.SetBool(isComingL, false);

                animatorR.SetBool(isNotComingR, false);
                animatorL.SetBool(isNotComingL, false);
            }

            else if (truck.transform.position.z < maximumCome + 0.5f)     //Kapýlar Açýlýyor
            {
                animatorR.SetBool(isComingR, true);
                animatorL.SetBool(isComingL, true);

                animatorR.SetBool(isNotComingR, false);
                animatorL.SetBool(isNotComingL, false);
            }
        }
    }
}
