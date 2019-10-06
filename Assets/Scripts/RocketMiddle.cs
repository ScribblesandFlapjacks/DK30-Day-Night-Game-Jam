using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMiddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BuildingManager>().RocketMiddlePlaced(gameObject);
        GameObject.Find("BuildingBar/RocketMiddleUIBlock").GetComponent<BuildingUI>().noLongerPlaceable();
    }
}
