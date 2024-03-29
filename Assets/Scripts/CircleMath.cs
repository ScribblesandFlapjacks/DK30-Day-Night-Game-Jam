﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMath : MonoBehaviour
{
    [SerializeField] float circleRadius;

    public Vector2 positionOnCirclePerimeter(float degree)
    {
        float rotationInRadians = Mathf.PI * degree / 180;
        return new Vector2(circleRadius * Mathf.Sin(rotationInRadians), circleRadius * Mathf.Cos(rotationInRadians));
    }

    public Vector2 customCirclePosition(float radius,float degree)
    {
        float rotationInRadians = Mathf.PI * degree / 180;
        return new Vector2(radius * Mathf.Sin(rotationInRadians), radius * Mathf.Cos(rotationInRadians));
    }

    public float getRadius()
    {
        return circleRadius;
    }
}
