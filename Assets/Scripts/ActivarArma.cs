using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArma : MonoBehaviour
{
    
    private AgarrarArma agarrarArma;
    // Start is called before the first frame update
    void Start()
    {
        //se asigna el script AgarrarArma del Player
        agarrarArma = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarArma>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //si el el Player atraviesa con el objeto se activa el arma de su mano derecha
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            agarrarArma.ActivateArma();
            Destroy(gameObject); //se destruye este objeto
        }
    }
}
