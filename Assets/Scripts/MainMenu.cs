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
    {
        volumen.onValueChanged.AddListener(ChangeVolumenFx);
        volumenMaster.onValueChanged.AddListener(ChangeVolumenMaster);
    }

    public void SetVolumen()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolumen);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolumen);
        }
    }

    public void ChangeVolumenMaster(float vol)
    {
        mixer.SetFloat("VolMaster", vol);
    }

    public void ChangeVolumenFx(float vol)
    {
        mixer.SetFloat("VolFx", vol);
    }


    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void OpenPanel(GameObject pnl)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        pnl.SetActive(true);
        PlaySoundButton();
    }

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MusicSuena()
    {
        AudioPerm.Suena();
    }
}
