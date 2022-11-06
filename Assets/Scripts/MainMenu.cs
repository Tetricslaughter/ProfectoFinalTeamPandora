using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Para el manejo del sonido
    [Header("Options")]
    public Slider volumen;
    public Slider volumenMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolumen;

    //Manejo de los paneles
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;


    private void Awake()
    {//en caso de que hayan cambios en los slider, se llamaran a los metodos pasados como parametro
        volumen.onValueChanged.AddListener(ChangeVolumenFx);
        volumenMaster.onValueChanged.AddListener(ChangeVolumenMaster);
    }
    public void Start()
    {//Se hace visible el cursor, es necesario para poder clickear los botones
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetVolumen()
    {
        if (mute.isOn)
        {//en caso de se active Mute, se llevara al min volumen
            mixer.GetFloat("VolMaster", out lastVolumen);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {//cuando se desactive, volvera al ultimo volumen en el que estaba
            mixer.SetFloat("VolMaster", lastVolumen);
        }
    }

    public void ChangeVolumenMaster(float vol)
    {//en caso de se cambie el slider, se pasara el valor actualizado
        mixer.SetFloat("VolMaster", vol);
    }

    public void ChangeVolumenFx(float vol)
    {
        mixer.SetFloat("VolFx", vol);
    }


    public void PlaySoundButton()
    {//Cada vez que se hace click a un boton, sonara el audio con ese efecto
        fxSource.PlayOneShot(clickSound);
    }

    public void OpenPanel(GameObject pnl)
    {//activara/desactivara los paneles
        mainPanel.SetActive(false);//Se desactivan todos los paneles existentes
        optionsPanel.SetActive(false);

        pnl.SetActive(true);//y se activa el panel que se pasa por parametro
        PlaySoundButton();//se llama el metodo para el sonido del boton
    }

    public void PlayLevel(string levelName)
    {//cambia de escena
        //en este caso se hará por medio del nombre de la escena, y no de su indice
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {//Esto sirve cuando se hace un ejecutable, y cierra por completo el juego
        Application.Quit();
    }

    public void MusicSuena()
    {//activa la musica de fondo
        AudioPerm.Suena();
    }
}
