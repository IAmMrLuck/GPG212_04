using System.Collections;
using UnityEngine;

public class AccessibilityMode : MonoBehaviour
{
    private int spaceKeyPressCount;
    public static bool fishOnHook;

    [SerializeField] private GameObject fishOnHookMsg;

    private bool isThreeTapMode;

    [SerializeField] private FishInventory fishInventory;

    public string[] availableFish;

    private void Start()
    {
        fishOnHook = false;
        fishOnHookMsg.SetActive(false);
        isThreeTapMode = false;
    }

    private void Update()
    {
        //if (fishOnHook)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        if (isThreeTapMode)
        //        {
        //            GetFish();
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        CastRod();
        //    }
        //}
    }

    //private void GetFish()
    //{
    //    if (fishOnHook && isThreeTapMode)
    //    {
    //        spaceKeyPressCount++;
    //        if (spaceKeyPressCount >= 3)
    //        {
    //            Debug.Log("Congratulations! You caught the fish!");
    //            fishInventory.FishScore();
    //            fishOnHook = false;
    //        }
    //        else
    //        {
    //            Debug.Log(string.Format("Press Space {0} more time(s) to catch the fish.", 3 - spaceKeyPressCount));
    //        }
    //    }
    //}

    public void MashReelButton()
    {
        if (fishOnHook && isThreeTapMode)
        {
            spaceKeyPressCount++;
            if (spaceKeyPressCount >= 10)
            {
                Debug.Log("Congratulations! You caught the fish!");
                CatchRandomFish();
                fishInventory.FishScore();
            }
            else
            {
                Debug.Log(string.Format("Press Space {0} more time(s) to catch the fish.", 10 - spaceKeyPressCount));
            }
        }
    }

    private void Catch(string fishName)
    {
        Debug.Log("Called Catch()");
        fishInventory.CatchFish(fishName);
    }

    private void CastRod()
    {
        if (!fishOnHook && isThreeTapMode)
        {
            float fishCatchChance = Random.Range(0f, 5f);
            if (fishCatchChance < 3.5f)
            {
                Debug.Log("Fish is on the hook");
                StartCoroutine(ActivateFishPrompt());
                fishOnHook = true;
                spaceKeyPressCount = 0;
                Debug.Log("Press Space to catch the fish!");
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
        isThreeTapMode = !isThreeTapMode;
    }

    public void CatchRandomFish()
    {
        int randomIndex = Random.Range(0, availableFish.Length);
        string fishName = availableFish[randomIndex];
        Debug.Log("Random Number selected " + randomIndex);
        Debug.Log("Fish Caught was " + fishName);
        Catch(fishName);
    }
}
