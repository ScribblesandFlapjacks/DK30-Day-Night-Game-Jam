using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    [SerializeField] int currentResources = 0;
    [SerializeField] Text currentResourcesUI;

    private void Start()
    {
        currentResourcesUI.text = "Ore: " + currentResources.ToString();
    }

    public void IncreaseResources(int resourcesToIncreaseBy)
    {
        currentResources += resourcesToIncreaseBy;
        currentResourcesUI.text = "Ore: " + currentResources.ToString();
    }

    public void DecreaseResources(int resourcesToDecreaseBy)
    {
        currentResources -= resourcesToDecreaseBy;
        currentResourcesUI.text = "Ore: " + currentResources.ToString();
    }

    public int GetCurrentResources()
    {
        return currentResources;
    }
}
