using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    private Animator anim;
    public GameObject portao;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = portao.GetComponent<Animator>();
    }
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Ativa", true);
            Debug.Log("acertou");
        }
    }

}
