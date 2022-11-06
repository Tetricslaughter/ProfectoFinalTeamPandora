using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    [SerializeField]
    private int plataformType; //para diferenciar las plataformas en el inspector
    [SerializeField]
    private float speedX;  //velocidad +
    [SerializeField]
    private float negativeSpeedX; //velocidad -
    private float posX;
    void Start()
    {
        posX = transform.position.x; //posX sea igual a transform position en x
    }

    // Update is called once per frame
    void Update()
    {
        MovePlataformas();
    }

    public void MovePlataformas()
    {
        switch (plataformType) //evaluamos la expresion
        {
            case 1:
                {
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 20f)
                    {
                        negativeSpeedX *= -1;  //cambia el signo de la velocidad
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0); //para que se mueva en el eje x la plataforma
                    break;
                }
            case 2:   //sera lo mismo en los otros casos
                {
                    if (transform.position.x < posX - 0.25f || transform.position.x > posX + 20f)
                    {
                        speedX *= -1;
                    }
                    transform.Translate(speedX * Time.deltaTime, 0, 0);
                    break;
                }
            case 3:
                {
                    if (transform.position.x > posX + 0.25f || transform.position.x < posX - 20f)
                    {
                        negativeSpeedX *= -1;
                    }
                    transform.Translate(negativeSpeedX * Time.deltaTime, 0, 0);
                    break;
                }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //cuando colisiona con objeto que tenga el tag "Player", el player se hace hijo de la plataforma esto es para que no se ...
        {                                              //caiga el jugador de la plataforma
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision) //cuando sale de esa colision ya no va a hacer hijo el player de la plataforma.
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
