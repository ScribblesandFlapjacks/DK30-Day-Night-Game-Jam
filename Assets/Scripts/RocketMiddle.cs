using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMiddle : MonoBehaviour
{
    BuildingManager buildingManager;
    // Start is called before the first frame update
    void Start()
    {
        buildingManager = FindObjectOfType<BuildingManager>();
        StartCoroutine(BuildTime());
    }

    private IEnumerator BuildTime()
    {
        GameObject.Find("RocketMiddleUIBlock(Clone)").GetComponent<BuildingUI>().noLongerPlaceable();
        gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 150);
        yield return new WaitForSeconds(buildingManager.rocketDelay());
        gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        gameObject.tag = "RocketPart2";
        buildingManager.RocketMiddlePlaced(gameObject);
    }
}
