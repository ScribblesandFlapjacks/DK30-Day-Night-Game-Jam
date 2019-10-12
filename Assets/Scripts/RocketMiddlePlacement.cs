using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMiddlePlacement : MonoBehaviour
{
    //cached references
    Renderer renderer;
    BuildingManager buildingManager;
    PlayerMovement playerMovement;
    CircleMath circleMath;

    GameObject rocketBase;

    bool touchingRocketBase = false;

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
            gameObject.transform.position = circleMath.positionOnCirclePerimeter(playerMovement.GetCurrentRotationDegree());
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()));
        } else
        {
            gameObject.transform.position = circleMath.customCirclePosition(circleMath.getRadius() + .75f, -rocketBase.transform.rotation.eulerAngles.z);
            gameObject.transform.rotation = rocketBase.transform.rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RocketPart")
        {
            rocketBase = collision.gameObject;
            touchingRocketBase = true;
            buildingManager.CanPlaceBuilding();
            renderer.material.color = new Color32(255, 255, 255, 180);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RocketPart")
        {
            rocketBase = null;
            touchingRocketBase = false;
            buildingManager.CantPlaceBuilding();
            renderer.material.color = new Color32(255, 0, 0, 180);
        }
    }
}
