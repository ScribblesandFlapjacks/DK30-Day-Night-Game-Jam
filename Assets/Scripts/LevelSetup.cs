using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] Text countdownUI;
    [SerializeField] Text planetSizeUI;
    [SerializeField] Text[] mutationDescriptors;
    [SerializeField] int countdown = 10;
    [SerializeField] GameObject[] planets;
    [SerializeField] GameObject[] sunOverlays;
    [SerializeField] GameObject[] buildingBarBlocks;
    [SerializeField] GameObject[] rocketUI;
    [SerializeField] GameObject playerAvatar;
    [SerializeField] GameObject tunnel;

    SessionManager sessionManager;
    CircleMath circleMath;

    GameObject planetUI;
    int buildingBarCurrentPosition = 1;

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
        RandomizeSun();
        if(Random.Range(0,4) >= 3)
        {
            PlaceTunnels();
        }
        RocketUI();
        StartCoroutine(BeginCountdown());
    }

    private void RandomizePlanet()
    {
        float scale = Random.Range(0.5f, 0.8f);
        GameObject randomPlanet = planets[Random.Range(1, planets.Length)-1];
        Vector3 planetSize = new Vector3(scale, scale, 1);
        Color32 planetColor = Random.ColorHSV(.1f,1f,.75f,1f,.75f,1f,.75f,1f);
        GameObject basePlanet = Instantiate(randomPlanet, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
        basePlanet.GetComponent<Transform>().localScale = planetSize;
        basePlanet.GetComponent<Renderer>().material.color = planetColor;
        planetUI = Instantiate(randomPlanet, new Vector3(2f,-1.5f,0f), Quaternion.Euler(0, 0, 0));
        planetUI.GetComponent<Renderer>().sortingOrder = 31;
        planetUI.GetComponent<Transform>().localScale = planetSize;
        planetUI.GetComponent<Renderer>().material.color = planetColor;
        circleMath.SetRadius(3.5f * scale);
        sunOverlays[0].transform.Find("PlanetCenter/DaylightOverlay").GetComponent<Transform>().localScale = new Vector3(scale, 1f, 1f);
        playerAvatar.GetComponent<Transform>().position = new Vector2(0f, 3.5f * scale);
        planetSizeUI.text = "Planet Size: " + System.Math.Round((scale * 3.5f * 2f),2).ToString();
    }

    private void RandomizeSun()
    {
        int randomSun = Random.Range(0, sunOverlays.Length);
        if(randomSun < 2)
        {
            sunOverlays[0].gameObject.SetActive(true);
        }
        else
        {
            sunOverlays[randomSun - 1].gameObject.SetActive(true);
            Instantiate(buildingBarBlocks[randomSun - 2], new Vector3(buildingBarCurrentPosition, -3.2f, 0f), Quaternion.Euler(0, 0, 0));
            buildingBarCurrentPosition += 1;
        }
    }

    private void PlaceTunnels()
    {
        float tunnelOneRotation = Random.Range(0f, 360f);
        float tunnelTwoRotation = Random.Range(tunnelOneRotation + 90f, 360f + tunnelOneRotation-90f);
        GameObject tunnelOne = Instantiate(tunnel, circleMath.CustomCirclePosition(circleMath.GetRadius(), tunnelOneRotation), Quaternion.Euler(0, 0, -tunnelOneRotation));
        GameObject tunnelTwo = Instantiate(tunnel, circleMath.CustomCirclePosition(circleMath.GetRadius(), tunnelTwoRotation), Quaternion.Euler(0, 0, -tunnelTwoRotation));
        tunnelOne.GetComponent<Tunnel>().SetTunnelLink(tunnelTwo);
        tunnelOne.GetComponent<Tunnel>().SetRotation(tunnelOneRotation);
        tunnelTwo.GetComponent<Tunnel>().SetTunnelLink(tunnelOne);
        if(tunnelTwoRotation > 360f)
        {
            tunnelTwo.GetComponent<Tunnel>().SetRotation(tunnelTwoRotation - 360f);
        } else
        {
            tunnelTwo.GetComponent<Tunnel>().SetRotation(tunnelTwoRotation);
        }
        SetMutationDescriptor("There are tunnels");
    }

    private void SetMutationDescriptor(string descriptor)
    {
        for(int i = 0; i < mutationDescriptors.Length; i++)
        {
            if(mutationDescriptors[i].text == "")
            {
                mutationDescriptors[i].text = descriptor;
                break;
            }
        }
    }

    private void RocketUI()
    {
        for(int i = 0; i < rocketUI.Length; i++)
        {
            Instantiate(rocketUI[i], new Vector3(buildingBarCurrentPosition, -3.2f, 0f), Quaternion.Euler(0, 0, 0));
            buildingBarCurrentPosition += 1;
        }
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
                playerAvatar.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}