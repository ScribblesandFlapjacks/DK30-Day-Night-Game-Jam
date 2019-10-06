using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    float circleRadius = 3.8f;
    int buildingCost;
    bool canPlaceBuilding = true;
    
    //cached references
    //[SerializeField] GameObject temporaryBuilding;
    //[SerializeField] GameObject building;
    GameObject placementBuilding;
    GameObject constructionBuilding;
    PlayerMovement playerMovement;
    Resources resources;

    bool rocketBasePlaced = false;
    bool rocketStageTwo = false;
    bool rocketStageThree = false;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        resources = FindObjectOfType<Resources>();
    }

    private void Update()
    {
        //Adjusts temporaryBuilding's position to match the player avatar
        if(placementBuilding != null)
        {
            //If the player left clicks and there are no building placement conflicts create a building object in the current position and destroy the temporary building
            if (Input.GetMouseButtonDown(0) && canPlaceBuilding)
            {
                Instantiate(constructionBuilding, placementBuilding.transform.position, placementBuilding.transform.rotation);
                resources.DecreaseResources(buildingCost);
                resetCurrentBuilding();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                resetCurrentBuilding();
            }
        }
    }

    //Creates a temporaryBuilding for building placement visualization
    public void BeginBuildingPlacement(int cost, GameObject buildingToPlace, GameObject buildingToConstruct)
    {
        if(placementBuilding == null)
        {
            placementBuilding = Instantiate(buildingToPlace, playerMovement.GetCurrentLocation(), playerMovement.GetCurrentRotationQuaternion());
            //placementBuilding.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 100);
            constructionBuilding = buildingToConstruct;
            buildingCost = cost;
        }
    }

    private void resetCurrentBuilding()
    {
        Destroy(placementBuilding.gameObject);
        placementBuilding = null;
        constructionBuilding = null;
        buildingCost = 0;
    }

    public void CanPlaceBuilding()
    {
        canPlaceBuilding = true;
    }

    public void CantPlaceBuilding()
    {
        canPlaceBuilding = false;
    }

    public void RocketBasePlaced()
    {
        rocketBasePlaced = true;
    }

    public void RocketMiddlePlaced()
    {
        rocketStageTwo = true;
    }

    public void RocketTopPlaced()
    {
        rocketStageThree = true;
    }
}

