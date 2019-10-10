﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    bool isScoring = true;

    int levelScore;
    [SerializeField] int levelScoreDefault = 1000;

    int totalScore = 0;
    int totalScoreTemp;

    int decrementScore = 25;

    private void Awake()
    {
        int otherInstances = FindObjectsOfType<Score>().Length;
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
        InvokeRepeating("DecreaseScore", 10f, 10f);
    }

    private void Update()
    {
        totalScoreTemp = totalScore + levelScore;
    }

    private void DecreaseScore()
    {
        levelScore = Mathf.Clamp(levelScore -= decrementScore,0,levelScoreDefault);
    }

    public void resetParameters()
    {
        totalScore = totalScoreTemp;
        levelScore = levelScoreDefault;
    }

    public int getScore()
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

}