using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    public void Start()
    {//Se activara el cursor para poder interactuar con botones
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayLevel(string levelName)
    {//se llama a una escena, que es pasada por nombre
        SceneManager.LoadScene(levelName);
    }
}
