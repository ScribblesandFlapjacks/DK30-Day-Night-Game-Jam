using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    bool isScoring = true;

    int levelScore;
    [SerializeField] int levelScoreDefault = 1000;

    int totalScore = 0;
    int totalScoreTemp;

    int decrementScore = 25;

    int level = 1;

    private void Awake()
    {
        int otherInstances = FindObjectsOfType<SessionManager>().Length;
        if(otherInstances > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        levelScore = levelScoreDefault;
        totalScoreTemp = totalScore + levelScore;
    }

    private void Update()
    {
        totalScoreTemp = totalScore + levelScore;
    }

    private void DecreaseScore()
    {
        levelScore = Mathf.Clamp(levelScore -= decrementScore,0,levelScoreDefault);
    }

    public void BeginScoring()
    {
        InvokeRepeating("DecreaseScore", 10f, 10f);
    }

    public void PauseScoring()
    {
        CancelInvoke();
    }

    public void NextLevel()
    {
        totalScore = totalScoreTemp;
        levelScore = levelScoreDefault;
        level += 1;
    }

    public void FinalResults()
    {
        totalScore = totalScoreTemp;
    }

    public int GetScore()
    {
        return totalScore;
    }

    public int GetLevelScore()
    {
        return levelScore;
    }

    public int GetTotalScore()
    {
        return totalScoreTemp;
    }

    public int GetLevel()
    {
        return level;
    }

}