using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    float buildingStageRate = 5f;
    bool isFinishedProducing = false;
    int buildingHealth = 100;
    int resourcesProductionRate = 10;
    int storedResources = 0;
    int maxVolume = 50;
    float productionRate = 5f;

    //cached references
    Renderer building;
    Resources resources;

    bool playerIsHere = false;

    // Start is called before the first frame update
    void Start()
    {
        resources = FindObjectOfType<Resources>();
        building = GetComponent<Renderer>();
        InvokeRepeating("Produce", 0f, productionRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsHere)
        {
            resources.IncreaseResources(storedResources);
            storedResources = 0;
        }

        if(storedResources < 20)
        {
            building.material.color = new Color32(255, 255, 255, 255);
        } else if(storedResources < 40)
        {
            building.material.color = new Color32(0, 150, 255, 255);
        } else if (storedResources == maxVolume)
        {
            building.material.color = new Color32(0, 255, 0, 255);
        }

        if(buildingHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }

    //Changes the building twice at buildingStageRate before beginning resource production
    private void Produce()
    {
        if(storedResources < maxVolume)
        {
            storedResources += resourcesProductionRate;
        }
    }
}
