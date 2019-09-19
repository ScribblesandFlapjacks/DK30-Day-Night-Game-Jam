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
        //Debug.Log(currentRotation);
        float rotationInRadians = Mathf.PI * currentRotation / 180;
        Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
    }

    public void MoveClockwise()
    {
        currentRotation++;
        //Debug.Log(currentRotation);
        float rotationInRadians = Mathf.PI * currentRotation / 180;
        Vector2 newPosition = new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
    }
}
