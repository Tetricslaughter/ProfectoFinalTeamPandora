using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow1; //para que podamos instanciar las flechas en el empty
    [SerializeField]
    private GameObject arrow2;
    [SerializeField]
    private int generatorType; //para diferencias los generadores 
    private float randomTime = 0; //que se generen las flechas al inicio
    void Start()
    {
        Invoke("ShootBullet", randomTime);
    }

    public void ShootBullet()
    {
        switch (generatorType) //evalua la expresion
        {
            case 1:
                {
                    Instantiate(arrow1, transform.position, transform.rotation); //instancia las flechas en el transform del empty
                    break;
                }
            case 2:
                {
                    Instantiate(arrow2, transform.position, transform.rotation);
                    break;
                }
        }
        randomTime = Random.Range(8, 10);
        Invoke("ShootBullet", randomTime); //llamamos de vuelta al Invoke

    }
}
