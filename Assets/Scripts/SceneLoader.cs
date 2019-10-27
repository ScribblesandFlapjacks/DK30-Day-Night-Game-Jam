using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    SessionManager sessionManager;

    private void Start()
    {
        sessionManager = FindObjectOfType<SessionManager>();
    }
    public void ChangeSceneTo(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartGame()
    {
        Destroy(sessionManager);
        SceneManager.LoadScene(2);
    }

    public void nextLevel()
    {
        sessionManager.NextLevel();
        SceneManager.LoadScene(2);
    }

    public void endScreen()
    {
        sessionManager.FinalResults();
        SceneManager.LoadScene(3);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
