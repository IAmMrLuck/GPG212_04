using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccessibilityMode : MonoBehaviour
{
    private int spaceKeyPressCount;
    private bool fishOnHook;

    [SerializeField] private GameObject fishOnHookMsg;

    private bool threeTapMode;

    [SerializeField] private FishInventory fishInventoryCS;

    void Start()
    {
        fishOnHook = false;
        fishOnHookMsg.SetActive(false);
        threeTapMode = false; // fix this button option for accessibility purposes
    }

    void Update()
    {
        // KEEP FOR PC TESTING
        // if the fish was on the hook, the player will tap space 3 times to catch it
        if (fishOnHook)
        {
            // Check for the space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(threeTapMode == true)
                {
                    GetThreeTapFish();
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            // Cast the fishing line
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CastRod();
            }
        }
    }

    public void GetThreeTapFish()
    {
        if (fishOnHook == true && threeTapMode == true)
        {
            spaceKeyPressCount++;
            if (spaceKeyPressCount >= 3)
            {
                Debug.Log("Congratulations! You caught the fish!");
                fishInventoryCS.FishScore();

                // instantiat6e fish type
                // CatchThefish()
                // call method of deciding fish

                fishOnHook = false; // cannot cast the line again until they've caught the fish
            }
            else
            {
                Debug.Log("Press Space " + (3 - spaceKeyPressCount) + " more time(s) to catch the fish.");
            }
        }
    }

    public void MashReelButton()
    {
        {
            if (fishOnHook == true && threeTapMode == false)
            {
                spaceKeyPressCount++;
                if (spaceKeyPressCount >= 10)
                {
                    Debug.Log("Congratulations! You caught the fish!");
                    fishInventoryCS.FishScore();

                    // call method of deciding fish

                    fishOnHook = false; // cannot cast the line again until they've caught the fish
                }
                else
                {
                    Debug.Log("Press Space " + (10 - spaceKeyPressCount) + " more time(s) to catch the fish.");
                }
            }
        }
    }

    public void CastRod()
    {
        if (fishOnHook == false)
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
    private IEnumerator ActivateFishPrompt()
    {
        Debug.Log("Coroutine Started");
        fishOnHookMsg.SetActive(true);

        yield return new WaitForSeconds(2);

        fishOnHookMsg.SetActive(false);
    }

    public void SetThreeTapMode()
    {
        if(threeTapMode == true)
        {
            threeTapMode = false;
        }

        else if (threeTapMode == false)
        {
            threeTapMode = true;
        }
    }

}
