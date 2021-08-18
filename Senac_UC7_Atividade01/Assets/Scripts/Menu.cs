using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int Vidas = 3;
    public void playgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("MyLife", Vidas);
    }
    public void exitgame()
    {
        Application.Quit();
        Debug.Log("Você saiu do jogo!!!");
    }
}
