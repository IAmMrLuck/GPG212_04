using ConaLuk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInventory : MonoBehaviour
{
    private int fishingScore;
    public FishDisplay fish;
    

    void Start()
    {
        fishingScore = 0;
    }

    public void FishScore()
    {
        fishingScore++;
        Debug.Log("Score is " + fishingScore);
        Debug.Log("You Caught a " + fish.scriptableObjects);
    }

    // each type of fish is kept as a seperate score
    // the score will become money and relevant to each fish
    // the money, fish and score will all be viewable from a tab which can be opened and closed

}
