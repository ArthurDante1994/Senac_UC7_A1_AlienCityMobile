using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAndroid : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Alien");
    }

    public void jumpcontrol()
    {
        player.GetComponent<MyPlayerController>().jump = true;
    }
    public void Attackcontrol()
    {
        Debug.Log("O botão de ataque esta funcionado!!!");
    }

}
