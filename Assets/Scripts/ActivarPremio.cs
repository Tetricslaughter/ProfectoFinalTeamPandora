using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPremio : MonoBehaviour
{
    private AgarrarPremio agarrarPremio;
    // Start is called before the first frame update
    void Start()
    {
        //se asigna el script AgarrarPremio del Player
        agarrarPremio = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarPremio>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //si el el Player atraviesa con el objeto se activa el Premio de su mano izquierda
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            agarrarPremio.ActivatePremio();
            Destroy(gameObject);//se destruye este objeto
        }
    }
}
