using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios; //arreglo para que podamos poner los sonidos independientes en el inspector
    private AudioSource controlAudio; 
    public static SoundManager inst2;//variable publica y estatica que almacena una instacia de esta clase de tipo SoundManager
    //esta variable inst2 nunca se le asigno un valor asi que va a hacer null
    //como es estatica puedo acceder desde cualquier escena
    private void Awake()//antes del start
    {  
        if (SoundManager.inst2 == null)
        {
            //primera vez. Esta es la instancia unica -  si es nulo es la primera vez.
            SoundManager.inst2 = this; //Esta es la instancia unica
            DontDestroyOnLoad(gameObject);//y solo en ese caso que no lo destruya
            //cuando se crea otra instacia (escena) el scrip ya no va a hacer nulo, entonces en el else se destruye
            controlAudio = GetComponent<AudioSource>(); //obtenemos el componente
        }
        else
        {
            //ya hay una instancia. Eliminar esta
            Destroy(gameObject);
        }

    }

    public static void SeleccionAudio(int indice, float volumen) //metodo estatico 
    {
        inst2.controlAudio.PlayOneShot(inst2.audios[indice], volumen); //El metodo PlayOneShot de la clase AudioSource nesesita el indice del array y el volumen
    }
}
