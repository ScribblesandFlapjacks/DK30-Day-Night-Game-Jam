using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 100;
    StartMenu startMenu;

    private void Start()
    {
        startMenu = FindObjectOfType<StartMenu>();
    }

    private void Update()
    {
        if(playerHealth < 1)
        {
            startMenu.ChangeSceneTo(3);
        }
    }
    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
    }
}