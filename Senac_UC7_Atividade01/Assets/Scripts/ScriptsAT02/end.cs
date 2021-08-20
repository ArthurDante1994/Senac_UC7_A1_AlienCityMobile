using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;
    public GameObject portao;
    public GameObject portao2;
    public float newtemp = 10f;

    // Start is called before the first frame update
    void Start()
    {
        anim = portao.GetComponent<Animator>();
        anim2 = portao2.GetComponent<Animator>();
    }
    public IEnumerator animacao()
    {
        
        anim2.SetBool("Ativa", true);
        yield return new WaitForSeconds(newtemp);
        Debug.Log("Terminou");
        SceneManager.LoadScene(3);

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Ativa", false);
            StartCoroutine(animacao());
        }
    }
}
