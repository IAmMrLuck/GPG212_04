using ConaLuk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishInventory : MonoBehaviour
{
    private int fishingScore;
    public GameObject[] inventoryImages;
    public string[] fishNames;

    

    void Start()
    {
        fishingScore = 0;
    }


    public void FishScore()
    {

        fishingScore++;
        FishBehaviour.isFishOnHook = false;

        Debug.Log("Score is " + fishingScore);

    }


    public void CatchFish(string fishName)
    {
        Debug.Log("You have called the method CatchFish()");
        for (int i = 0; i < fishNames.Length; i++)
        {
            if (fishNames[i] == fishName)
            {
                inventoryImages[i].SetActive(true);
                Debug.Log("Opened Inventory slot");
                break;
            }
        }
    }

    // each type of fish is kept as a seperate score
    // the score will become money and relevant to each fish
    // the money, fish and score will all be viewable from a tab which can be opened and closed

}
