using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Funcaogame");
        player = GameObject.Find("Samson");
        // chama a courtine
        StartCoroutine(DestroyGems());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
