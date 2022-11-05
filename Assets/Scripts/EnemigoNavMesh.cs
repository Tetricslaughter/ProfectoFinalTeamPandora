using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoNavMesh : MonoBehaviour
{
    //Necesario para el NavMesh
    public GameObject player;
    public float stopEn;
    private UnityEngine.AI.NavMeshAgent agente;

    //Al detectar al jugador
    private bool detectedPlayer;
    public LayerMask capaPlayer;
    private float rango = 5;

    private Animator animacion;
    private bool enemigoAtacando;
    public float rangoAtaque;
    private Vector3 posEnemy;

    public GameObject trofeo;
    void Awake()
    {
        animacion = GetComponent<Animator>();
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        posEnemy = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
        //Detected();
        if (!enemigoAtacando)
        {
            Detected();
        }
        Atacar();
    }

    void Detected()
    {
        detectedPlayer = Physics.CheckSphere(transform.position, rango, capaPlayer);
        if (detectedPlayer == true)
        {
            animacion.SetBool("avanza", true);

            //Vector3 pos = new Vector3(player.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
            transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
            agente.SetDestination(player.GetComponent<Transform>().position);
            agente.stoppingDistance = stopEn;
        }
        else
        {
            transform.LookAt(new Vector3(trofeo.transform.position.x, transform.position.y, trofeo.transform.position.z));
            agente.SetDestination(trofeo.GetComponent<Transform>().position);
            agente.stoppingDistance = 2.3f;
            animacion.SetBool("avanza", true);
        }
    }

    private void OnDrawGizmos()
    {   //Esto permite que la esfera sea visible
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
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
                    //Debug.Log("atacar");
                    //animacion.SetTrigger("beat1");
                    animacion.SetTrigger("beat2");
                    enemigoAtacando = true;
                }
                else if (hit.transform.tag == "Trofeo")
                {
                    //Debug.Log("detenerse");
                    animacion.SetBool("avanza", false);
                }
            }
            
            
        }
        /*if (Input.GetKeyDown(KeyCode.E) && floorDetected && !atacando)
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
        }*/
    }
}
