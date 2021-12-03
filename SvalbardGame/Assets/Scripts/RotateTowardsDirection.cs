using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsDirection : MonoBehaviour
{
    bool calculateEnabled;
    public Vector3 moveDirection;

    void Start()
    {
        calculateEnabled = true;
    }

    void FixedUpdate()
    {
        if (calculateEnabled)
            StartCoroutine(CalculateRotation());
    }

    IEnumerator CalculateRotation()
    {
        Vector3 oldPosition = transform.position;
        yield return new WaitForSeconds(.01f);
        moveDirection = transform.position - oldPosition;
        //print(moveDirection);
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        calculateEnabled = true;
    }
}