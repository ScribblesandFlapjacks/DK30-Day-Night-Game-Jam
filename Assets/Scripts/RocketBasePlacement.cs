using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBasePlacement : MonoBehaviour
{
    //cached references
    Renderer renderer;
    BuildingManager buildingManager;
    PlayerMovement playerMovement;
    CircleMath circleMath;

    int numberOfCollisions = 0;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        buildingManager = FindObjectOfType<BuildingManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        circleMath = FindObjectOfType<CircleMath>();
    }

    private void Update()
    {
        gameObject.transform.position = circleMath.PositionOnCirclePerimeter(playerMovement.GetCurrentRotationDegree());
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -(playerMovement.GetCurrentRotationDegree()));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            numberOfCollisions++;
            renderer.material.color = new Color32(255, 0, 0, 150);
            buildingManager.CantPlaceBuilding();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            numberOfCollisions--;
            if (numberOfCollisions == 0)
            {
                renderer.material.color = new Color32(255, 255, 255, 150);
                buildingManager.CanPlaceBuilding();
            }
        }
    }
}
