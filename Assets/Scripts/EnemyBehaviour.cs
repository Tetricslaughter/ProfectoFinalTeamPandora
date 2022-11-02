using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int hp;
    public int danioArma;
    public int danioPunio;

    private Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        if (other.gameObject.tag == "golpeImpacto")
        {
            /*if (animacion != null)
            {
                animacion.Play("NombreAnimación");
            }*/
            hp -= danioPunio;
        }
        if (hp <= 0)
        {

            animacion.SetBool("diying", true);
            //Destroy(gameObject);
        }
    }
}
