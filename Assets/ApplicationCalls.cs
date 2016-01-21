﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationCalls : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);

            
        }
    }

}
