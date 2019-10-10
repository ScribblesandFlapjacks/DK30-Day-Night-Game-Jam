using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text healthUI;
    float playerHealth = 100;
    StartMenu startMenu;

    private void Start()
    {
        startMenu = FindObjectOfType<StartMenu>();
    }

    private void Update()
    {
        healthUI.text = Mathf.RoundToInt(playerHealth).ToString();
        if(playerHealth < 1)
        {
            startMenu.endScreen();
        }
    }
    public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
    }
}