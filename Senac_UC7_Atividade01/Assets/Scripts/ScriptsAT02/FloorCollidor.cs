using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollidor : MonoBehaviour
{
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump == true)
        {
           // Debug.Log("Esta no Chao o personagem!!!");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Chao")
        {
            canJump = true;
        }
    }
}
