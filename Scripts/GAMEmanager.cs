using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEmanager : MonoBehaviour
{
    public static GAMEmanager gAMEmanager;

    public bool game1;
    public bool game2;
    public bool game3;

    private void Awake()
    {
        if (gAMEmanager == null)
        {
            gAMEmanager = this;
        }
    }
    void Start()
    {
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        while (true)
        {
            if (this.tag == "GAME-1")
            {
                print("game1");
                GameObject Truck = this.transform.GetChild(0).gameObject;
                GameObject TruckUpdate = Truck.transform.GetChild(2).gameObject;
                GameObject TruckUpdate1 = TruckUpdate.transform.GetChild(0).gameObject;
                GameObject TruckUpdate2 = TruckUpdate1.transform.GetChild(0).gameObject;

                CoinManager.coinManager.TRUCK = Truck;

                Truck.GetComponent<TruckMoveManager>().truckX = -12f;
                TruckUpdate2.GetComponent<TruckUpdate>().truckX = -12f;

                RandomPlayer.randomPlayer.xPos1 = -12.5f;
                RandomPlayer.randomPlayer.xPos2 = -10f;

                GameObject conveyorHamburger = this.transform.GetChild(1).gameObject;
                GameObject conveyorHotDog = this.transform.GetChild(2).gameObject;
                
                //CoinManager.coinManager.conveyor = conveyorHamburger;

                GameObject botCreate = this.transform.GetChild(3).gameObject;

                LevelManager.levelManager.truck = Truck;

                game1 = true;
            }
            if (this.tag == "GAME-2")
            {
                print("game2");
                GameObject Truck = this.transform.GetChild(0).gameObject;
                GameObject TruckUpdate = Truck.transform.GetChild(2).gameObject;
                GameObject TruckUpdate1 = TruckUpdate.transform.GetChild(0).gameObject;
                GameObject TruckUpdate2 = TruckUpdate1.transform.GetChild(0).gameObject;

                CoinManager.coinManager.TRUCK = Truck;

                Truck.GetComponent<TruckMoveManager>().truckX = 60.5f;
                TruckUpdate2.GetComponent<TruckUpdate>().truckX = 60.5f;

                RandomPlayer.randomPlayer.xPos1 = 60.5f;
                RandomPlayer.randomPlayer.xPos2 = 61f;

                GameObject conveyorHamburger = this.transform.GetChild(1).gameObject;
                GameObject conveyorHotDog = this.transform.GetChild(2).gameObject;

                BotWalkManager.botWalkManager.Truck = Truck;
                BotWalkManager.botWalkManager.Hamburger = conveyorHamburger;
                BotWalkManager.botWalkManager.HotDog = conveyorHotDog;

                GameObject botCreate = this.transform.GetChild(3).gameObject;
                CoinManager.coinManager.botCreate = botCreate;

                LevelManager.levelManager.truck = Truck;

                LevelManager.levelManager.level2 = true;

                game2 = true;
            }
            if (this.tag == "GAME-3")
            {
                print("game3");
                GameObject Truck = this.transform.GetChild(0).gameObject;
                GameObject TruckUpdate = Truck.transform.GetChild(2).gameObject;
                GameObject TruckUpdate1 = TruckUpdate.transform.GetChild(0).gameObject;
                GameObject TruckUpdate2 = TruckUpdate1.transform.GetChild(0).gameObject;

                CoinManager.coinManager.TRUCK = Truck;

                Truck.GetComponent<TruckMoveManager>().truckX = 144.5f;
                TruckUpdate2.GetComponent<TruckUpdate>().truckX = 144.5f;

                RandomPlayer.randomPlayer.xPos1 = 145.5f;
                RandomPlayer.randomPlayer.xPos2 = 146f;

                GameObject conveyorHamburger = this.transform.GetChild(1).gameObject;
                GameObject conveyorHotDog = this.transform.GetChild(2).gameObject;

                BotWalkManager.botWalkManager.Truck = Truck;
                BotWalkManager.botWalkManager.Hamburger = conveyorHamburger;
                BotWalkManager.botWalkManager.HotDog = conveyorHotDog;

                GameObject botCreate = this.transform.GetChild(3).gameObject;

                //CoinManager.coinManager.botCreate = botCreate;

                WaiterWalkManager.waiterWalkManager.hamburgerOven = conveyorHamburger;
                WaiterWalkManager.waiterWalkManager.hotDogOven = conveyorHotDog;

                LevelManager.levelManager.truck = Truck;

                LevelManager.levelManager.level3 = true;
                LevelManager.levelManager.conveyorHamburger = conveyorHamburger;
                LevelManager.levelManager.conveyorHotDog = conveyorHotDog;
                

                game3 = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
