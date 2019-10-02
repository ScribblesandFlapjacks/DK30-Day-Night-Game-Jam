using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //cached references
    [SerializeField] GameObject playerAvatar;
    Animator animator;
    PlayerMovement playerMovement;
    BuildingUI buildingUI;
    BuildingManager buildingManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = playerAvatar.GetComponent<Animator>();
        playerMovement = playerAvatar.GetComponent<PlayerMovement>();
        //playerMovement = FindObjectOfType<PlayerMovement>();
        buildingUI = FindObjectOfType<BuildingUI>();
        buildingManager = FindObjectOfType<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement.MoveCounterclockwise();
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement.MoveClockwise();
            animator.SetBool("isWalking", true);
        }
        if(!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))){
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (buildingUI.IsBuildingPurchasable())
            {
                buildingManager.BeginBuildingPlacement(buildingUI.GetBuildingCost());
            }
        }
    }
}
