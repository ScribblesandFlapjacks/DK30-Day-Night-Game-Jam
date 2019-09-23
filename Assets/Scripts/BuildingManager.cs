using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] Buildings buildings;
    Buildings placementBuilding;
    float circleRadius = 3.8f;
    int buildingCost;

    PlayerMovement playerMovement;
    Resources resources;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        resources = FindObjectOfType<Resources>();
    }

    private void Update()
    {
        if(placementBuilding != null)
        {
            float rotationInRadians = Mathf.PI * (playerMovement.GetCurrentRotationDegree() + 5) / 180;
            Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
            placementBuilding.transform.position = newPosition;
            placementBuilding.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()+5));
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(buildings, placementBuilding.transform.position, placementBuilding.transform.rotation);
                resources.DecreaseResources(buildingCost);
                Destroy(placementBuilding.gameObject);
                placementBuilding = null;
                buildingCost = 0;
            }
        }
    }

    public void BeginBuildingPlacement(int cost)
    {
        placementBuilding = Instantiate(buildings, playerMovement.GetCurrentLocation(), playerMovement.GetCurrentRotationQuaternion());
        placementBuilding.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 100);
        buildingCost = cost;
    }
}
