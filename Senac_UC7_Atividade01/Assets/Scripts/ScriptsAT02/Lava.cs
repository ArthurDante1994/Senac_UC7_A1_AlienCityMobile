using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Armadilha
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damenge(collider));
            //Debug.Log("acertou");
        }
    }
  

}
