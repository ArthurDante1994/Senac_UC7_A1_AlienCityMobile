using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gem;
    [HideInInspector]public int qtdgems = 0;
    public GameObject[] spawnPoints = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(qtdgems < 3)
        {
            Instantiate(gem, spawnPoints[Random.Range(0, 6)].transform.position, transform.rotation);
            qtdgems++;
        }
    }
}
