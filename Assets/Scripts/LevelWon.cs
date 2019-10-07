using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    StartMenu startMenu;

    private void Start()
    {
        startMenu = FindObjectOfType<StartMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RocketPart")
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4);
        startMenu.ChangeSceneTo(2);
    }
}
