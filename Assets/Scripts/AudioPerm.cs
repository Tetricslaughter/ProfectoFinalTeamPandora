using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPerm : MonoBehaviour
{
    AudioSource _audio;
    public static AudioPerm inst;
    private void Awake()
    {
        if (AudioPerm.inst ==null)
        {
            //primera vez. Esta es la instancia unica
            AudioPerm.inst = this;
            DontDestroyOnLoad(gameObject);
            _audio = GetComponent<AudioSource>();
        }
        else
        {
            //ya hay una instancia. Eliminar esta
            Destroy(gameObject);
        }
    }

    public static void Suena()
    {
        inst._audio.Play();
    }

    public static void Pausar()
    {
       inst._audio.Pause(); //desde otros scripts podemos llamar a este metodo
    }

    public static void Despausar()
    {
        inst._audio.UnPause(); //desde otros scripts podemos llamar a este metodo
    }
}
