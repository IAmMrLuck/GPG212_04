using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace ConaLuk
{



    public class RodBehaviour : MonoBehaviour
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
            MashReelButton();
        }

        public void MashReelButton()
        {
            if (fishOnHook && !isThreeTapMode)
            {
                var touch = Touchscreen.current.primaryTouch;
                if (touch.press.isPressed)
                {
                    Debug.Log("ScreenTouched");
                    if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended && touch.delta.ReadValue().magnitude > 0.5f)
                    {
                        Debug.Log("Swipe detected! You caught the fish!");
                        CatchRandomFish();
                        fishInventory.FishScore();
                    }
                    else
                    {
                        Debug.Log("Swipe motion not detected. Keep swiping to catch the fish!");
                    }
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("ball entered trigger");

            if (!fishOnHook && !isThreeTapMode)
            {
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

        private IEnumerator ActivateFishPrompt()
        {
            Debug.Log("Coroutine Started");
            fishOnHookMsg.SetActive(true);
            yield return new WaitForSeconds(2);
            fishOnHookMsg.SetActive(false);
        }

        public void CatchRandomFish()
        {
            int randomIndex = Random.Range(0, availableFish.Length);
            string fishName = availableFish[randomIndex];
            Debug.Log("Random Number selected " + randomIndex);
            Debug.Log("Fish Caught was " + fishName);
            Catch(fishName);
        }

        private void Catch(string fishName)
        {
            Debug.Log("Called Catch()");
            fishInventory.CatchFish(fishName);
        }
    }

}