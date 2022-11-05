using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaWinner : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //PlayLevel();
            Invoke("Ganaste", 0.5f);
        }
    }*/

    public void Ganaste()
    {
        SceneManager.LoadScene(levelName);
    }
}
