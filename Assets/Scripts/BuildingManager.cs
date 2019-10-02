using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    float circleRadius = 3.8f;
    int buildingCost;
    bool canPlaceBuilding = true;
    
    //cached references
    [SerializeField] GameObject temporaryBuilding;
    [SerializeField] GameObject building;
    GameObject placementBuilding;
    PlayerMovement playerMovement;
    Resources resources;

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
            float rotationInRadians = Mathf.PI * (playerMovement.GetCurrentRotationDegree()) / 180;
            Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
            Vector2 offsetPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
            placementBuilding.transform.position = newPosition;
            placementBuilding.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()+5));
            //If the player left clicks and there are no building placement conflicts create a building object in the current position and destroy the temporary building
            if (Input.GetMouseButtonDown(0) && canPlaceBuilding)
            {
                Instantiate(building, placementBuilding.transform.position, placementBuilding.transform.rotation);
                resources.DecreaseResources(buildingCost);
                Destroy(placementBuilding.gameObject);
                placementBuilding = null;
                buildingCost = 0;
            }
        }
    }

    //Creates a temporaryBuilding for building placement visualization
    public void BeginBuildingPlacement(int cost)
    {
        if(placementBuilding == null)
        {
            placementBuilding = Instantiate(temporaryBuilding, playerMovement.GetCurrentLocation(), playerMovement.GetCurrentRotationQuaternion());
            //placementBuilding.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 100);
            buildingCost = cost;
        }
    }

    public void CanPlaceBuilding()
    {
        canPlaceBuilding = true;
    }

    public void CantPlaceBuilding()
    {
        canPlaceBuilding = false;
    }
}
