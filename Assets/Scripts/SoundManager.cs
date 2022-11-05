using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios;
    private AudioSource controlAudio;
    public static SoundManager inst2;
    private void Awake()
    {  
        if (SoundManager.inst2 == null)
        {
            //primera vez. Esta es la instancia unica
            SoundManager.inst2 = this;
            DontDestroyOnLoad(gameObject);
            controlAudio = GetComponent<AudioSource>();
        }
        else
        {
            //ya hay una instancia. Eliminar esta
            Destroy(gameObject);
        }

    }

    public static void SeleccionAudio(int indice, float volumen)
    {
        inst2.controlAudio.PlayOneShot(inst2.audios[indice], volumen);
    }
}
