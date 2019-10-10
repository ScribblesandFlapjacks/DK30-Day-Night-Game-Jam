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
        renderer.material.color = new Color32(255, 0, 0, 150);
        buildingManager.CantPlaceBuilding();
    }

    private void Update()
    {
        if (!touchingRocketBase)
        {
            gameObject.transform.position = circleMath.positionOnCirclePerimeter(playerMovement.GetCurrentRotationDegree());
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()));
        }
        if (touchingRocketBase)
        {
            gameObject.transform.position = circleMath.customCirclePosition(circleMath.getRadius()+1, -rocketBase.transform.rotation.eulerAngles.z);
            gameObject.transform.rotation = rocketBase.transform.rotation;
        }
        if(touchingRocketMiddle)
        {
            gameObject.transform.position = circleMath.customCirclePosition(circleMath.getRadius()+2, -rocketBase.transform.rotation.eulerAngles.z);
            gameObject.transform.rotation = rocketBase.transform.rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RocketPart")
        {
            rocketBase = collision.gameObject;
            touchingRocketBase = true;
        }
        if(collision.gameObject.tag == "RocketPart2")
        {
            touchingRocketMiddle = true;
            buildingManager.CanPlaceBuilding();
            renderer.material.color = new Color32(255, 255, 255, 150);
        }
    }
}
