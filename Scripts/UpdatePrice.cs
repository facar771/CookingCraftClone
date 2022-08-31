using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePrice : MonoBehaviour
{
    public static UpdatePrice updatePrice;

    public int levelUpdatePrice = 20;
    private void Awake()
    {
        if (updatePrice == null)
        {
            updatePrice = this;
        }
    }
}
