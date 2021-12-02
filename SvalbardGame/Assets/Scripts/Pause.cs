using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button exitButton, resumeButton;
    bool pauseBool = false;

    void Start()
    {
        resumeButton.onClick.AddListener(ResumeButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseBool = !pauseBool;
            pauseMenu.SetActive(pauseBool);
            Time.timeScale = 0f;
        }
    }

    public void ResumeButton()
    {
        pauseBool = false;
        pauseMenu.SetActive(pauseBool); 
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
