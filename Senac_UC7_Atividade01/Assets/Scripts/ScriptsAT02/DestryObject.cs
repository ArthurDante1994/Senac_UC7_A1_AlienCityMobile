using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryObject : MonoBehaviour
{
    public int maxHealth = 100;
    public int Health;
    public GameObject destryparede;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        destryparede.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            destryparede.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void dano(int valor)
    {
        Health -= valor;
    }
}
