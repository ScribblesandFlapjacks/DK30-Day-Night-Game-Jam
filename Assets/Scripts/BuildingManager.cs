using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    float circleRadius;
    int buildingCost;
    bool canPlaceBuilding = true;
    
    //cached references
    //[SerializeField] GameObject temporaryBuilding;
    //[SerializeField] GameObject building;
    GameObject placementBuilding;
    GameObject constructionBuilding;
    PlayerMovement playerMovement;
    Resources resources;
    CircleMath circleMath;

    int rocketBuildDelay = 10;
    GameObject rocketBasePlaced;
    GameObject rocketStageTwo;
    GameObject rocketStageThree;
    bool blastOff = false;
    float rocketDistance;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        resources = FindObjectOfType<Resources>();
        circleMath = FindObjectOfType<CircleMath>();
        circleRadius = circleMath.getRadius();
        rocketDistance = circleMath.getRadius();
    }

    private void Update()
    {
        //Adjusts temporaryBuilding's position to match the player avatar
        if(placementBuilding != null)
        {
            //If the player left clicks and there are no building placement conflicts create a building object in the current position and destroy the temporary building
            if (Input.GetKeyDown(KeyCode.Space) && canPlaceBuilding)
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

        if (blastOff && playerMovement.ReadyToFly())
        {
            resetCurrentBuilding();
            Destroy(GameObject.Find("PlayerAvatar"));
            rocketDistance += Time.deltaTime;
            rocketBasePlaced.transform.position = circleMath.customCirclePosition(rocketDistance, -rocketBasePlaced.transform.rotation.eulerAngles.z);
            rocketStageTwo.transform.position = circleMath.customCirclePosition(rocketDistance + .75f, -rocketBasePlaced.transform.rotation.eulerAngles.z);
            rocketStageThree.transform.position = circleMath.customCirclePosition(rocketDistance + 1.5f, -rocketBasePlaced.transform.rotation.eulerAngles.z);
        }
    }

    //Creates a temporaryBuilding for building placement visualization
    public void BeginBuildingPlacement(int cost, GameObject buildingToPlace, GameObject buildingToConstruct)
    {
        resetCurrentBuilding();
        placementBuilding = Instantiate(buildingToPlace, playerMovement.GetCurrentLocation(), playerMovement.GetCurrentRotationQuaternion());
        constructionBuilding = buildingToConstruct;
        buildingCost = cost;
    }

    private void resetCurrentBuilding()
    {
        if(placementBuilding != null)
        {
            Destroy(placementBuilding.gameObject);
        }
        placementBuilding = null;
        constructionBuilding = null;
        buildingCost = 0;
        canPlaceBuilding = true;
    }

    public void CanPlaceBuilding()
    {
        canPlaceBuilding = true;
    }

    public void CantPlaceBuilding()
    {
        canPlaceBuilding = false;
    }

    public void RocketBasePlaced(GameObject rocketBase)
    {
        rocketBasePlaced = rocketBase;
    }

    public void RocketMiddlePlaced(GameObject rocketMiddle)
    {
        rocketStageTwo = rocketMiddle;
    }

    public bool IsRocketMiddlePlaced()
    {
        return rocketStageTwo == null;
    }

    public void RocketTopPlaced(GameObject rocketTop)
    {
        rocketStageThree = rocketTop;
        blastOff = true;
    }

    public int rocketDelay()
    {
        return rocketBuildDelay;
    }

    public bool BlastOffReady()
    {
        return blastOff;
    }
}

