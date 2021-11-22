using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public string nextScene;

    public Image fade;
    public Animator fadeAnim;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(Fading(nextScene));
        }
    }

    IEnumerator Fading(string nextScene)
    {
        //fade.enabled = true;
        fadeAnim.SetBool("fade", true);
        yield return new WaitUntil(() => fade.color.a == 1);
        SceneManager.LoadScene(nextScene);
    }
}
