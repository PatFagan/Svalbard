using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton, exitButton;
    public string nextScene;

    void Start()
    {
        startButton.onClick.AddListener(StartButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartButton();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }

    void StartButton()
    {
        SceneManager.LoadScene(nextScene);
    }

    void ExitButton()
    {
        Application.Quit();
    }
}