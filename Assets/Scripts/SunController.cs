using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    float currentRotation = 0.0f;
    [SerializeField] bool rotates = true;
    [SerializeField]
    float rotationSpeed = 1.0f;
    float buildingDamageRate = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (rotates)
        {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            if (currentRotation > 360)
            {
                currentRotation -= 360;
            }
        }
    }
}