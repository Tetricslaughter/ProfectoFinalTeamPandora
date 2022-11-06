using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField]
    private int ArrowType; //para diferenciar las flechas
    [SerializeField]
    private float speed; //velocidad

    // Update is called once per frame
    void Update()
    {
        switch (ArrowType) //evaluamos la expresion
        {
            case 1:
                {
                    transform.Translate(0, speed * Time.deltaTime, 0); //que se trasladen en el eje y..... las flechas estan rotadas 
                    break;
                }
                case 2:
                    {
                        transform.Translate(0, speed * Time.deltaTime, 0);
                        break;
                    }
        }
        DestroyArrow();
    }

    public void DestroyArrow() //este metodo va a ser para que se destruyan las flechas y no sobrecargar la escena
    {
        if (transform.position.z > 135f)
        {
            Destroy(gameObject);
        }
        if (ArrowType == 2 && transform.position.x < 50)
        {
            Destroy(gameObject);
        }
    }

}
