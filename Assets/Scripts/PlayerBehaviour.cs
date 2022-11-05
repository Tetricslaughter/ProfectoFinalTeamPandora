using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private float speedRotate = 200f;
    private Animator animacion;
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
    private bool muerto;

    public CambioEscena restart;

    public int danio;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        muerto = false;
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
        if (!muerto)
        {
            if (!atacando)
            {
                MovePlayer();
            }
            Atacar();
        }
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
        }
        else
        {
            floorDetected = false;
        }

        if (floorDetected)
        {
            if (!atacando)
            {
                if (isJump)
                {
                    animacion.SetBool("jump", true);
                    physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                    SoundManager.SeleccionAudio(0, 0.05f);
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
                SoundManager.SeleccionAudio(1, 0.05f);
            }
            else
            {
                animacion.SetTrigger("golpe1");
                atacando = true;
                SoundManager.SeleccionAudio(1, 0.05f);
            }
        }
    }
    public void DejarDeGolpear()
    {
        atacando = false;
    }
    public void AvanzoSolo()
    {
        avanza = true;
    }
    public void DejaDeAvanzar()
    {
        avanza = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!muerto)
        {
            if (other.gameObject.tag == "leftImpacto")
            {
                Debug.Log("impacto");
                hpPlayer -= danioEnemigo;
                barraVida.vidaActual = hpPlayer;
            }
            if (hpPlayer <= 0)
            {
                Debug.Log("muerto");
                animacion.SetTrigger("estoyMuerto");
                muerto = true;
            }
        }
        if (other.gameObject.tag == "Finish")
        {
            hpPlayer -= danio;
            barraVida.vidaActual = hpPlayer;
            if (!muerto)
            {
                transform.position = new Vector3(62f, 62f, 42f);
            }
            
        }

    }
    public void Perdiste()
    {
        SceneManager.LoadScene(levelName);
    }
}
