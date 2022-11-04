using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private float speedRotate = 200f;
    private Animator animacion;
    //private float x, y;
    private float jumpForce;
    private Rigidbody physicBody;
    private bool isJump = false;
    private bool floorDetected = false;

    private bool atacando;
    public bool avanza;
    public float impulsoGolpe = 10f;

    public bool conArma;

    public int hpPlayer;
    public BarraVidaBehaviour barraVida;
    public int danioEnemigo;

    public CambioEscena restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = FindObjectOfType<CambioEscena>();
        barraVida.vidaMax = hpPlayer;
        barraVida.vidaActual = hpPlayer;
        animacion = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jumpForce = 6f;
        physicBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (avanza)
        {
            physicBody.velocity = transform.forward * impulsoGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!atacando)
        {
            MovePlayer();
        }
        Atacar();
        //barraVida.vidaActual = hpPlayer;

    }
    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        float rotationY = (Input.GetAxis("Mouse X"));
        transform.Rotate(new Vector3(0, rotationY, 0) * Time.deltaTime * speedRotate);

        animacion.SetFloat("VelX", horizontal);
        animacion.SetFloat("VelY", vertical);
        isJump = Input.GetButtonDown("Jump");

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 0.5f))
        {
            floorDetected = true;
             //Debug.Log("esta en true");
        }
        else
        {
            floorDetected = false;
        }


        /*if (floorDetected)
        {
            if (isJump)
            {
                animacion.SetBool("jump", true);
                physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            animacion.SetBool("hitGround", true);
        }
        else
        {
            Falling();
        }*/

        if (floorDetected)
        {
            if (!atacando)
            {
                if (isJump)
                {
                    animacion.SetBool("jump", true);
                    physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                }
            }
            
            animacion.SetBool("hitGround", true);
        }
        else
        {
            Falling();
        }
    }
    public void Falling()
    {
        animacion.SetBool("hitGround", false);
        animacion.SetBool("jump", false);
    }

    public void Atacar()
    {

        if (Input.GetKeyDown(KeyCode.E) && floorDetected && !atacando)
        {
            
            if (conArma)
            {
                animacion.SetTrigger("golpe2");
                atacando = true;
            }
            else
            {
                animacion.SetTrigger("golpe1");
                atacando = true;
            }
        }
    }
    public void DejarDeGolpear()
    {
        atacando = false;
        //avanza = false;
    }
    public void AvanzoSolo()
    {
        avanza = true;
    }
    public void DejaDeAvanzar()
    {
        avanza = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Finish")
        {
            restart.CargaEscenaActual();
            // transform.position = new Vector3(62f,62f,42f);
        }
        /*if (collision.gameObject.tag=="leftImpacto")
        {
            Debug.Log("imactoI");
        }
        if (collision.gameObject.tag == "rightImpacto")
        {
            Debug.Log("imactoD");
        }*/

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rightImpacto")
        {
      
            //Debug.Log("impacto");
            hpPlayer -= danioEnemigo;
            barraVida.vidaActual = hpPlayer;
        }
        if (other.gameObject.tag == "leftImpacto")
        {
            
            hpPlayer -= danioEnemigo;
            barraVida.vidaActual = hpPlayer;
        }
        if (hpPlayer <= 0)
        {
            Debug.Log("muerto");
            //animacion.SetBool("diying", true);
            //animacion.SetTrigger("death");
        }
    }
}
