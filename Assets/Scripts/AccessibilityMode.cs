using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccessibilityMode : MonoBehaviour
{
    private int spaceKeyPressCount;
    private bool fishOnHook;

    [SerializeField] private GameObject fishOnHookMsg;
    private Coroutine FishMessage;


    void Start()
    {
        fishOnHook = false;
        fishOnHookMsg.SetActive(false);
    }

    void Update()
    {
        // if the fish was on the hook, the player will tap space 3 times to catch it
        if (fishOnHook)
        {
            // Check for the space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetFish();
            }
        }

        else
        {
            // Cast the fishing line
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                float fishCatchChance = Random.Range(0f, 5f);

                if (fishCatchChance < 3.5f)
                {
                    Debug.Log("fish is on Hook");
                    StartCoroutine("ActivateFishPrompt");
                    Debug.Log("Coroutine Called");
                    fishOnHook = true;
                    spaceKeyPressCount = 0;
                    Debug.Log("Press Space to catch the Fish!");
                }
                else
                {
                    Debug.Log("Not even a nibble!");
                }
            }
        }
    }

    public void GetFish()
    {
        spaceKeyPressCount++;
        if (spaceKeyPressCount >= 3)
        {
            Debug.Log("Congratulations! You caught the fish!");
            fishOnHook = false; // cannot cast the line again until they've caught the fish
            StopCoroutine("ActivateFishPrompt");
        }
        else
        {
            Debug.Log("Press Space " + (3 - spaceKeyPressCount) + " more time(s) to catch the fish.");
        }
    }


    private IEnumerator ActivateFishPrompt()
    {
        Debug.Log("Coroutine Started");
        fishOnHookMsg.SetActive(true);

        yield return new WaitForSeconds(2);

        fishOnHookMsg.SetActive(false);
    }
}
