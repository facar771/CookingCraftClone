using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChangeUpdate : MonoBehaviour
{
    public static LevelChangeUpdate levelChangeUpdate;

    public GameObject Player;
    public GameObject LevelUpdate;
    public GameObject LevelUpdateZone;
    public GameObject LevelUpdateZone2;

    Animator animator;
    Animator animator2;

    int playerTable;
    int playerTable2;
    float transparen;

    public bool levelChange1 = false;
    public bool levelChange = false;

    private void Awake()
    {
        if (levelChangeUpdate == null)
        {
            levelChangeUpdate = this;
        }
    }
    void Start()
    {
        playerTable = Animator.StringToHash("playerTable");
        playerTable2 = Animator.StringToHash("playerTable2");
        animator = LevelUpdateZone.GetComponent<Animator>();

        StartCoroutine(level());
        StartCoroutine(animationn());
        StartCoroutine(colorChange());
    }

    IEnumerator level()
    {
        while (true)
        {
            Animator walk = Player.GetComponent<Animator>();
            int isWalking = Animator.StringToHash("IsWalking");

            if (levelChange)
            {
                walk.SetBool(isWalking, true);
                Player.transform.rotation = Quaternion.Euler(0, 45, 0);
                Player.transform.Translate(0f, 0f, 2f * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
    IEnumerator colorChange()
    {
        while (true)
        {
            if (levelChange)
            {
                yield return new WaitForSeconds(2f);
                while (true)
                {
                    Image img = LevelUpdate.GetComponent<Image>();
                    img.color = new Color(0.2f, 0.2f, 0.2f, transparen);
                    transparen += 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator animationn()
    {
        while (true)
        {
            if (animator)
            {
                if (StackTrigger.instanceStackTrigger.levelUpdate1 == true)
                {
                    animator.SetBool(playerTable, true);
                    print("Çalýþýyo");
                }

                if (StackTrigger.instanceStackTrigger.levelUpdate1 == false)
                {
                    animator.SetBool(playerTable, false);
                }

                if (StackTrigger.instanceStackTrigger.levelUpdate11 == true)
                {
                    animator.SetBool(playerTable2, true);
                    print("e bura çalýþýyo2");
                }
                if (StackTrigger.instanceStackTrigger.levelUpdate11 == false)
                {
                    animator.SetBool(playerTable2, false);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
