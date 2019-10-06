using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BuildingManager>().RocketTopPlaced(gameObject);
        GameObject.Find("BuildingBar/RocketTopUIBlock").GetComponent<BuildingUI>().noLongerPlaceable();
    }
}