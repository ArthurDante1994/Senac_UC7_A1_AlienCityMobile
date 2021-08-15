using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2D : MonoBehaviour
{
    private Touch touch;
    public GameObject createdObject;
    private Vector2 posTouch;
    private Vector3 posPlayer;
    public bool touchingPlayer = false;
    [HideInInspector] public int contador = 0;

    public Text txtcolete;
    public Text txtpoint;
    public Text txtfinalend;

    public GameObject gema;
    // Start is called before the first frame update
    void Start()
    {
        txtcolete.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        txtpoint.text = contador.ToString();
        txtfinalend.text = "Pontuação: " + contador;
        MoveTouchNew();
    }
    void testfucao()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = -10f; // select distance = 10 units from the camera
        Vector3 possicao = Camera.main.ScreenToWorldPoint(mousePos);
        possicao.z = -4.32f;
        transform.position = possicao;
        Debug.Log(possicao);
    }
    void MoveTouchNew()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Began)
         {
          posTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane + 5.65f));
          posPlayer = transform.position;
          if(posTouch.x > posPlayer.x - 1f && posTouch.x < posPlayer.x + 1f && posTouch.y > posPlayer.y - 1.5f && posTouch.y < posPlayer.y + 1.5f)
          {
             touchingPlayer = true;
             txtcolete.text = "COLETE TODAS AS GEMAS!!!";
          }
           //touchingPlayer = true;
         
         }

        if (touch.phase == TouchPhase.Ended)
        {
            touchingPlayer = false;
            txtcolete.text = "";
        }

        if (touchingPlayer)
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane + 5.65f));
            vec.z = -5.8f;
            transform.position = vec;
        }
    }
    void MovementTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                transform.position += (Vector3)t.deltaPosition / 100;
            }
        }
    }
    void MovementTouchClick()
    {
        if(Input.touchCount > 0)
        {
            Touch X = Input.GetTouch(0);
            Vector3 possicao = Camera.main.ScreenToWorldPoint(X.position);
            possicao.z = -2.9022f;
            transform.position = possicao;
        }
    }
    void newtestnew()
    {
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane + 5.0f));
                Vector3 oldVec = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log(oldVec + " vs " + vec);
                //vec.z = 0;
                Instantiate(createdObject, vec, Quaternion.identity);
            }
        }
    }
}
