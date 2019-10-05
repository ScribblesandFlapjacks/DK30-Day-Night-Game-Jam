using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    float currentRotation = 0.0f;
    [SerializeField]
    float rotationSpeed = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Sun Trigger Entered");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        if (currentRotation > 360) {
            currentRotation -= 360;
        }
    }
}
