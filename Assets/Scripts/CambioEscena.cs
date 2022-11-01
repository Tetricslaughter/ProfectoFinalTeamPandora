using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        int escenaActual = SceneManagement.GetActiveScene().buildIndex;
        if(escenaActual == "0")
        {
            SceneManager.LoadScene("SceneCueva");
        }
        // else
        // {
        //     SceneManager.LoadScene(0);

        // }
    } 
    void OnTriggerEnter(Collision other)
    {
        if(other.tag == "Player")
        {
            LoadNextScene();
        }
    }
}
