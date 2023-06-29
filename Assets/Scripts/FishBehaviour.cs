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
    }
}
