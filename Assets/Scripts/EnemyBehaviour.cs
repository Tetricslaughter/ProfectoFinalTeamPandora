using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private int enemyType;
    public int hp;
    public int danioArma;
    public int danioPunio;

    private Animator animacion;

    public BarraVidaBehaviour barraVida;
    // Start is called before the first frame update
    void Start()
    {
        barraVida.vidaMax = hp;
        barraVida.vidaActual = hp;
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            /*if (animacion != null)
            {
                animacion.Play("NombreAnimación");
            }*/
            hp -= danioArma;
            barraVida.vidaActual = hp;
        }
        if (other.gameObject.tag == "golpeImpacto")
        {
            /*if (animacion != null)
            {
                animacion.Play("NombreAnimación");
            }*/
            hp -= danioPunio;
            barraVida.vidaActual = hp;
        }
        if (hp <= 0)
        {

            //animacion.SetBool("diying", true);
            animacion.SetTrigger("death");
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
