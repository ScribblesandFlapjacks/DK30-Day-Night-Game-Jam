using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    float startPosition;
    int asteroidDamageOnHit = 20;

    float velocity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Building")
        {
            collision.gameObject.GetComponent<Buildings>().DamageBuilding(asteroidDamageOnHit);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(asteroidDamageOnHit);
        }
    }

    public void setStartPosition(float position)
    {
        startPosition = position;
    }

    public void SetSpeed(float speed)
    {
        velocity = speed;
    }

    public float GetSpeed()
    {
        return velocity;
    }

    public float returnStartPosition()
    {
        return startPosition;
    }
}
