using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour
{
    public static RandomPlayer randomPlayer;

    public GameObject biker;
    private GameObject ChildGameObject1;

    public List<GameObject> customerList = new List<GameObject>();

    public float xPos1;
    public float xPos2;

    public float xPos;
    public int zPos;

    int i;

    private void Awake()
    {
        if (randomPlayer == null)
        {
            randomPlayer = this;
        }
    }

    void Start()
    {
        StartCoroutine(CustomerCreate());
    }

    IEnumerator CustomerCreate()
    {
        while (true)
        {
            if (customerList.Count < 6)
            {
                yield return new WaitForSeconds(0.3f);

                xPos = Random.Range(xPos1, xPos2);
                int random = Random.Range(0, 19);
                zPos = -customerList.Count - 15;
                GameObject playerNew = Instantiate(biker, new Vector3(xPos, 0.1f, zPos), Quaternion.identity);

                for (int i = 0; i < 19; i++)
                {
                    ChildGameObject1 = playerNew.transform.GetChild(i).gameObject;
                    ChildGameObject1.SetActive(false);
                }

                ChildGameObject1 = playerNew.transform.GetChild(random).gameObject;
                ChildGameObject1.SetActive(true);

                customerList.Add(playerNew);

                playerNew.tag = "Customer"; 
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
