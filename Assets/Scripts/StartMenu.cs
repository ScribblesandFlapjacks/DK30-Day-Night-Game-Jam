﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void ChangeSceneTo(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
