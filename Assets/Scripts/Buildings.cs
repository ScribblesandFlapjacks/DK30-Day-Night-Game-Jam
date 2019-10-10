using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    float buildingStageRate = 5f;
    bool isFinishedProducing = false;
    [SerializeField] float buildingHealth = 100;
    int resourcesProductionRate = 10;
    int storedResources = 0;
    int maxVolume = 50;
    float productionRate = 5f;

    //cached references
    Renderer building;
    Resources resources;
    Renderer buildingIndicator;

    bool playerIsHere = false;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().Play();
        resources = FindObjectOfType<Resources>();
        building = GetComponent<Renderer>();
        buildingIndicator = gameObject.transform.Find("BuildingIndicator").GetComponent<Renderer>();
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

        if(storedResources < (int) Mathf.Round(maxVolume/4))
        {
            buildingIndicator.material.color = new Color32(255, 0, 0, 255);
        } else if(storedResources < (int) Mathf.Round(maxVolume/2))
        {
            buildingIndicator.material.color = new Color32(255, 255, 0, 255);
        } else
        {
            buildingIndicator.material.color = new Color32(0, 255, 0, 255);
        }

        if(buildingHealth < 80)
        {
            byte alpha = (byte)Mathf.Clamp(Mathf.Round((3 * buildingHealth)),60f,255f);
            building.material.color = new Color32(255, 255, 255, alpha);
        }

        maxVolume = (int) Mathf.Clamp(Mathf.Round(buildingHealth / 2), 10f, 100f);

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

    public void DamageBuilding(float damage)
    {
        buildingHealth -= damage;
    }
}
