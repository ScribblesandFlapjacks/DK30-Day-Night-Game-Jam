using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    AsteroidController asteroidController;
    Score score;

    private void Start()
    {
        asteroidController = FindObjectOfType<AsteroidController>();
        score = FindObjectOfType<Score>();
    }
    public void ChangeSceneTo(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartGame()
    {
        Destroy(score);
        SceneManager.LoadScene(2);
    }

    public void nextLevel()
    {
        asteroidController.IncreaseDifficulty();
        score.resetParameters();
        SceneManager.LoadScene(2);
    }

    public void endScreen()
    {
        Destroy(asteroidController);
        score.resetParameters();
        SceneManager.LoadScene(3);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
