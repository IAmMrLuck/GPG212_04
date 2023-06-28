using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject helpButton;
    [SerializeField] private GameObject helpPanel;

    void Start()
    {
        startButton.SetActive(false);
        helpButton.SetActive(false);
        helpPanel.SetActive(false);
        Invoke("LoadButtons", 2.5f);
    }

    public void LoadButtons()
    {
        startButton.SetActive(true);
        helpButton.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("FishingScene");
    }

    public void LoadHelp()
    {
        helpPanel.SetActive(true);
    }

}
