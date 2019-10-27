using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] Text levelUI;
    // Start is called before the first frame update
    void Start()
    {
        levelUI.text = "Level: " + FindObjectOfType<SessionManager>().GetLevel();
    }
}