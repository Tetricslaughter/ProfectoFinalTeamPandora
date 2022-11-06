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
        barraVida.vidaMax = hp; //se asigna el hp a una variable del script BarraVidaBehaviour
        barraVida.vidaActual = hp; //se asigna el hp a una variable del script BarraVidaBehaviour
        animacion = GetComponent<Animator>(); //se le asigna el componente Animator del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto") //"armaImpacto" es el tag que tiene la espada
        {
            hp -= danioArma;            //disminuye el hp del enemigo con el daño que causa la espada
            barraVida.vidaActual = hp;
        }
        if (other.gameObject.tag == "golpeImpacto") //"golpeImpacto" es el tag que tiene el puño del personaje
        {
            hp -= danioPunio;           //disminuye el hp del enemigo con el daño que causa el puño del player
            barraVida.vidaActual = hp;  //se asigna el hp Actual a una variable del script BarraVidaBehaviour 
        }
        if (hp <= 0)                        //si el hp es menor o igual a 0 se reproduce la animación de muerte del enemigo
        {
            animacion.SetTrigger("death");  //esta animación se llama al cambiar la variable de tipo Trigger "death" que esta en el animator del enemigo
        }
    }

    //Destruye al objeto Enemigo. esta funcion se llama a través de un evento que esta en la animacion de muerte
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
