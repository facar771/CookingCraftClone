using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public static LevelChange levelChange;

    public GameObject Game1;
    public GameObject Game2;
    public GameObject Game3;

    public GameObject player;

    bool a;
    bool b;
    private void Awake()
    {
        if (levelChange == null)
        {
            levelChange = this;
        }
    }
    void Start()
    {
        StartCoroutine(GameChangeManager());
    }
    IEnumerator GameChangeManager()
    {
        while (true)
        {
            if (!a && CoinManager.coinManager.update)
            {
                GameObject g1 = CoinManager.coinManager.update.transform.GetChild(0).gameObject;
                GameObject g2 = g1.transform.GetChild(0).gameObject;

                if (LevelChangeUpdate.levelChangeUpdate.levelChange && g2.tag == "LevelUpdate1")
                {
                    yield return new WaitForSeconds(1.5f);
                    yield return new WaitForSeconds(3f);
                    a = true;
                    SceneManager.LoadScene(1);
                }
                if (LevelChangeUpdate.levelChangeUpdate.levelChange && g2.tag == "LevelUpdate2")
                {
                    yield return new WaitForSeconds(3f);
                    a = true;
                    SceneManager.LoadScene(2);
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
