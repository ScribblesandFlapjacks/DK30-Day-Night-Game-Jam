using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 origin = new Vector2(0, 0);
    int currentRotation = 0;
    float circleRadius = 3.5f;
    public void MoveCounterclockwise()
    {
        currentRotation--;
        float rotationInRadians = Mathf.PI * currentRotation / 180;
        Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        GetComponent<SpriteRenderer>().flipX = true;
    }

    public void MoveClockwise()
    {
        currentRotation++;
        float rotationInRadians = Mathf.PI * currentRotation / 180;
        Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        GetComponent<SpriteRenderer>().flipX = false;
    }

    public Vector2 GetCurrentLocation()
    {
        return transform.position;
    }

    public int GetCurrentRotationDegree()
    {
        return currentRotation;
    }

    public Quaternion GetCurrentRotationQuaternion()
    {
        return transform.rotation;
    }
}
