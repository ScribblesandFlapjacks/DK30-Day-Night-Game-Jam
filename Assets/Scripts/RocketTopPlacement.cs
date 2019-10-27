using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTopPlacement : MonoBehaviour
{
    //cached references
    Renderer renderer;
    BuildingManager buildingManager;
    PlayerMovement playerMovement;
    CircleMath circleMath;

    GameObject rocketBase;

    bool touchingRocketBase = false;
    bool touchingRocketMiddle = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        buildingManager = FindObjectOfType<BuildingManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        circleMath = FindObjectOfType<CircleMath>();
        renderer.material.color = new Color32(255, 0, 0, 180);
        buildingManager.CantPlaceBuilding();
    }

    private void Update()
    {
        if (!touchingRocketBase)
        {
            gameObject.transform.position = circleMath.PositionOnCirclePerimeter(playerMovement.GetCurrentRotationDegree());
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()));
        }
        if (touchingRocketBase)
        {
            if (!buildingManager.IsRocketMiddlePlaced())
            {
                gameObject.transform.position = circleMath.CustomCirclePosition(circleMath.GetRadius() + 1.5f, -rocketBase.transform.rotation.eulerAngles.z);
                gameObject.transform.rotation = rocketBase.transform.rotation;
                buildingManager.CanPlaceBuilding();
            } else
            {
                gameObject.transform.position = circleMath.PositionOnCirclePerimeter(playerMovement.GetCurrentRotationDegree());
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RocketPart")
        {
            rocketBase = collision.gameObject;
            touchingRocketBase = true;
        }
    }
}