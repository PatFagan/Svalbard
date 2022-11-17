using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    ParticleSystem m_particleSystem;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        ParticleSystem.ShapeModule _editableShape = m_particleSystem.shape;
        _editableShape.position = player.transform.position + offset;
    }
}
