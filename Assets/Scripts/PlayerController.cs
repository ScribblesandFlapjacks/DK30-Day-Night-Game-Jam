using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //cached references
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement.MoveCounterclockwise();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement.MoveClockwise();
        }
    }
}
