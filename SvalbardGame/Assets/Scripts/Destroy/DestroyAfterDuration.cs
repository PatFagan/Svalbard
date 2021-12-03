using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDuration : MonoBehaviour
{
    public float lifespan;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
