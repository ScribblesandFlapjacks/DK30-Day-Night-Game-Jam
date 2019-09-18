using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    public void IncreaseScore(int scoreToIncreaseBy)
    {
        currentScore += scoreToIncreaseBy;
    }

    public void DecreaseScore(int scoreToDecreaseBy)
    {
        currentScore -= scoreToDecreaseBy;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
