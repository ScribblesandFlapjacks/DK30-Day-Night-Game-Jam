using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    float asteroidFrequency;
    [SerializeField] float asteroidFrequencyDefault;
    [SerializeField] GameObject asteroid;
    List<GameObject> asteroids = new List<GameObject>();

    CircleMath circleMath;

    private void Awake()
    {
        int otherInstances = FindObjectsOfType<AsteroidController>().Length;
        if(otherInstances > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        asteroidFrequency = asteroidFrequencyDefault;
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
            asteroids[i].transform.position = circleMath.customCirclePosition(currentDistance - Time.deltaTime * speed,-asteroids[i].transform.rotation.eulerAngles.z);
            asteroids[i].GetComponent<AsteroidHit>().setStartPosition(currentDistance - Time.deltaTime * speed);
            if (currentDistance < circleMath.getRadius())
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
        AsteroidHit asteroidHit = tempAsteroid.GetComponent<AsteroidHit>();
        asteroidHit.setStartPosition(10f);
        asteroidHit.SetSpeed(Random.Range(3f, 5f));
        asteroids.Add(tempAsteroid);
    }

    public void IncreaseDifficulty()
    {
        asteroidFrequency = Mathf.Clamp(asteroidFrequency -= 2f,0,20);
    }
}