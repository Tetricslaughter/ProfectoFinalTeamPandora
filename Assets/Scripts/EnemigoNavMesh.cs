using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoNavMesh : MonoBehaviour
{
    //Necesario para el NavMesh
    public GameObject player;//es necesario para acceder al componente Transform y que el enemigo lo persiga
    public float stopEn;//usado para determinar a que distancia el enemigo se debe detener
    private UnityEngine.AI.NavMeshAgent agente;//es lo que permite que el enemigo reconozca un objetivo y lo persiga

    //Al detectar al jugador
    private bool detectedPlayer;//un bool que determinara si el juegador es detectado en un determinado rango
    public LayerMask capaPlayer;//funciona como un tag, el enemigo debera tener el mismo layer del objetivo a perseguir
    private float rango = 5;//es el rango, a partir de si mismo, en que el jugador puede ser detectado

    private Animator animacion;
    private bool enemigoAtacando;
    public float rangoAtaque;
    private Vector3 posEnemy;

    public GameObject baseTrofeo;//es el objeto que el enemigo irá, si no detecta al jugador
    void Awake()
    {
        animacion = GetComponent<Animator>();
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        posEnemy = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        if (!enemigoAtacando)
        {
            Detected();
        }
        Atacar();
    }

    void Detected()
    {   //se verifica si el jugador esta dentro del rango para ser perseguido, y se lo guarda en detectedPlayer
        detectedPlayer = Physics.CheckSphere(transform.position, rango, capaPlayer);
        if (detectedPlayer == true)
        {//en caso de detectarlo, se activara la animacion de caminar en el enemigo
            animacion.SetBool("avanza", true);
            //se usa LookAt para que el enemigo siempre esté mirando hacia la direccion que se dirija el jugador
            transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
            //y se establece su destino, en este caso, el jugador
            agente.SetDestination(player.GetComponent<Transform>().position);
            //agente.stoppingDistance = stopEn;
        }
        else
        {   //En caso de que no se detecte al jugador, su objetivo sera el premio y se hace lo mismo
                //se usa LookAt para mirar al premio
            transform.LookAt(new Vector3(baseTrofeo.transform.position.x, transform.position.y, baseTrofeo.transform.position.z));
            //Se establece su destino hacia el premio
            agente.SetDestination(baseTrofeo.GetComponent<Transform>().position);
            //Tambien se establece una distancia para que al acercarse no choque con el premio
            agente.stoppingDistance = stopEn;
            //Y se activa la animacion de caminar
            animacion.SetBool("avanza", true);
        }
    }

    private void OnDrawGizmos()
    {   //Esto permite que la esfera sea visible
        Gizmos.color = Color.red;//se cambia de color
        Gizmos.DrawWireSphere(transform.position, rango);//es el tamaño y lugar donde se dibujara la esfera
        Gizmos.DrawRay(posEnemy, transform.forward * rangoAtaque);

    }
    public void DejarDeGolpear()
    {
        enemigoAtacando = false;
    }
    public void Atacar()
    {
        RaycastHit hit;
        if (Physics.Raycast(posEnemy,transform.forward, out hit, rangoAtaque))
        {
            if (!enemigoAtacando)
            {
                if (hit.transform.tag == "Player")
                {
                    animacion.SetTrigger("beat2");
                    enemigoAtacando = true;
                }
                else if (hit.transform.tag == "Base")
                {
                    animacion.SetBool("avanza", false);
                }
            }
            
            
        }
    }
}
