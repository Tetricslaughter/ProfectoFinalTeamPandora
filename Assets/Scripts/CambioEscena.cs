using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importamos la libreria 

public class CambioEscena : MonoBehaviour
{
    [SerializeField] private float transicionTime = 1f; //el tiempo
    private Animator transicionAnimator; //de tipo Animator
    public int numeroEscena; //Escena que queremos que se muestre que vamos a poner en el inspector
    public int  escenaActual;

    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().buildIndex; // que la escena actual obtenga la escena actual con el metodo "GetActiveScene"
        transicionAnimator = GetComponentInChildren<Animator>(); //que busque entre sus hijos del gambe object el componente Animator
        Debug.Log(escenaActual);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //cuando entre en la region del G.O con el tag Player, cargue el metodo
        {
            CargaSiguienteEscena();
        }
    }
    public void CargaSiguienteEscena()
    {
        StartCoroutine(CargaEscena(numeroEscena)); //se encarga de arrancar la corrutina, en cual le pasamos la corrutina(el metodo"CargaEscena") y el parametro 
                                                   //de numeroEscena que pusimos en el inspector que es un int
                                                  //en el buildSettings el segundo nivel es el que tiene el numero 1
    }
    public IEnumerator CargaEscena(int sceneIndex) //IEnumerator basicamente hace que itere hasta algun punto y retornar algun valor o ninguno hasta que termine
    {
        //dispara el trigger para reproducir la animacion fade in 
        transicionAnimator.SetTrigger("StartTransicion"); 
        //espera un segundo
        yield return new WaitForSeconds(transicionTime);
        //carga la escena
        SceneManager.LoadScene(sceneIndex); //le pasamos el parametro int
    }
    public void CargaEscenaActual()
    {
        StartCoroutine(CargaEscena(escenaActual));
        
    }
}