using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterruptorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private int interruptorType;
    private Vector3 posPremio;
    private AgarrarPremio agarrarPremio;

     private PuertaBehaviour puertaBehaviour1;
     private PuertaBehaviour puertaBehaviour2;
     private PuertaBehaviour puertaBehaviour3;
     private PuertaBehaviour puertaBehaviour4;

    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        //se guarda una posición donde se instanciará el premio
        posPremio = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        //se busca el script correspondiente buscándolo por el nombre del gameObjet del que queremos sacar el script
        agarrarPremio = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarPremio>();
        puertaBehaviour1 = GameObject.Find("Puerta1").GetComponent<PuertaBehaviour>();
        puertaBehaviour2 = GameObject.Find("Puerta2").GetComponent<PuertaBehaviour>();
        puertaBehaviour3 = GameObject.Find("Puerta3").GetComponent<PuertaBehaviour>();
        puertaBehaviour4 = GameObject.Find("Puerta4").GetComponent<PuertaBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trofeo") == true)  //evaluá si el objeto que lo atraviesa tiene el tag Trofeo
        {
            Instantiate(premio, posPremio, transform.rotation); //instancia un premio

            agarrarPremio.DesactivarPremio(); //desactiva el premio que tiene en su mano el player

            //dependiendo de cual sea el interruptor, abre una determinada puerta
            if (puertaBehaviour1.NumberDoor == 1 && interruptorType == 1)
            {
                puertaBehaviour1.OpenClose();
            }

            if (puertaBehaviour2.NumberDoor == 2 && interruptorType == 2)
            {
                puertaBehaviour2.OpenClose();
            }

            if (puertaBehaviour3.NumberDoor == 3 && interruptorType == 3)
            {
                puertaBehaviour3.OpenClose();
            }

            if (puertaBehaviour4.NumberDoor == 4 && interruptorType == 4)
            {
                puertaBehaviour4.OpenClose();
            }
            
            if (interruptorType == 5)   //si es el ultimo
            {
                Invoke("Ganaste", 0.5f);//invoca el método Ganaste
                SoundManager.SeleccionAudio(2, 0.05f); //reproduce un sonido
                AudioPerm.Pausar();//pausa el sonido de la escena anterior
            }
        }
        
    }
    public void Ganaste()
    {//se llama a una escena, que es pasada por nombre
        SceneManager.LoadScene(levelName);
    }
}
