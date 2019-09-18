using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] int currentResources = 0;

    public void IncreaseResources(int resourcesToIncreaseBy)
    {
        currentResources += resourcesToIncreaseBy;
    }

    public void DecreaseResources(int resourcesToDecreaseBy)
    {
        currentResources -= resourcesToDecreaseBy;
    }

    public int GetCurrentResources()
    {
        return currentResources;
    }
}
