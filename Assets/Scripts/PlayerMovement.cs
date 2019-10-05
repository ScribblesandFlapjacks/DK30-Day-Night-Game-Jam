using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 50;
    float currentRotation = 0;
    float circleRadius = 3.5f;

    CircleMath circleMath;

    private void Start()
    {
        circleMath = FindObjectOfType<CircleMath>();
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
}
