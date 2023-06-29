using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityButton : MonoBehaviour
{
    public static bool isAccessibilityMode;
    [SerializeField] private GameObject castButton;
    [SerializeField] private GameObject reelButton;

    private void Start()
    {
        isAccessibilityMode = false;
        castButton.SetActive(false);
        reelButton.SetActive(false);
    }
    public void SetAccessibilityMode()
    {
        isAccessibilityMode = !isAccessibilityMode;
        Debug.Log("Accesibility mode is " + isAccessibilityMode);
    }

    private void Update()
    {
        if(isAccessibilityMode == true)
        {
            castButton.SetActive(true);
            reelButton.SetActive(true);
        }
        else
        {
            castButton.SetActive(false);
            reelButton.SetActive(false);
        }
    }
}
