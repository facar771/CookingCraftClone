using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{
    public static TruckMove truckMoveinstanse;

    public GameObject truck;
    public GameObject doorR;
    public GameObject doorL;

    public float maximumGo = 30f;
    public float maximumCome = 22f;
    private float moveSpeed = 2f;
    //private float time = 2;

    public bool truckIsHere = false;

    Animator animatorR;
    Animator animatorL;

    int isComingR;
    int isComingL;
    int isNotComingR;
    int isNotComingL;

    private void Awake()
    {
        if (truckMoveinstanse == null)
        {
            truckMoveinstanse = this;
        }
    }

    void Start()
    {
        Vector3 position = new Vector3(5.0f, 0f, 30);
        truck.transform.position = position;

        animatorR = doorR.GetComponent<Animator>();
        animatorL = doorL.GetComponent<Animator>();

        isComingR = Animator.StringToHash("Open");
        isComingL = Animator.StringToHash("Open");

        isNotComingR = Animator.StringToHash("Close");
        isNotComingL = Animator.StringToHash("Close");
    }

    public void TruckForth()
    {
        print("BUDA ÇALIIYO");
        while (truck.transform.position.z < maximumGo)
        {
            print("BUDA ÇALIIYO2");
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

    public void TruckBack()
    {
        while (truck.transform.position.z > maximumCome)
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

    void Update()
    {
        if (truckIsHere)       //Araç Geri Geliyor
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

        else    //Araç Ýleri Gidiyor
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
    }

    /*
    IEnumerator ExecuteAfterTime(float time)
    {
        movingTruck.transform.Translate(0f, 0f, 0f);
        yield return new WaitForSeconds(time);
        movingTruck.transform.Translate(0f, 0.005f, 0f;     //TÝTREME KODLARI
        yield return new WaitForSeconds(time);
        movingTruck.transform.Translate(0f, 0f, 0f);
        yield return new WaitForSeconds(time);
        movingTruck.transform.Translate(0f, -0.005f, 0f);
        yield return new WaitForSeconds(time);
        StartCoroutine(ExecuteAfterTime(0.05f));
    }
    */

    /*
     
        //truckMotor.SetBool(motor, true);          //TÝTREME KODLARI
        if (playerIsHere)       //Araç Geri Geliyor
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

        else    //Araç Ýleri Gidiyor
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

     */

}
