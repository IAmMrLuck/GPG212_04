using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

namespace ConaLuk
{

    public class RodBehaviour : MonoBehaviour
    {
        [Header("Serialized Fields")]
        [SerializeField] private FishBehaviour fishBehaviourCS;
        [SerializeField] private GameObject fishOnHookMsg;
        [SerializeField] private TMP_Text swipeText;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private AudioSource castSound;

        [Header("String of Fish")]
        public string[] availableFish;

        [Header("Private Fields")]
        private Vector3 _firstPos;
        private Vector3 _lastPos;
        private float _dragDistance;
        private int _swipeCount;


        private void Start()
        {
            fishOnHookMsg.SetActive(false);
        }

        void Update() 
        {
            if (FishBehaviour.isFishChanceMet == true)
            {
                loadingPanel.SetActive(false);

                Debug.Log("Fish is on the hook");
                StartCoroutine(ActivateFishPrompt());
                FishBehaviour.isFishOnHook = true;
                _swipeCount = 10;
                Debug.Log("Press Space to catch the fish!");
                FishBehaviour.isFishChanceMet = false;
            }

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _firstPos = touch.position;
                    _lastPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    _lastPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _lastPos = touch.position;

                    if (Mathf.Abs(_lastPos.x - _firstPos.x) > _dragDistance || Mathf.Abs(_lastPos.y - _firstPos.y) > _dragDistance)
                    {
                        if (Mathf.Abs(_lastPos.x - _firstPos.x) > Mathf.Abs(_lastPos.y - _firstPos.y))
                        {
                            if (_lastPos.x > _firstPos.x)
                            {
                                Debug.Log("Right Swipe");
                            }
                            else
                            {
                                Debug.Log("Left Swipe");
                            }
                        }
                        else
                        {
                            if (_lastPos.y > _firstPos.y)
                            {
                                FishCatcher();
                                Debug.Log("Up Swipe");
                            }
                            else
                            {
                                FishCatcher();
                                Debug.Log("Down Swipe");
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Tap");
                    }
                }
            }
        }

        private void FishCatcher()
        {
            if (FishBehaviour.isFishOnHook && !AccessibilityButton.isAccessibilityMode)
            {
                Debug.Log("Called FishCatcher()");

                _swipeCount--;

                if (_swipeCount == 0)
                {
                    fishBehaviourCS.CatchRandomFish();
                    FishBehaviour.isFishOnHook = false;
                }

                else
                {
                    swipeText.text = $"Keep Reeling it In, only {_swipeCount} to go";
                }
            }
            else
            {
                Debug.Log("no Fish on hook");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (!FishBehaviour.isFishOnHook && !AccessibilityButton.isAccessibilityMode)
            {
                castSound.Play();
                fishBehaviourCS.CheckIsFishCaught();
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
}