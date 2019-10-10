using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{
    [SerializeField] float currentTemperature = 0;
    [SerializeField] float sunIncreaseTemp = 1;
    [SerializeField] float sunDecreaseTemp = 1;
    [SerializeField] Slider thermometer;
    bool isInSun = false;

    PlayerHealth playerHealth;
    AudioSource starside;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        starside = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        //check if collision is with DaylightOverlay
        if (collision.gameObject.layer.Equals(8)) {
            starside.Play();
            isInSun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //check if collision is with DaylightOverlay
        if (collision.gameObject.layer.Equals(8)) {
            starside.Stop();
            isInSun = false;
        }
    }

    private void Update()
    {
        thermometer.value = currentTemperature;
        if(currentTemperature > 30 && currentTemperature < 40)
        {
            playerHealth.DamagePlayer(Time.deltaTime);
        } else if(currentTemperature > 40)
        {
            playerHealth.DamagePlayer(Time.deltaTime*2);
        }
        if(currentTemperature < -30 && currentTemperature > -40)
        {
            playerHealth.DamagePlayer((Time.deltaTime));
        }else if (currentTemperature < -40)
        {
            playerHealth.DamagePlayer(Time.deltaTime * 2);
        }
    }

    private void FixedUpdate() {
        if (isInSun) {
            IncreaseTemperature(sunIncreaseTemp * Time.deltaTime);
            //Debug.Log("Temp is going up " + currentTemperature);
        } else {
            DecreaseTemperature(sunDecreaseTemp * Time.deltaTime);
            //Debug.Log("Temp is decreasing " + currentTemperature);
        }
    }

    public void IncreaseTemperature(float tempToIncreaseBy)
    {
        currentTemperature = Mathf.Clamp(currentTemperature += tempToIncreaseBy,-50,50);
    }

    public void DecreaseTemperature(float tempToDecreaseBy)
    {
        currentTemperature = Mathf.Clamp(currentTemperature -= tempToDecreaseBy,-50,50);
    }

    public float GetCurrentTemperature()
    {
        return currentTemperature;
    }
}
