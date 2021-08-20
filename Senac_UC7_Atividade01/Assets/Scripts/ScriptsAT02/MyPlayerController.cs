using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    private Animator anim;

    public float MoveSpeed = 2f;
    public float RotationSpeed = 5f;
    public bool jump = false;

    private Vector3 gravidade;
    private Vector3 moviment;
    private CharacterController cc;
    public Transform floorCollidor;

    public bool ControlGame = false;
    public Joystick joystick;
    public Color[] cores;
    private GameObject mallhadoalien;
    private bool ativado;
    public float newtemp = 0.5f;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        if(cores.Length == 0)
        {
            Debug.LogWarning("Crie uma lista com uma ou mais cores");

            return;
        }

        mallhadoalien = GameObject.Find("MalhaAlien");
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        healthbar.setmaxhealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControlGame)
        {
            // função de controle para teclado
            moviment = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));
            Movimentacao();
        }
        else
        {
            // função de controle para celular
            moviment = joystick.Vertical * transform.TransformDirection(Vector3.forward) * MoveSpeed;
            transform.Rotate(new Vector3(0, joystick.Horizontal * RotationSpeed * Time.deltaTime, 0));
            Movimentacao();
        }
    }
    // função de movimentação do personagem principal
    void Movimentacao()
    {
        testdamege();
        if (isjumpcontrole())
        {
            jump = true;
            Debug.Log("Esta funcionando o pulor");
        }
        if (!cc.isGrounded)
        {
            gravidade += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravidade = Vector3.zero;
            if (jump && floorCollidor.GetComponent<FloorCollidor>().canJump == true)
            {
                //anim.SetTrigger("Pula");
                floorCollidor.GetComponent<FloorCollidor>().canJump = false;
                gravidade.y = 10f;
                jump = false;
            }
        }
        moviment += gravidade;

        cc.Move(moviment * Time.deltaTime);
        //Debug.Log("esta Correndo " + moviment.x);
        if (Input.anyKey && Input.GetAxis("Vertical") != 0 || joystick.Vertical != 0)
        {
            if (floorCollidor.GetComponent<FloorCollidor>().canJump == true)
            {
                anim.SetTrigger("Corre");
                //Debug.Log("esta Correndo " + moviment.x);
            }
            else
            {
                anim.SetTrigger("Pula");
            }
        }
        else
        {
            if (floorCollidor.GetComponent<FloorCollidor>().canJump == true)
            {
                anim.SetTrigger("Parado");
                //Debug.Log("esta parado " + moviment.x);
            }
            else
            {
                anim.SetTrigger("Pula");
            }
        }
    }
    public IEnumerator animacaodano()
    {
        Color dano = cores[0];
        Color normal = cores[1];
        if (!ativado)
        {
            ativado = true;
            mallhadoalien.GetComponent<Renderer>().material.color = dano;
            yield return new WaitForSeconds(newtemp);
            mallhadoalien.GetComponent<Renderer>().material.color = normal;
            yield return new WaitForSeconds(newtemp);
            ativado = false;
        }
    }
    public void TakeDamage(int damage)
    {
        // sistema de damo de vida do jogado
        currentHealth -= damage;
        Handheld.Vibrate();
        StartCoroutine(animacaodano());
        healthbar.sethealth(currentHealth);
    }

    public void HealingLife(int healing)
    {
        // sistema de recuperação de vida do jogado
        currentHealth += healing;
        if(currentHealth > 100)
        {
            currentHealth = 100;
            healthbar.sethealth(currentHealth);
        }
        else
        {
            healthbar.sethealth(currentHealth);
        }

    }

    public void testdamege()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }
    public bool isjumpcontrole()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
