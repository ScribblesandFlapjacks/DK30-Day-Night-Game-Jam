using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    float asteroidFrequency = 6f;
    float asteroidSpeed = 5f;
    [SerializeField] GameObject asteroid;
    List<GameObject> asteroids = new List<GameObject>();

    CircleMath circleMath;
    // Start is called before the first frame update
    void Start()
    {
        circleMath = FindObjectOfType<CircleMath>();
        asteroidFrequency -= 5f;
        InvokeRepeating("LobAsteroid", 5f, asteroidFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < asteroids.Count; i++)
        {
            Debug.Log("Yup");
            float currentDistance = asteroids[i].GetComponent<AsteroidHit>().returnStartPosition();
            asteroids[i].transform.position = circleMath.customCirclePosition(currentDistance - Time.deltaTime * asteroidSpeed,-asteroids[i].transform.rotation.eulerAngles.z);
            asteroids[i].GetComponent<AsteroidHit>().setStartPosition(currentDistance - Time.deltaTime * asteroidSpeed);
            if (currentDistance < 3.5)
            {
                Destroy(asteroids[i].gameObject);
                asteroids.RemoveAt(i);
            }
        }
    }

    private void LobAsteroid()
    {
        float randomAngle = Random.Range(0f, 360f);
        GameObject tempAsteroid = Instantiate(asteroid, circleMath.customCirclePosition(10f, randomAngle), Quaternion.Euler(0,0,randomAngle));
        tempAsteroid.GetComponent<AsteroidHit>().setStartPosition(10f);
        asteroids.Add(tempAsteroid);
    }
}
