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
        SessionManager sessionManager = FindObjectOfType<SessionManager>();
        finalLevel.text = "You Died On Level: " + sessionManager.GetLevel();
        finalScore.text = "Final Score: " + sessionManager.GetScore().ToString();
    }
}
