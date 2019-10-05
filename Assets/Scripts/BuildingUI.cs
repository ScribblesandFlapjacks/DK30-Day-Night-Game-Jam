using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    Resources resources;
    bool buildingUnavailable = false;
    [SerializeField] int buildingCost;

    Transform building;
    Transform background;
    Renderer buildingColor;
    Renderer backgroundColor;

    Color32 unavailableColor = new Color32(165, 175, 175, 100);
    Color32 defaultColor = new Color32(255, 255, 255, 255);
    Color32 unpurchasable = new Color32(255, 0, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        building = gameObject.transform.Find("TestBuilding");
        background = gameObject.transform.Find("BuildingBarBlock");
        buildingColor = building.GetComponent<Renderer>();
        backgroundColor = background.GetComponent<Renderer>();
        resources = FindObjectOfType<Resources>();
        if(resources.GetCurrentResources() < buildingCost)
        {
            buildingUnavailable = true;
            building.GetComponent<Renderer>().material.color = unavailableColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resources.GetCurrentResources() < buildingCost)
        {
            buildingUnavailable = true;
            buildingColor.material.color = unavailableColor;
        } else
        {
            buildingUnavailable = false;
            buildingColor.material.color = defaultColor;
        }
    }

    public bool IsBuildingPurchasable()
    {
        if (buildingUnavailable)
        {
            StartCoroutine(Flash());
            return false;
        } else
        {
            return true;
        }
    }

    IEnumerator Flash()
    {
        backgroundColor.material.color = unpurchasable;
        yield return new WaitForSeconds(.2f);
        backgroundColor.material.color = defaultColor;
    }

    public int GetBuildingCost()
    {
        return buildingCost;
    }
}
