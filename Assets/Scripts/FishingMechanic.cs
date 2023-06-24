using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMechanic : MonoBehaviour
{
    private int spaceKeyPressCount;
    private bool fishOnHook;

    void Start()
    {
        fishOnHook = false;
    }

    void Update()
    {
                    // if the fish was on the hook, the player will tap space 3 times to catch it
        if (fishOnHook)
        {
            // Check for the space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceKeyPressCount++;

                if (spaceKeyPressCount >= 3)
                {
                    Debug.Log("Congratulations! You caught the fish!");
                    fishOnHook = false; // cannot cast the line again until they've caught the fish
                }
                else
                {
                    Debug.Log("Press Space " + (3 - spaceKeyPressCount) + " more time(s) to catch the fish.");
                }
            }
        }

        else
        {
            // Cast the fishing line
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                float fishCatchChance = Random.Range(0f, 5f);

                if (fishCatchChance < 3.5f)
                {
                    Debug.Log("Fish Caught");
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
}
