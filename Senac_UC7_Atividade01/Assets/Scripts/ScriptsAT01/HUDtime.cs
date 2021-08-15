using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUDtime : MonoBehaviour
{
    public GameObject fimgame;
    // Start is called before the first frame update
    void Start()
    {
        fimgame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Image>().fillAmount != 0f)
        {
            GetComponent<Image>().fillAmount -= Time.deltaTime * 0.02f;
        }
        else
        {
            Debug.Log("O tempo acabou!!!!!!!!!");
            fimgame.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
