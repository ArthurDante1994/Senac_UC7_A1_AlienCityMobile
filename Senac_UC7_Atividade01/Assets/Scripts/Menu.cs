﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void playgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void exitgame()
    {
        Application.Quit();
        Debug.Log("Você saiu do jogo!!!");
    }
}