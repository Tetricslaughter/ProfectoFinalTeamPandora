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
        muerto = false;                             //por defecto el player no esta muerto
        restart = FindObjectOfType<CambioEscena>(); //asigna a la variable un objeto
        barraVida.vidaMax = hpPlayer;               //asigna el hp del player a una variable del script BarraVidaBehaviour
        barraVida.vidaActual = hpPlayer;            //asigna el hp del player a una variable del script BarraVidaBehaviour
        animacion = GetComponent<Animator>();       //le asigna el componente Animator del player
        Cursor.lockState = CursorLockMode.Locked;   //estas 2 líneas hace que no sea el visible el cursor cuando se juega
        Cursor.visible = false;
        jumpForce = 6f;
        physicBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate() //Las ejecuciones por segundo del fixedUpdate es fija, mientras que en el Update es variable
    {
        //en el update esto daba problemas
        if (avanza)
        {
            physicBody.velocity = transform.forward * impulsoGolpe; //hace que el player avanze u+por un momento cuando ataca
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            if (!atacando)
            {
                MovePlayer();//el player solo se puede mover si no esta muerto y si no se esta atacando
            }
            Atacar();
        }
    }
    public void MovePlayer()
    {
        //movimiento y Rotacion
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        float rotationY = (Input.GetAxis("Mouse X"));
        transform.Rotate(new Vector3(0, rotationY, 0) * Time.deltaTime * speedRotate);
        //esto hace que se reproduscan las animaciones de moviento correspondientes
        animacion.SetFloat("VelX", horizontal);
        animacion.SetFloat("VelY", vertical);

        //SALTO 
        isJump = Input.GetButtonDown("Jump");
        //se crea un vector que apunta hacia abajo
        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 0.5f))
        {
            floorDetected = true;
        }
        else
        {
            floorDetected = false;
        }

        //si se detecta que esta en el suelo y si no esta atacando entoces recién se puede saltar
        if (floorDetected)
        {
            if (!atacando)
            {
                if (isJump)
                {
                    animacion.SetBool("jump", true);//esto hace que se reprodusca las animación del salto
                    physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //impulsa al game objet
                    SoundManager.SeleccionAudio(0, 0.05f);//reproduce el sonido correspondiente
                }
            }
            
            animacion.SetBool("hitGround", true);
        }
        else           //si no detecta el suelo entos esta en el aire
        {
            Falling();
        }
    }
    //esto hace que se reprodusca las animación de cuando el player esta en el aire
    public void Falling()
    {
        animacion.SetBool("hitGround", false);
        animacion.SetBool("jump", false);
    }

    public void Atacar()
    {
        //se puede atacar con la tecla correspondiente sólo si se detecta el suelo y si no esta atacando
        if (Input.GetKeyDown(KeyCode.E) && floorDetected && !atacando)
        {
            //hace una animacion diferente dependiendo si tiene equipado un arma
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

    //cambia el estado de la variable atacando a falso
    public void DejarDeGolpear()
    {
        atacando = false;
    }
    //cambia el estado de la variable avanza a verdadero
    public void AvanzoSolo()
    {
        avanza = true;
    }
    //cambia el estado de la variable avanza a falso
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
                hpPlayer -= danioEnemigo;//disminuye el hp del player
                barraVida.vidaActual = hpPlayer;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            }
            if (hpPlayer <= 0)
            {
                animacion.SetTrigger("estoyMuerto");//esta animación se llama al cambiar la variable de tipo Trigger "estoyMuerto" que esta en el animator del Player
                muerto = true;          //cambia el estado de muerto a true
            }
        }
        if (other.gameObject.tag == "Finish")
        {
            hpPlayer -= danio;//disminuye el hp del player
            barraVida.vidaActual = hpPlayer;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            if (!muerto)
            {
                transform.position = new Vector3(62f, 62f, 42f);//mueve al player a una posicion
            }
            
        }

    }

    //llama la escena de derrota
    public void Perdiste()
    {
        SceneManager.LoadScene(levelName);
    }
}
