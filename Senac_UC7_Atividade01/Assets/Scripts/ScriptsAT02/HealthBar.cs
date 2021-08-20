using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //public Text pontuacao;
    public Gradient gradient;
    public GameObject player;
    public Image fill;
    public float vida;
    public float Maxvida;
    //private int pontos = 0;
    public int quantidadevidas = 0;
    public GameObject[] minhasvidas = new GameObject[3];

    void Start()
    {
        quantidadevidas = PlayerPrefs.GetInt("MyLife");
        player = GameObject.Find("Alien");
        for (int i = 0; i < quantidadevidas; i++)
        {
            minhasvidas[i].SetActive(true);
        }
        Debug.Log(PlayerPrefs.GetInt("MyLife"));

    }

    public void setmaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        vida = health;
        Maxvida = health;
    }
    public void sethealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        vida = health;
    }
    /*
    public void setpontos(int pont)
    {
        pontos += pont;
        pontuacao.text = pontos.ToString();
    }
    */
    public void setvidasplayer(int vid)
    {
        quantidadevidas -= vid;
        PlayerPrefs.SetInt("MyLife", quantidadevidas);
        switch (quantidadevidas)
      {
          case 0:
                Handheld.Vibrate();
                minhasvidas[0].SetActive(false);
                SceneManager.LoadScene(4);
            break;
          case 1:
                minhasvidas[1].SetActive(false);
                SceneManager.LoadScene(2);
                player.GetComponent<MyPlayerController>().HealingLife((int)Maxvida);
            break;
          case 2:
                minhasvidas[2].SetActive(false);
                SceneManager.LoadScene(2);
                player.GetComponent<MyPlayerController>().HealingLife((int)Maxvida);
                break;
            default:
                Debug.Log("Não tem  o jogador");
            break;
        }
    }
    void Update()
    {
        //pontuacao.text = pontos.ToString();
        if(vida <= 0)
        {
            setvidasplayer(1);
        }
    }
}
