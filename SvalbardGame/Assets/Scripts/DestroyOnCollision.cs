using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool onExit;
    public string[] collisionTags;
    void OnTriggerExit(Collider collider)
    {
        if (onExit)
        {
            for (int i = 0; i < collisionTags.Length; i++)
            {
                if (collider.gameObject.tag == collisionTags[i])
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (onExit == false)
        {
            for (int i = 0; i < collisionTags.Length; i++)
            {
                if (collider.gameObject.tag == collisionTags[i])
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
