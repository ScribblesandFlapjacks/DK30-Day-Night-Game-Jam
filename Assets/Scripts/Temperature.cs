using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    [SerializeField] int currentTemperature = 0;

    public void IncreaseTemperature(int tempToIncreaseBy)
    {
        currentTemperature += tempToIncreaseBy;
    }

    public void DecreaseTemperature(int tempToDecreaseBy)
    {
        currentTemperature -= tempToDecreaseBy;
    }

    public int GetCurrentTemperature()
    {
        return currentTemperature;
    }
}
