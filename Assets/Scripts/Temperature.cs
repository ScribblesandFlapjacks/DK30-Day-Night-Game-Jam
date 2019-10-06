using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    [SerializeField] float currentTemperature = 0;
    [SerializeField] float sunIncreaseTemp = 20;
    [SerializeField] float sunDecreaseTemp = 15;
    bool isInSun = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        //check if collision is with DaylightOverlay
        if (collision.gameObject.layer.Equals(8)) {
            isInSun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //check if collision is with DaylightOverlay
        if (collision.gameObject.layer.Equals(8)) {
            isInSun = false;
        }
    }

    private void FixedUpdate() {
        if (isInSun) {
            IncreaseTemperature(sunIncreaseTemp * Time.deltaTime);
        } else {
            DecreaseTemperature(sunDecreaseTemp * Time.deltaTime);
        }
    }

    public void IncreaseTemperature(float tempToIncreaseBy)
    {
        currentTemperature += tempToIncreaseBy;
    }

    public void DecreaseTemperature(float tempToDecreaseBy)
    {
        currentTemperature -= tempToDecreaseBy;
    }

    public float GetCurrentTemperature()
    {
        return currentTemperature;
    }
}
