using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorNvl1 : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private int interruptorType;
    private Vector3 posPremio;
    private AgarrarPremio agarrarPremio;

    private PuertaBehaviour puertaBehaviour1;

    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        //se guarda una posición donde se instanciará el premio
        posPremio = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        //se busca el script correspondiente buscándolo por el nombre del gameObjet del que queremos sacar el script
        agarrarPremio = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarPremio>();
        puertaBehaviour1 = GameObject.Find("PuertaNvl1").GetComponent<PuertaBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trofeo") == true) //evaluá si el objeto que lo atraviesa tiene el tag Trofeo
        {
            Instantiate(premio, posPremio, transform.rotation); //instancia un premio

            agarrarPremio.DesactivarPremio();   //desactiva el premio que tiene en su mano el player

            //abre una puerta
            if (puertaBehaviour1.NumberDoor == 6 && interruptorType == 6)
            {
                puertaBehaviour1.OpenClose();
            }
        }

    }
}
