using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    Resources resources;
    bool buildingUnavailable = false;
    [SerializeField] int buildingCost;
    [SerializeField] KeyCode keyCode;
    [SerializeField] GameObject building;
    [SerializeField] GameObject placementBuilding;

    Transform buildingUI;
    Transform background;
    Renderer buildingRenderer;
    Renderer backgroundColor;
    BuildingManager buildingManager;

    bool canPlace = true;

    Color32 unavailableColor = new Color32(165, 175, 175, 100);
    Color32 defaultColor = new Color32(255, 255, 255, 255);
    Color32 unpurchasable = new Color32(255, 0, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        buildingManager = FindObjectOfType<BuildingManager>();
        buildingUI = gameObject.transform.Find("TestBuilding");
        background = gameObject.transform.Find("BuildingBarBlock");
        buildingRenderer = buildingUI.GetComponent<Renderer>();
        backgroundColor = background.GetComponent<Renderer>();
        resources = FindObjectOfType<Resources>();
        if(resources.GetCurrentResources() < buildingCost)
        {
            buildingUnavailable = true;
            buildingRenderer.material.color = unavailableColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlace)
        {
            if (resources.GetCurrentResources() < buildingCost)
            {
                buildingUnavailable = true;
                buildingRenderer.material.color = unavailableColor;
            }
            else
            {
                buildingUnavailable = false;
                buildingRenderer.material.color = defaultColor;
            }
            if (Input.GetKeyDown(keyCode))
            {
                if (IsBuildingPurchasable())
                {
                    buildingManager.BeginBuildingPlacement(buildingCost, placementBuilding, building);
                }
            }
        }
    }

    private bool IsBuildingPurchasable()
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

    public void noLongerPlaceable()
    {
        canPlace = false;
        buildingRenderer.material.color = unavailableColor;
    }
}
