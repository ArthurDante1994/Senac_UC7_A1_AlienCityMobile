using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    public AudioClip pegandomoedas;
    public GameObject sonsbase;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Funcaogame");
        player = GameObject.Find("Samson");
        sonsbase = GameObject.Find("AudioControlle");
        // chama a courtine
        StartCoroutine(DestroyGems());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sonsbase.GetComponent<audiocontrolle>().ToqueSFX(pegandomoedas);
            player.GetComponent<Move2D>().contador += 10;
            spawn.GetComponent<GemSpawner>().qtdgems--;
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyGems()
    {
        yield return new WaitForSeconds(Random.Range(3, 8));
        spawn.GetComponent<GemSpawner>().qtdgems--;
        Destroy(gameObject);
    }
}
