using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = "Final Score: " + FindObjectOfType<Score>().getScore().ToString();
    }
}
