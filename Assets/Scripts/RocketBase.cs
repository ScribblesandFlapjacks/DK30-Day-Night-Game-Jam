using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BuildingManager>().RocketBasePlaced(gameObject);
        GameObject.Find("BuildingBar/RocketBottomUIBlock").GetComponent<BuildingUI>().noLongerPlaceable();
    }
}
