using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    public int dano;
    public float tempo;
    public bool estado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator Damenge(Collider objeto)
    {
        if (!estado)
        {
            estado = true;
            Debug.Log("acertou o player!!!");
            objeto.GetComponent<MyPlayerController>().TakeDamage(dano);
            yield return new WaitForSeconds(tempo);
            estado = false;
        }
    }
}
