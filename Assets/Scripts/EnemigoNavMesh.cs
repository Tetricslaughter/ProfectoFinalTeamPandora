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

    public GameObject trofeo;
    void Awake()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Detected();
    }

    void Detected()
    {
        detectedPlayer = Physics.CheckSphere(transform.position, rango, capaPlayer);
        if (detectedPlayer == true)
        {
            Vector3 pos = new Vector3(player.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
            transform.LookAt(pos);
            agente.SetDestination(player.GetComponent<Transform>().position);
            agente.stoppingDistance = stopEn;
        }
        else
        {
            agente.SetDestination(trofeo.GetComponent<Transform>().position);
            agente.stoppingDistance = 3;
        }
    }

    private void OnDrawGizmos()
    {   //Esto permite que la esfera sea visible
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
