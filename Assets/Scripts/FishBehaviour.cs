using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

        public static bool isFishOnHook;
        public static bool isFishChanceMet;

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

            if (fishCatchChance < 3.5f)
            {
                Invoke("SetFishBool", 3);
            }   

            else
            {
                Debug.Log("Not even a nibble!");
            }
        }

        public void SetFishBool()
        {
            isFishChanceMet = true;
        }
    }
}
