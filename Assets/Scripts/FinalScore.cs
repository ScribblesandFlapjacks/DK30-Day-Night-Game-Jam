using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] Text finalLevel;
    [SerializeField] Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        Score score = FindObjectOfType<Score>();
        finalLevel.text = "You Died On Level: " + score.GetLevel();
        finalScore.text = "Final Score: " + score.getScore().ToString();
    }
}
