using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    float asteroidFrequency;
    [SerializeField] float asteroidFrequencyDefault;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject explosion;
    List<GameObject> asteroids = new List<GameObject>();

    CircleMath circleMath;

    // Start is called before the first frame update
    void Start()
    {
        asteroidFrequency = Mathf.Clamp(asteroidFrequencyDefault -= 2f * (FindObjectOfType<SessionManager>().GetLevel() - 1), 2f, asteroidFrequencyDefault);
        circleMath = FindObjectOfType<CircleMath>();
        InvokeRepeating("LobAsteroid", 15f, asteroidFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < asteroids.Count; i++)
        {
            AsteroidHit asteroidHit = asteroids[i].GetComponent<AsteroidHit>();
            float currentDistance = asteroidHit.returnStartPosition();
            float speed = asteroidHit.GetSpeed();
            asteroids[i].transform.position = circleMath.CustomCirclePosition(currentDistance - Time.deltaTime * speed,-asteroids[i].transform.rotation.eulerAngles.z);
            asteroids[i].GetComponent<AsteroidHit>().setStartPosition(currentDistance - Time.deltaTime * speed);
            if (currentDistance < circleMath.GetRadius())
            {
                GameObject explosionHolder = Instantiate(explosion, asteroids[i].gameObject.transform.position, asteroids[i].gameObject.transform.rotation);
                Destroy(explosionHolder, 0.3f);
                Destroy(asteroids[i].gameObject);
                asteroids.RemoveAt(i);
            }
        }
    }

    private void LobAsteroid()
    {
        float randomAngle = Random.Range(0f, 360f);
        GameObject tempAsteroid = Instantiate(asteroid, circleMath.CustomCirclePosition(10f, randomAngle), Quaternion.Euler(0,0,randomAngle));
        AsteroidHit asteroidHit = tempAsteroid.GetComponent<AsteroidHit>();
        asteroidHit.setStartPosition(10f);
        asteroidHit.SetSpeed(Random.Range(3f, 5f));
        asteroids.Add(tempAsteroid);
    }
}