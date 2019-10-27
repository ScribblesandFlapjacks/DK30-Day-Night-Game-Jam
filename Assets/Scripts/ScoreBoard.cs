using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text levelScore;
    [SerializeField] Text totalScore;
    SessionManager sessionManager;
    // Start is called before the first frame update
    void Start()
    {
        sessionManager = FindObjectOfType<SessionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        levelScore.text = sessionManager.GetLevelScore().ToString();
        totalScore.text = sessionManager.GetTotalScore().ToString();
    }
}
