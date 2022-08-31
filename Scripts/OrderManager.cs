using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public static OrderManager orderManager;

    public TextMeshProUGUI hamburgerText;
    public TextMeshProUGUI hotDogText;

    public GameObject table;

    public GameObject masa;
    public GameObject masa2;

    public GameObject masa3;
    public GameObject masa4;


    private GameObject canvas;
    private GameObject canvas2;
    private GameObject hamburger;
    private GameObject hotDog;

    private GameObject hamburgerCanvasPrice;
    private GameObject hotDogCanvasPrice;

    public bool foodFinished;
    public int hamburgerPrice;
    public int hotDogPrice;
    public int hamburgerPrice2;
    public int hotDogPrice2;
    int i = 0;
    public int totalOrder = 0;
    public int totalOrder2 = 0;

    private void Awake()
    {
        if (orderManager == null)
        {
            orderManager = this;
        }
    }

    void Start()
    {
        //StartCoroutine(CustomerOrder());
    }

    IEnumerator CustomerOrder()
    {
        while (true)
        {
            if (totalOrder == 0 &&/* TableCreate.tableCreate.tableActive &&*/ this.tag == "TableMain")
            {
                hamburgerPrice = Random.Range(1, 3);
                hotDogPrice = Random.Range(1, 3);
                totalOrder = hamburgerPrice + hotDogPrice;
            }

            canvas = masa.transform.GetChild(0).gameObject;
            

            while (masa3.GetComponent<CustomerWalkManager>().orderOn) 
            {
                canvas.SetActive(true);

                totalOrder = hamburgerPrice + hotDogPrice;

                hamburgerText.text = hamburgerPrice.ToString();
                hotDogText.text = hotDogPrice.ToString();

                yield return new WaitForSeconds(0.1f);

                if (hamburgerPrice == 0)
                {
                    hamburger = canvas.transform.GetChild(0).gameObject;
                    hamburgerCanvasPrice = canvas.transform.GetChild(2).gameObject;
                    hamburger.SetActive(false);
                    hamburgerCanvasPrice.SetActive(false);
                }

                if (hotDogPrice == 0)
                {
                    hotDog = canvas.transform.GetChild(1).gameObject;
                    hotDogCanvasPrice = canvas.transform.GetChild(3).gameObject;
                    hotDog.SetActive(false);
                    hotDogCanvasPrice.SetActive(false);
                }

                if (hamburgerPrice == 0 && hotDogPrice == 0 && RandomPlayer.randomPlayer.customerList.Count > 0)
                {
                    foodFinished = true;
                    print("FoodFinishedControl");
                }

                i += 1;
            }

            if (!masa3.GetComponent<CustomerWalkManager>().orderOn)
            {
                foodFinished = false;

                canvas.SetActive(false);

                hamburger = canvas.transform.GetChild(0).gameObject;
                hamburgerCanvasPrice = canvas.transform.GetChild(2).gameObject;
                hamburger.SetActive(true);
                hamburgerCanvasPrice.SetActive(true);

                hotDog = canvas.transform.GetChild(1).gameObject;
                hotDogCanvasPrice = canvas.transform.GetChild(3).gameObject;
                hotDog.SetActive(true);
                hotDogCanvasPrice.SetActive(true);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
