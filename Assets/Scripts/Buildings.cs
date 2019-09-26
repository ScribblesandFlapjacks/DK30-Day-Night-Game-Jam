using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    float buildingStageRate = 5f;
    bool isFinishedBuilding = false;
    int buildingHealth = 100;
    int resourcesProduces = 10;
    float productionRate = 3f;
    Renderer building;
    Resources resources;

    // Start is called before the first frame update
    void Start()
    {
        resources = FindObjectOfType<Resources>();
        building = GetComponent<Renderer>();
        StartCoroutine(BuildInStages());
    }

    // Update is called once per frame
    void Update()
    {
        if(buildingHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BuildInStages()
    {
        yield return new WaitForSeconds(buildingStageRate);
        building.material.color = new Color32(0, 150, 255, 255);
        yield return new WaitForSeconds(buildingStageRate);
        building.material.color = new Color32(0, 255, 0, 255);
        isFinishedBuilding = true;
        InvokeRepeating("ProduceResources", 0f, productionRate);
    }

    private void ProduceResources()
    {
        resources.IncreaseResources(resourcesProduces);
    }
}
