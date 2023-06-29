using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityButton : MonoBehaviour
{
    public static bool isAccessibilityMode;

    private void Start()
    {
        isAccessibilityMode = false;
    }
    public void SetAccessibilityMode()
    {
        isAccessibilityMode = !isAccessibilityMode;
        Debug.Log("Accesibility mode is " + isAccessibilityMode);
    }
}
