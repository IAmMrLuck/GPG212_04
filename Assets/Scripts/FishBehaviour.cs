using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ConaLuk
{
    public class FishBehaviour : MonoBehaviour
    {
        [SerializeField] private FishInventory fishInventory;


        public string[] availableFish;

        //public string[] availableFish = {
        //    "One",
        //    "Two",
        //    "Three"
        //    };
        [SerializeField] private Image nofish;
        public static bool isFishOnHook;
        public static bool isFishChanceMet;
        [SerializeField] private GameObject loadingPanel;

        private void Start()
        {
            loadingPanel.SetActive(false);
            nofish.enabled = false;

        }

        public void CatchRandomFish()
        {
            int randomIndex = Random.Range(0, availableFish.Length);
            string fishName = availableFish[randomIndex];
            Debug.Log("Random Number selected " + randomIndex);
            Debug.Log("Fish Caught was " + fishName);
            isFishOnHook = false;
            Catch(fishName);
        }

        private void Catch(string fishName)
        {
            Debug.Log("Called Catch()");
            fishInventory.CatchFish(fishName);
        }

        public void CheckIsFishCaught()
        {

            // three dot animation
            Debug.Log("checking if caught");

            float fishCatchChance = Random.Range(0f, 5f);
            loadingPanel.SetActive(true);
            if (fishCatchChance < 3.5f)
            {
                Invoke("SetFishBool", 3);
            }   

            else
            {
                Invoke("TurnOffPanel", 3);
                // another way to tell the player they didn't get the fish
                // sad face?
                Debug.Log("Not even a nibble!");
            }
        }

        private void SetFishBool()
        {
            isFishChanceMet = true;
        }

        private void TurnOffPanel()
        {
            loadingPanel.SetActive(false);
            nofish.enabled = true;
            Invoke("TurnOffNofish", 2);
        }

        private void TurnOffNofish()
        {
            nofish.enabled = false;

        }
    }
}
