using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button exitButton, resumeButton;

    void Start()
    {
        resumeButton.onClick.AddListener(ResumeButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
