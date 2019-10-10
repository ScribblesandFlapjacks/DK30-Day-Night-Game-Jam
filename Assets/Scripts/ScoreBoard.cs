using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text levelScore;
    [SerializeField] Text totalScore;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        levelScore.text = score.GetLevelScore().ToString();
        totalScore.text = score.GetTotalScore().ToString();
    }
}
