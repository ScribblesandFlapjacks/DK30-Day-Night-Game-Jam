using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //cached references
    PlayerMovement playerMovement;
    BuildingUI buildingUI;
    BuildingManager buildingManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        buildingUI = FindObjectOfType<BuildingUI>();
        buildingManager = FindObjectOfType<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement.MoveCounterclockwise();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement.MoveClockwise();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (buildingUI.IsBuildingPurchasable())
            {
                buildingManager.BeginBuildingPlacement(buildingUI.GetBuildingCost());
            }
        }
    }
}
