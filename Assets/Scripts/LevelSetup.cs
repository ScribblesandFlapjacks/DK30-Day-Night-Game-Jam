using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] Text countdownUI;
    [SerializeField] Text planetSizeUI;
    [SerializeField] int countdown = 10;
    [SerializeField] GameObject[] planets;
    [SerializeField] GameObject sunOverlay;
    [SerializeField] GameObject playerAvatar;

    SessionManager sessionManager;
    CircleMath circleMath;

    GameObject planetUI;

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        sessionManager = FindObjectOfType<SessionManager>();
        circleMath = FindObjectOfType<CircleMath>();
        RandomizePlanet();
        StartCoroutine(BeginCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomizePlanet()
    {
        float scale = Random.Range(0.5f, 0.8f);
        GameObject randomPlanet = planets[Random.Range(1, planets.Length)-1];
        Vector3 planetSize = new Vector3(scale, scale, 1);
        Color32 planetColor = Random.ColorHSV(.75f,1f,.75f,1f,.75f,1f,.75f,1f);
        GameObject basePlanet = Instantiate(randomPlanet, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
        basePlanet.GetComponent<Transform>().localScale = planetSize;
        basePlanet.GetComponent<Renderer>().material.color = planetColor;
        planetUI = Instantiate(randomPlanet, new Vector3(6f,-1.5f,0f), Quaternion.Euler(0, 0, 0));
        planetUI.GetComponent<Renderer>().sortingOrder = 31;
        planetUI.GetComponent<Transform>().localScale = planetSize;
        planetUI.GetComponent<Renderer>().material.color = planetColor;
        circleMath.SetRadius(3.5f * scale);
        sunOverlay.GetComponent<Transform>().localScale = new Vector3(scale, 1f, 1f);
        playerAvatar.GetComponent<Transform>().position = new Vector2(0f, 3.5f * scale);
        planetSizeUI.text = "Planet Size: " + System.Math.Round((scale * 3.5f * 2f),2).ToString();
    }

    IEnumerator BeginCountdown()
    {
        for(int i = countdown; i>=0; i--)
        {
            countdownUI.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
            if (i == 1)
            {
                Destroy(gameObject);
                Destroy(planetUI);
                Time.timeScale = 1f;
            }
        }
    }
}
