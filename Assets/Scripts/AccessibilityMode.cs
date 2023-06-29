using System.Collections;
using UnityEngine;
using TMPro;

namespace ConaLuk
{

    public class AccessibilityMode : MonoBehaviour
    {
        [SerializeField] private GameObject fishOnHookMsg;
        [SerializeField] private FishBehaviour fishBehaviourCS;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private TMP_Text reelItIn;

        private int _reelButtonPressCount;

        private void Start()
        {
            FishBehaviour.isFishOnHook = false;
            fishOnHookMsg.SetActive(false);
        }

        private void Update()
        {
            if (FishBehaviour.isFishChanceMet == true)
            {
                loadingPanel.SetActive(false);
                Debug.Log("Fish is on the hook");
                StartCoroutine(ActivateFishPrompt());
                FishBehaviour.isFishOnHook = true;
                _reelButtonPressCount = 10;
                Debug.Log("Press Space to catch the fish!");
                FishBehaviour.isFishChanceMet = false;
            }
        }

        public void MashReelButton()
        {
            if (FishBehaviour.isFishOnHook && AccessibilityButton.isAccessibilityMode)
            {
                _reelButtonPressCount--;
                if (_reelButtonPressCount <= 0)
                {
                    Debug.Log("Congratulations! You caught the fish!");
                    fishBehaviourCS.CatchRandomFish();
                    reelItIn.text = null;
                }

                else
                {
                    reelItIn.text = $"Keep Reeling it In, only {_reelButtonPressCount} to go";
                    
                    Debug.Log(string.Format("Press Space {0} more time(s) to catch the fish.", 10 - _reelButtonPressCount));
                }
            }
        }

        private void CastRod()
        {
            if (!FishBehaviour.isFishOnHook && AccessibilityButton.isAccessibilityMode)
            {
                fishBehaviourCS.CheckIsFishCaught();              
            }
        }

        private IEnumerator ActivateFishPrompt() //move this to seperate script
        {
            Debug.Log("Coroutine Started");
            fishOnHookMsg.SetActive(true);
            yield return new WaitForSeconds(2);
            fishOnHookMsg.SetActive(false);
        }

        
    }
}