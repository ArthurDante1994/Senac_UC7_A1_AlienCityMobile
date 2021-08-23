using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMenu : MonoBehaviour
{
    private Touch touch;
    public GameObject menusistema;
    public bool ativado;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }
    // Update is called once per frame
    void Update()   
    {
        if (ativado)
        {
            if (Input.GetMouseButtonDown(0))
            {
                menusistema.SetActive(true);
                Debug.Log("Sistema de mouse funcionando!!");
            }
        }
    }
    void touchsystem()
    {
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane + 5.0f));
                Vector3 oldVec = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log(oldVec + " vs " + vec);

            }
        }
    }
    private void OnMouseEnter()
    {
        ativado = true;
    }
    private void OnMouseExit()
    {
        ativado = false;
    }

}
