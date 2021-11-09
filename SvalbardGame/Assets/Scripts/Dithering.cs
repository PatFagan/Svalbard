using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dithering : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    IEnumerator FadeOut()
    {
        for (int i = 0; i < 100; i++)
        {
            spriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime);
            yield return new WaitForSeconds(.005f);
        }
    }

    IEnumerator FadeIn()
    {
        for (int i = 0; i < 100; i++)
        {
            spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime);
            yield return new WaitForSeconds(.005f);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(FadeOut());
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(FadeIn());
        }
    }
}