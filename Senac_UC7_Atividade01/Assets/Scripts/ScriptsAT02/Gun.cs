using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletpoint;
    public GameObject bulletprefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletpoint = GameObject.Find("Mira").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletprefab, bulletpoint.position, bulletpoint.rotation);
        }
    }
}
