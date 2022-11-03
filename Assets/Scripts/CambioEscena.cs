using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    [SerializeField] private float transicionTime = 1f;
    private Animator transicionAnimator;
    public int numeroEscena;
    public int  escenaActual;

    // public void LoadNextScene()
    // {
    //     int escenaActual = SceneManagement.GetActiveScene().buildIndex;
    //     if(escenaActual == "0")
    //     {
    //         SceneManager.LoadScene("SceneCueva");
    //     }
    //     // else
    //     // {
    //     //     SceneManager.LoadScene(0);

    //     // }
    // } 

    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().buildIndex;
        transicionAnimator = GetComponentInChildren<Animator>();
        Debug.Log(escenaActual);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CargaSiguienteEscena();
        }
    }
    public void CargaSiguienteEscena()
    {
        StartCoroutine(CargaEscena(numeroEscena));
        
    }
    public IEnumerator CargaEscena(int sceneIndex)
    {
        //dispara el trigger para reproducir la animacion fade in 
        transicionAnimator.SetTrigger("StartTransicion");
        //espera un segundo
        yield return new WaitForSeconds(transicionTime);
        //carga la escena
        SceneManager.LoadScene(sceneIndex);
    }
    public void CargaEscenaActual()
    {
        StartCoroutine(CargaEscena(escenaActual));
        
    }
}