using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Rigidbody rb;
    public int damege = 25;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Quebravel"))
        {
            Destroy(gameObject);
            Debug.Log("acertou o inimigo!!!");
            collider.GetComponent<DestryObject>().dano(damege);
        }
    }
}
