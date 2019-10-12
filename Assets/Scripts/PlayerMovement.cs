using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 50;
    float currentRotation = 0;
    bool nextToRocket = false;
    bool readyToFly = false;

    BuildingManager buildingManager;

    CircleMath circleMath;

    private void Start()
    {
        circleMath = FindObjectOfType<CircleMath>();
        buildingManager = FindObjectOfType<BuildingManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nextToRocket && buildingManager.BlastOffReady())
        {
            readyToFly = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RocketPart")
        {
            nextToRocket = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RocketPart")
        {
            nextToRocket = false;
        }
    }
    public void MoveCounterclockwise()
    {
        currentRotation -= Time.deltaTime * playerSpeed;
        transform.position = circleMath.positionOnCirclePerimeter(currentRotation);
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        GetComponent<SpriteRenderer>().flipX = false;
    }

    public void MoveClockwise()
    {
        currentRotation += Time.deltaTime * playerSpeed;
        transform.position = circleMath.positionOnCirclePerimeter(currentRotation);
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        GetComponent<SpriteRenderer>().flipX = true;
    }

    public Vector2 GetCurrentLocation()
    {
        return transform.position;
    }

    public float GetCurrentRotationDegree()
    {
        return currentRotation;
    }

    public Quaternion GetCurrentRotationQuaternion()
    {
        return transform.rotation;
    }

    public bool ReadyToFly()
    {
        return readyToFly;
    }
}
