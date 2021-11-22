using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton, exitButton;
    public string nextScene;

    public Image fade;
    public Animator fadeAnim;

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
        StartCoroutine(Fading(nextScene));
    }

    void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator Fading(string nextScene)
    {
        fadeAnim.SetBool("fade", true);
        yield return new WaitUntil(() => fade.color.a == 1);
        SceneManager.LoadScene(nextScene);
    }
}