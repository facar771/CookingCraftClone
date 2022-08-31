using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTriggerManager : MonoBehaviour
{
    public static BotTriggerManager botTriggerManager;
    public bool botRawTake;
    public bool botHamburgerLeave;
    public bool botHotDogLeave;
    private void Awake()
    {
        if (botTriggerManager == null)
        {
            botTriggerManager = this;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BotRawTake")
        {
            botRawTake = true;
        }
        if (other.tag == "BotHamburgerLeave")
        {
            botHamburgerLeave = true;
        }
        if (other.tag == "BotHotDogLeave")
        {
            botHotDogLeave = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BotRawTake")
        {
            botRawTake = false;
        }
        if (other.tag == "BotHamburgerLeave")
        {
            botHamburgerLeave = false;
        }
        if (other.tag == "BotHotDogLeave")
        {
            botHotDogLeave = false;
        }
    }
}
