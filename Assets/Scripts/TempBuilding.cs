using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBuilding : MonoBehaviour
{
    //cached references
    Renderer renderer;
    BuildingManager buildingManager;

    int numberOfCollisions = 0;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        buildingManager = FindObjectOfType<BuildingManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Building")
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
            if(numberOfCollisions == 0)
            {
                renderer.material.color = new Color32(255, 255, 255, 150);
                buildingManager.CanPlaceBuilding();
            }
        }
    }
}
