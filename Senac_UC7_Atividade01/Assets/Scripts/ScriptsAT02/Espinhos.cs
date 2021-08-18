using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : Armadilha
{
    private Animator anim;
    public GameObject portao;
    public float newtemp = 10f;
    private bool ativado = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = portao.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(animacao());
    }
    public IEnumerator animacao()
    {
        if (!ativado)
        {
            ativado = true;
            anim.SetBool("Ativa",true);
            yield return new WaitForSeconds(newtemp);
            anim.SetBool("Ativa", false);
            yield return new WaitForSeconds(newtemp);
            ativado = false;
        }
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
